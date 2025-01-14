using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using IssueTracker.ModelLayer.Base;

namespace IssueTracker.DataLayer
{
    /// <summary>
    /// Purpose:    This class will call the database stored procedures or views [TODO] to access data or to save data.
    /// Created By: Arpit Shrivastava
    /// Created Dt: 20 Dec 2019 04:52
    /// </summary>
    public class SQLDataAccess : IApplicationDBContext
    {
        #region Design Pattern: Singleton (Single Instance)

        private static readonly object lockObject = new object();
        private static SQLDataAccess _Instance;

        public static SQLDataAccess Instance
        {
            get
            {
                //Lock is used to make the call Thread-safe
                lock (lockObject)
                {
                    if (_Instance == null)
                    {
                        _Instance = new SQLDataAccess();
                    }
                }
                return _Instance;
            }
        }
        #endregion

        private SqlConnection _conn;
        private SqlTransaction _tran;

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IssueTrackerConnectionString"].ConnectionString;
        }

        public void OpenConnection()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();

            _conn = new SqlConnection(GetConnectionString());
            _conn.Open();
        }
        public void CloseConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                return;

            _conn.Close();
            _conn.Dispose();
        }

        public void BeginTransaction()
        {
            if (_conn.State == ConnectionState.Closed)
                _conn.Open();
            if (_tran != null)
                return;

            _tran = _conn.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            if (_tran == null)
                return;

            _tran.Rollback();
            _tran.Dispose();
        }
        public void CommitTransaction()
        {
            if (_tran == null)
                return;

            _tran.Commit();
            _tran.Dispose();
        }

        public ResultList<TResponse> LoadData<TResponse>(string storedProcedure, object parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new Dapper.DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);

                    List<TResponse> data = con.Query<TResponse>(storedProcedure, dynamicp, commandType: CommandType.StoredProcedure).ToList();

                    ushort isSuccess = dynamicp.Get<ushort>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");

                    if (isSuccess > 10)
                        throw new Exception(message);

                    if (isSuccess == 0)
                        throw new ArgumentException(message);

                    if (data == null || data.Count <= 0)
                        return new ResultList<TResponse>(false) { Message = "No Record Found." };

                    return new ResultList<TResponse>(true) { Message = message, Data = data };
                }
            }
            catch (ArgumentException ex)
            {
                return new ResultList<TResponse>(false) { Message = ex.Message };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultList<TResponse> LoadData<TRequest, TResponse>(string storedProcedure, TRequest parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new Dapper.DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_RecordCount", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);

                    List<TResponse> data = con.Query<TResponse>(storedProcedure, dynamicp, commandType: CommandType.StoredProcedure).ToList();

                    int recordCount = dynamicp.Get<int>("R_RecordCount");
                    ushort isSuccess = dynamicp.Get<ushort>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");

                    if (isSuccess > 10)
                        throw new Exception(message);

                    if (isSuccess == 0)
                        throw new ArgumentException(message);

                    if (data == null || data.Count <= 0)
                        return new ResultList<TResponse>(false) { Message = "No Record Found.", RecordCount = recordCount };

                    return new ResultList<TResponse>(true) { Message = message, Data = data, RecordCount = recordCount };
                }
            }
            catch (ArgumentException ex)
            {
                return new ResultList<TResponse>(false) { Message = ex.Message };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ResultSingle<TResponse> SaveData<TResponse>(string storedProcedure, object parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new Dapper.DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                    dynamicp.Add("R_Data", dbType: DbType.Object, direction: ParameterDirection.Output);

                    _tran = con.BeginTransaction();
                    con.Execute(storedProcedure, dynamicp, _tran, commandType: CommandType.StoredProcedure);

                    ushort isSuccess = dynamicp.Get<ushort>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");
                    TResponse data = dynamicp.Get<TResponse>("R_Data");

                    if (isSuccess > 10)
                        throw new Exception(message);

                    if (isSuccess == 0)
                        throw new ArgumentException(message);

                    _tran.Commit();
                    return new ResultSingle<TResponse>(true) { Message = message, Data = data };
                }
            }
            catch (ArgumentException ex)
            {
                if (_tran != null)
                    _tran.Rollback();
                return new ResultSingle<TResponse>(false) { Message = ex.Message };
            }
            catch (Exception)
            {
                if (_tran != null)
                    _tran.Rollback();
                throw;
            }
        }

        /// <summary>
        /// OPEN THE CONNECTION
        /// BEGIN TRANSACTION
        /// DISPOSE TRANSACTION
        /// DISPOSE CONNECTION
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ResultSingle<TResponse> SaveContinueData<TResponse>(string storedProcedure, object parameters)
        {
            try
            {
                if (_conn == null || _conn.State == ConnectionState.Closed)
                    throw new Exception("Connection is required to save continue data. Please use OpenConnection method.");

                if (_tran == null)
                    throw new Exception("Transaction is required to save continue data. Please use BeginTransaction method.");

                var dynamicp = new Dapper.DynamicParameters();
                dynamicp.AddDynamicParams(parameters);
                dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                dynamicp.Add("R_Data", dbType: DbType.Object, direction: ParameterDirection.Output);

                _conn.Execute(storedProcedure, dynamicp, _tran, commandType: CommandType.StoredProcedure);

                ushort isSuccess = dynamicp.Get<ushort>("R_Success");
                string message = dynamicp.Get<string>("R_Message");
                TResponse data = dynamicp.Get<TResponse>("R_Data");

                if (isSuccess > 10)
                    throw new Exception(message);

                if (isSuccess == 0)
                    throw new ArgumentException(message);

                return new ResultSingle<TResponse>(true) { Message = message, Data = data };
            }
            catch (ArgumentException ex)
            {
                if (_tran != null)
                    _tran.Rollback();
                return new ResultSingle<TResponse>(false) { Message = ex.Message };
            }
            catch (Exception)
            {
                if (_tran != null)
                    _tran.Rollback();
                throw;
            }
        }

    }
}
