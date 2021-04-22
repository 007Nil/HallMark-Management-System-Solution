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
    class FundTransferTableService
    {

        
        public List<FundEntryModel> findOneEntryWithAllParams(FundEntryModel fundEntryModel)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                Console.WriteLine("select * from Fund_Transfer_table where " +
                    "transaction_type=" + fundEntryModel.transaction_type + " and type=" + fundEntryModel.type +
                    " and jeweller_id=" + fundEntryModel.jeweller_id + " and net_amount=" + fundEntryModel.net_amount +
                    " and cheque_no='" + fundEntryModel.cheque_no + "' and cheque_date='" + fundEntryModel.cheque_date +
                    "' and bank_id=" + fundEntryModel.bank_id + " and bill_no='" + fundEntryModel.bill_no + "'" +
                    " and bill_date='" + fundEntryModel.bill_date + "' and remarks='" + fundEntryModel.remarks + "';");

                var queryResult = cnn.Query<FundEntryModel>("select * from Fund_Transfer_table where " +
                    "transaction_type="+fundEntryModel.transaction_type+ " and type="+fundEntryModel.type+
                    " and jeweller_id="+fundEntryModel.jeweller_id+ " and net_amount="+fundEntryModel.net_amount+
                    " and cheque_no='"+fundEntryModel.cheque_no+ "' and cheque_date='"+fundEntryModel.cheque_date+
                    "' and bank_id="+fundEntryModel.bank_id+ " and bill_no='"+fundEntryModel.bill_no+"'"+
                    " and bill_date='"+fundEntryModel.bill_date+ "' and remarks='"+fundEntryModel.remarks+"';", new DynamicParameters());
                return queryResult.ToList();
            }
        }

        private static String LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
