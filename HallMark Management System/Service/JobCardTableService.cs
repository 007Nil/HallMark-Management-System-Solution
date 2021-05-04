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
    public class JobCardTableService
    {
        private ConnectToDatabaseService connectToDatabaseService = new ConnectToDatabaseService();

        public void insertData(JobCardModel jobCradModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {
                cnn.Execute("insert into JobCardTable (jobCardNo,jewellerID) values (@jobCardNo, @jewellerID)", jobCradModel);
            }
        }

        public List<JobCardModel> findLatestData()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {
                var queryResult= cnn.Query<JobCardModel>("SELECT * FROM JobCardTable ORDER BY id DESC LIMIT 1;");
                return queryResult.ToList();
            }
        }

    }
}
