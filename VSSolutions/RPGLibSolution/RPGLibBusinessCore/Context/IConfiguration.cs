using System;
using System.Collections.Generic;
using System.Text;

namespace RPGLibBusinessCore.Context
{
    public interface IConfiguration
    {
        public string GetConnectionString(string connecionName);
    }
}
