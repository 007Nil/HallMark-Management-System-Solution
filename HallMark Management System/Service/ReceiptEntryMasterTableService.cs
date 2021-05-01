using Dapper;
using HallMark_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace HallMark_Management_System.Service
{
    class ReceiptEntryMasterTableService
    {

        private ConnectToDatabaseService connectToDatabaseService = new ConnectToDatabaseService();

        public Boolean SaveAllData(ReceiptEntryMasterModel receiptEntryMasterModel)
        {
            try
            {
                    using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
                    {
                        cnn.Execute("insert into ReceiptEntryMaster_table (jeweller_id,receipt_date,issue_voucher_no," +
                            "delivery_by, delivery_date, box_no, previous_box_no, customer_name, ILC_receipt ) values" +
                            " (@jeweller_id, @receipt_date, @issue_voucher_no, @delivery_by, @delivery_date," +
                            "@box_no, @previous_box_no, @customer_name, @ILC_receipt)", receiptEntryMasterModel);
                    }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        public List<String> findAllIdReverse()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<String>(" SELECT id FROM ReceiptEntryMaster_table ORDER BY ROWID DESC;", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public List<ReceiptEntryMasterModel> findByID(int ID)
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<ReceiptEntryMasterModel>(" SELECT * FROM ReceiptEntryMaster_table where Id="+ID+ " AND is_valid=1;", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        public List<ReceiptEntryMasterModel> findAll()
        {
            using (IDbConnection cnn = new SQLiteConnection(connectToDatabaseService.LoadConnectionString()))
            {

                var queryResult = cnn.Query<ReceiptEntryMasterModel>(" SELECT * FROM ReceiptEntryMaster_table where is_valid=1;", new DynamicParameters());
                return queryResult.ToList();
            }
        }
    }
}
