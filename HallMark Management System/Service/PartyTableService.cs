using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HallMark_Management_System.Service
{
    public class PartyTableService
    {

        public List<PartyModel> findByJewllerName(string jewller_name)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<PartyModel>("select * from Party_table where jewller_name='"+jewller_name+"';", new DynamicParameters());
                return queryResult.ToList();
            }
        }
        public List<PartyModel> findAllData()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<PartyModel>("select * from Party_table", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public List<PartyModel> findById(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var queryResult = cnn.Query<PartyModel>("select * from Party_table where ID=" + id + ";", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
