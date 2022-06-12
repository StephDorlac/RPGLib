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
    public class ItemBaseImplementation : ItemBaseData
    {

        private readonly IConfiguration _configuration;
        private readonly ILog _logger;

        public ItemBaseImplementation(IConfiguration configuration, ILog logger)
        {
            this._configuration = configuration;
            this._logger = logger;
        }

        public async Task<CommonResult> AddAsync(ItemBase entity)
        {
            this._logger.Debug($"ItemBaseImplementation.AddAsync {entity.ToString()}");

            var sql = "INSERT INTO ITEM_BASE(Id,Name,ItemTypeId,Weigth) VALUES (@Id,@Name,@ItemTypeId,@Weigth)";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql,new { Id=entity.Id, Name=entity.Name, Weigth=entity.Weigth, ItemTypeId=entity.ItemTypeId});                    
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemBaseImplementation.AddAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<CommonResult> DeleteAsync(ItemBase entity)
        {
            this._logger.Debug($"ItemBaseImplementation.DeleteAsync {entity.ToString()}");

            var sql = "DELETE FROM ITEM_BASE WHERE Id=@Id";
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
                this._logger.Error("ERROR ItemBaseImplementation.DeleteAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<IReadOnlyList<ItemBase>> GetAllAsync()
        {
            this._logger.Debug($"ItemBaseImplementation.GetAllAsync");

            var sql = "SELECT Id,Name,ItemTypeId,Weigth FROM ITEM_BASE WITH(NOLOCK)";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.QueryAsync<ItemBase>(sql);
                    return resultSQL.AsList<ItemBase>();
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemBaseImplementation.GetAllAsync", ex);
                throw ex;
            }
        }

        public async Task<ItemBase> GetByIdAsync(Guid id)
        {
            this._logger.Debug($"ItemBaseImplementation.GetByIdAsync with Id: {id}");

            var sql = "SELECT Id,Name,ItemTypeId,Weigth FROM ITEM_BASE WITH(NOLOCK) WHERE Id=@id";

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.QuerySingleOrDefaultAsync<ItemBase>(sql, new { Id = id });
                   
                    return resultSQL;
                }
            }
            catch (Exception ex)
            {
                this._logger.Error("ERROR ItemBaseImplementation.GetByIdAsync", ex);
                throw ex;
            }
        }

        public async Task<CommonResult> UpdateAsync(ItemBase entity)
        {
            this._logger.Debug($"ItemBaseImplementation.UpdateAsync {entity.ToString()}");

            var sql = "UPDATE ITEM_BASE SET Name=@Name, ItemTypeId=@ItemTypeId, Weigth=@Weigth WHERE Id=@Id";
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
                this._logger.Error("ERROR ItemBaseImplementation.UpdateAsync", ex);
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }
    }
}
