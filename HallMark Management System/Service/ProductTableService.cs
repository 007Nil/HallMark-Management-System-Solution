using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Service
{
    class ProductTableService
    {
        private ConnectToDatabaseService connectToDatabaseService = new ConnectToDatabaseService();

        public List<ProductModel> findAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<ProductModel>(" SELECT * FROM Product_table;", new DynamicParameters());
                return queryResult.ToList();
            }
        }
    }
}
