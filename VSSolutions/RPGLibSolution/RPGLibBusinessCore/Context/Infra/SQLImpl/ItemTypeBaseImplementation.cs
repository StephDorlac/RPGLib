using RPGLibBusinessCore.Common;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using log4net;
using static RPGLibBusinessCore.Context.EnumerationsTools;

namespace RPGLibBusinessCore.Context.Infra.SQLImpl
{
    public class ItemTypeBaseImplementation : IItemTypeData
    {
        private readonly IConfiguration _configuration;
        private readonly ILog _logger;
        public ItemTypeBaseImplementation(IConfiguration configuration, ILog logger)
        {
            this._configuration = configuration;
            this._logger = logger;
        }

       
        public async Task<CommonResult> AddAsync(ItemTypeBase entity)
        {

            this._logger.Debug($"ItemTypeBaseImplementation.AddAsync {entity.ToString()}");

            var sql = "INSERT INTO ITEM_TYPE(Id,Name) VALUES (@Id,@Name)";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql, entity);
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemTypeBaseImplementation.AddAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }


  
        public async Task<CommonResult> DeleteAsync(ItemTypeBase entity)
        {
            this._logger.Debug($"ItemTypeBaseImplementation.DeleteAsync {entity.ToString()}");

            var sql = "DELETE FROM ITEM_TYPE WHERE Id=@Id";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql, entity);
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemTypeBaseImplementation.DeleteAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<IReadOnlyList<ItemTypeBase>> GetAllAsync()
        {
            this._logger.Debug($"ItemTypeBaseImplementation.GetAllAsync");

            var sql = "SELECT Id,Name FROM ITEM_TYPE WITH(NOLOCK)";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.QueryAsync<ItemTypeBase>(sql);
                    return resultSQL.AsList<ItemTypeBase>();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemTypeBaseImplementation.GetAllAsync", ex);
                throw ex;
            }
        }

        
        public async Task<ItemTypeBase> GetByIdAsync(Guid id)
        {
            this._logger.Debug($"ItemTypeBaseImplementation.GetByIdAsync with Id: {id}");

            var sql = "SELECT Id, Name FROM ITEM_TYPE WITH(NOLOCK) WHERE Id=@Id";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.QuerySingleOrDefaultAsync<ItemTypeBase>(sql, new { Id = id });
                    return resultSQL;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemTypeBaseImplementation.GetByIdAsync", ex);
                throw ex;
            }
        }


        public async Task<CommonResult> UpdateAsync(ItemTypeBase entity)
        {

            this._logger.Debug($"ItemTypeBaseImplementation.UpdateAsync {entity.ToString()}");

            var sql = "UPDATE ITEM_TYPE SET Name=@Name WHERE Id=@Id";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql, entity);                    
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemTypeBaseImplementation.UpdateAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }
    }
}
