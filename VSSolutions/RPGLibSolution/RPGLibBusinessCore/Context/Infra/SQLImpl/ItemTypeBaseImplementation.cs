using RPGLibBusinessCore.Common;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;

namespace RPGLibBusinessCore.Context.Infra.SQLImpl
{
    public class ItemTypeBaseImplementation : IItemTypeData
    {
        private readonly IConfiguration _configuration;
        public ItemTypeBaseImplementation(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// AddAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>        
        public async Task<CommonResult> AddAsync(ItemTypeBase entity)
        {            

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
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }


        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<CommonResult> DeleteAsync(ItemTypeBase entity)
        {
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
                result.Message = ex.ToString();
                result.ResultStatus = CommonResult.ResultStatusAction.Failure;
            }

            return result;
        }

        public async Task<IReadOnlyList<ItemTypeBase>> GetAllAsync()
        {
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
                //tODO LOG
                throw ex;
            }
        }

        /// <summary>
        /// GetByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ItemTypeBase> GetByIdAsync(Guid id)
        {
            var sql = "SELECT Id, Name FROM ITEM_TYPE WITH(NOLOCK) WHERE Id=@Id";           

            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var resultSQL = await connection.QuerySingleOrDefaultAsync<ItemTypeBase>(sql, new {Id=id });
                    return resultSQL;
                }                
            }
            catch (Exception ex)
            {
                //tODO LOG
                throw ex;
            }            
        }

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<CommonResult> UpdateAsync(ItemTypeBase entity)
        {
            var sql = "UPDATE ITEM_TYPE (Name) VALUES (@Name) WHERE Id=@Id";
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
    }
}
