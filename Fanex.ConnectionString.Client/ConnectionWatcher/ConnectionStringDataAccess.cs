// --------------------------------------------------------------------------
// <copyright file="ConnectionStringDataAccess.cs" company="Nexcel Solutions Vietnam">
// Copyright (c) Nexcel Solutions Vietnam. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------
// <history>
//   <change who="Edward.Nguyen" date="2013.1.11">Created</change>
// </history>

namespace Fanex.ConnectionString.Client.ConnectionWatcher
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading;
    using Fanex.ConnectionString.Client.Configuration;

    /// <summary>
    /// The connection string data access class.
    /// </summary>
    internal class ConnectionStringDataAccess : IDisposable
    {
        #region Memeber

        private string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private IDataReader _result;
        private SqlWatcherNotificationType _notificationType;

        #endregion

        #region Ctor

        public ConnectionStringDataAccess(string connectionString, SqlCommand command, SqlWatcherNotificationType notificationType)
        {
            this._notificationType = notificationType;
            this._connectionString = connectionString;
            SqlDependency.Start(this._connectionString, ConnectionSettings.Settings.Queue);
            this._connection = new SqlConnection(this._connectionString);
            this._command = command;
            this._command.Connection = this._connection;
        }

        #endregion

        public delegate void SqlWatcherEventHandler(IDataReader Result);

        public event SqlWatcherEventHandler OnChange;

        public IDataReader DataSet
        {
            get { return _result; }
        }

        public void Start()
        {
            RegisterForChanges();
        }

        public void Stop()
        {
            SqlDependency.Stop(this._connectionString, ConnectionSettings.Settings.Queue);
        }

        public void ChangeEventWrapper(object state)
        {
            IDataReader result = (IDataReader)state;
            OnChange(result);
        }

        public void Dispose()
        {
            Stop();
        }

        /// <summary>
        /// Handles the OnChange event of the Handle control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SqlNotificationEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ApplicationException">Failed to create queue notification subscription!.</exception>
        private void Handle_OnChange(object sender, SqlNotificationEventArgs e)
        {
            if (e.Type != SqlNotificationType.Change)
            {
                throw new ApplicationException("Failed to create queue notification subscription!");
            }

            // Clean up the old notification
            SqlDependency dep = (SqlDependency)sender;
            dep.OnChange -= Handle_OnChange;

            // Register for the new notification
            RegisterForChanges();
        }

        /// <summary>
        /// Registers for changes.
        /// </summary>
        private void RegisterForChanges()
        {
            try
            {
                if (this._connection.State == ConnectionState.Closed)
                {
                    this._connection.Open();
                }

                // Remove old dependency object
                this._command.Notification = null;

                // Create new dependency object
                SqlDependency dep = new SqlDependency(this._command, string.Format("service={0};local database=bodb_ConnectionString", ConnectionSettings.Settings.Service), 120);
                dep.OnChange += new OnChangeEventHandler(Handle_OnChange);

                // Save data
                _result = this._command.ExecuteReader();

                // Notify client of change to DataSet
                switch (_notificationType)
                {
                    case SqlWatcherNotificationType.Blocking:
                        OnChange(_result);
                        break;
                    case SqlWatcherNotificationType.Threaded:
                        ThreadPool.QueueUserWorkItem(ChangeEventWrapper, _result);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this._connection.Close();
            }
        }
    }
}
