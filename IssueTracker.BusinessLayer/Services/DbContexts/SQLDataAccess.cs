using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using IssueTracker.BusinessLayer.Base;
using IssueTracker.BusinessLayer.Contracts;

namespace IssueTracker.BusinessLayer.Services.DbContexts
{
    /// <summary>
    /// Purpose:    This class will call the database stored procedures or views [TODO] to access data or to save data.
    /// Created By: Arpit Shrivastava
    /// Created Dt: 20 Dec 2019 04:52
    /// </summary>
    public class SQLDataAccess : IApplicationDBContext
    {
        private SqlConnection _conn;
        private SqlTransaction _tran;

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["IssueTrackerConnectionString"].ConnectionString;
        }

        public async Task OpenConnectionAsync()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();

            _conn = new SqlConnection(GetConnectionString());
            await _conn.OpenAsync();
        }
        public void CloseConnection()
        {
            if (_conn.State == ConnectionState.Closed)
                return;

            _conn.Close();
            _conn.Dispose();
        }

        public async Task BeginTransactionAsync()
        {
            if (_conn.State == ConnectionState.Closed)
                await _conn.OpenAsync();
            if (_tran != null)
                return;

            _tran = _conn.BeginTransaction();
        }
        public void RollbackTransaction()
        {
            if (_tran == null || _tran.Connection == null)
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

        public async Task<ResultList<TResponse>> LoadDataAsync<TResponse>(string storedProcedure, object parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                    dynamicp.Add("R_Data", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    var result = await con.QueryAsync<TResponse>(storedProcedure, dynamicp, commandType: CommandType.StoredProcedure);

                    List<TResponse> data = result.ToList();

                    byte hasValue = dynamicp.Get<byte>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");
                    long recordCount = dynamicp.Get<long>("R_Data");

                    if (hasValue == 0)
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

        public async Task<ResultList<TResponse>> LoadDataAsync<TRequest, TResponse>(string storedProcedure, TRequest parameters)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                    dynamicp.Add("R_Data", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    var result = await con.QueryAsync<TResponse>(storedProcedure, dynamicp, commandType: CommandType.StoredProcedure);

                    List<TResponse> data = result.ToList();

                    byte hasValue = dynamicp.Get<byte>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");
                    long recordCount = dynamicp.Get<long>("R_Data");

                    if (hasValue == 0)
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

        public async Task<ResultSingle<long>> SaveDataAsync(string storedProcedure, object parameters)
        {
            try
            {
                using (_conn = new SqlConnection(GetConnectionString()))
                {
                    var dynamicp = new DynamicParameters();
                    dynamicp.AddDynamicParams(parameters);
                    dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                    dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                    dynamicp.Add("R_Data", dbType: DbType.Int64, direction: ParameterDirection.Output);

                    await BeginTransactionAsync();
                    await _conn.ExecuteAsync(storedProcedure, dynamicp, _tran, commandType: CommandType.StoredProcedure);

                    byte hasValue = dynamicp.Get<byte>("R_Success");
                    string message = dynamicp.Get<string>("R_Message");
                    long RecordId = dynamicp.Get<long>("R_Data");

                    if (hasValue == 0)
                        throw new ArgumentException(message);

                    CommitTransaction();
                    return new ResultSingle<long>(true) { Message = message, Data = RecordId };
                }
            }
            catch (ArgumentException ex)
            {
                RollbackTransaction();
                return new ResultSingle<long>(false) { Message = ex.Message };
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                CloseConnection();
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
        public async Task<ResultSingle<TResponse>> SaveContinueDataAsync<TResponse>(string storedProcedure, object parameters)
        {
            try
            {
                if (_conn == null || _conn.State == ConnectionState.Closed)
                    throw new Exception("Connection is required to save continue data. Please use OpenConnection method.");

                if (_tran == null)
                    throw new Exception("Transaction is required to save continue data. Please use BeginTransaction method.");

                var dynamicp = new DynamicParameters();
                dynamicp.AddDynamicParams(parameters);
                dynamicp.Add("R_Success", dbType: DbType.Byte, direction: ParameterDirection.Output);
                dynamicp.Add("R_Message", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                dynamicp.Add("R_Data", dbType: DbType.Object, direction: ParameterDirection.Output);

                await _conn.ExecuteAsync(storedProcedure, dynamicp, _tran, commandType: CommandType.StoredProcedure);

                byte hasValue = dynamicp.Get<byte>("R_Success");
                string message = dynamicp.Get<string>("R_Message");
                TResponse data = (TResponse)dynamicp.Get<object>("R_Data");

                if (hasValue == 0)
                    throw new ArgumentException(message);

                return new ResultSingle<TResponse>(true) { Message = message, Data = data };
            }
            catch (ArgumentException ex)
            {
                RollbackTransaction();
                CloseConnection();
                return new ResultSingle<TResponse>(false) { Message = ex.Message };
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                CloseConnection();
                throw;
            }
        }

    }
}
