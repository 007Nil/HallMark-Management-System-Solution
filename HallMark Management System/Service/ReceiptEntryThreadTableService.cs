using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace HallMark_Management_System.Service
{
    class ReceiptEntryThreadTableService
    {
        private ConnectToDatabaseService connectToDatabaseService = new ConnectToDatabaseService();

        public Boolean SaveAllData(List<ReceiptEntryThreadModel> receiptEntryThreadModels) 
        {
            try
            {
                foreach(ReceiptEntryThreadModel eachModel in receiptEntryThreadModels)
                {
                    using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
                    {
                        cnn.Execute("insert into ReceiptEntryThread_table (jewllery_id,total_pcs,gross_wt," +
                            "net_wt, msphc_wt, receipt_entry_master_id, remark) values" +
                            " (@jewllery_id, @total_pcs, @gross_wt, @net_wt, @msphc_wt," +
                            "@receipt_entry_master_id, @remark)", eachModel);
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public List<int> findAllByMasterId(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<int>(" SELECT id FROM ReceiptEntryThread_table WHERE receipt_entry_master_id=@id AND is_valid=1;", new {id = ID});
                return queryResult.ToList();
            }
        }

        public List<ReceiptEntryThreadModel> findAll(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<ReceiptEntryThreadModel>(" SELECT * FROM ReceiptEntryThread_table WHERE receipt_entry_master_id=@id AND is_valid=1;", new { id = ID });
                return queryResult.ToList();
            }
        }

        public Boolean updateThreadData(List<ReceiptEntryThreadModel> receiptEntryThreadModels)
        {
            try
            {
                foreach (ReceiptEntryThreadModel eachThread in receiptEntryThreadModels)
                {
                    using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
                    {
                        cnn.Execute("UPDATE ReceiptEntryThread_table SET jewllery_id=@jewllery_id," +
                            "total_pcs=@total_pcs,gross_wt=@gross_wt,net_wt=@net_wt," +
                            "msphc_wt=@msphc_wt,remark=@remark,receipt_entry_master_id=@receipt_entry_master_id  WHERE id=@Id;", eachThread);
                    } 
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void DisableData(List<int> allIDs)
        {

            foreach(int eachID in allIDs)
            {
                using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
                {
                    cnn.Execute("UPDATE ReceiptEntryThread_table SET is_valid=0 WHERE id=@Id;", new { id=eachID });
                }
            }
        }


    }
}
