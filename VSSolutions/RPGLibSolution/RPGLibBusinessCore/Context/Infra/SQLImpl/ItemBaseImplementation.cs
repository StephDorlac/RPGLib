using RPGLibBusinessCore.Common;
using RPGLibEntityCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<CommonResult> AddAsync(ItemBase entity)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResult> DeleteAsync(ItemBase entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ItemBase>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemBase> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResult> UpdateAsync(ItemBase entity)
        {
            throw new NotImplementedException();
        }
    }
}
