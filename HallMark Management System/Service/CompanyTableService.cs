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
    class CompanyTableService
    {

        private ConnectToDatabaseService connectToDatabaseService = new ConnectToDatabaseService();

        public List<CompanyModel> findAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<CompanyModel>(" SELECT * FROM Company_table WHERE ID=1;", new DynamicParameters());
                return queryResult.ToList();
            }
        }
    }
}
