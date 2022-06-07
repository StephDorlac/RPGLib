using RPGLibBusinessCore.Common;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Context.Infra.SQLImpl
{
    public class ItemBaseImplementation : ItemBaseData
    {

        private readonly IConfiguration _configuration;

        public ItemBaseImplementation(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<CommonResult> AddAsync(ItemBase entity)
        {
            var sql = "INSERT INTO ITEM_BASE(Id,Name,ItemTypeId,Weigth) VALUES (@Id,@Name,@ItemTypeId,@Weigth)";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql,new { Id=entity.Id, Name=entity.Name, Weigth=entity.Weigth, ItemTypeId=entity.Type.Id});                    
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<CommonResult> DeleteAsync(ItemBase entity)
        {
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
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<IReadOnlyList<ItemBase>> GetAllAsync()
        {
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
                //tODO LOG
                throw ex;
            }
        }

        public async Task<ItemBase> GetByIdAsync(Guid id)
        {
            var sql = "Id,Name,ItemTypeId,Weigth FROM ITEM_BASEE WITH(NOLOCK) WHERE Id=@Id";

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
                //tODO LOG
                throw ex;
            }
        }

        public async Task<CommonResult> UpdateAsync(ItemBase entity)
        {
            var sql = "UPDATE ITEM_BASE (Name,ItemTypeId,Weigth) VALUES (@Name,@ItemTypeId,@Weigth WHERE Id=@Id";
            var result = new CommonResult() { Message = String.Empty, ResultStatus = CommonResult.ResultStatusAction.Pending };

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.ExecuteAsync(sql, new { Name=entity.Name,ItemTypeId=entity.Type.Id,Wigth=entity.Weigth,Id=entity.Id});
                }
                result.ResultStatus = CommonResult.ResultStatusAction.Success;
            }
            catch (Exception ex)
            {
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }
    }
}
