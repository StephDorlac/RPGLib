using RPGLibBusinessCore.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestRPGLibIntegrationSQL
{
    public class SQLConfiguration : IConfiguration
    {
        public string GetConnectionString(string connectionName)
        {
            return "Server=PC-STEPH\\SQLEXPRESS;Database=RPGLibData;User Id=sa;Password=dev2020*;";
        }
    }
}
