using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;


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


    }
}
