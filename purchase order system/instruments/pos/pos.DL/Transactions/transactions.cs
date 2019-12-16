using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DL.Transactions
{
    public class transactions
    {
        public DataTable List(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select * from transactions_view where `C` like '%" + keywords + "%'");
        }

        public EL.Transactions.transactions Select(EL.Transactions.transactions transactionEL)
        {
            var dt = Helper.executeQuery("select * from transactions where transactionid = '" + transactionEL.Transactionid + "'");

            if (dt.Rows.Count > 0)
            {
                transactionEL.Transactionid = Convert.ToInt32(dt.Rows[0]["transactionid"].ToString());
                transactionEL.Customerid = Convert.ToInt32(dt.Rows[0]["customerid"].ToString());
                transactionEL.Transactiondatetime = dt.Rows[0]["transactiondatetime"].ToString();
                transactionEL.Totalamount = Convert.ToSingle(dt.Rows[0]["totalamount"].ToString());
                transactionEL.Amounttendered = Convert.ToSingle(dt.Rows[0]["amounttendered"].ToString());
                transactionEL.ChangeAmount = Convert.ToSingle(dt.Rows[0]["changeamount"].ToString());
                transactionEL.Isvoid = Convert.ToInt32(dt.Rows[0]["isvoid"]);

                return transactionEL;
            }
            else
            {
                return null;
            }

        }

        public long Insert(EL.Transactions.transactions transactionEL)
        {
            return Helper.executeNonQueryLong("insert into transactions (customerid, transactiondatetime, totalamount, amounttendered, changeamount, isvoid) values ('" + transactionEL.Customerid + "', '" + transactionEL.Transactiondatetime + "', '" + transactionEL.Totalamount + "', '" + transactionEL.Amounttendered + "', '" + transactionEL.ChangeAmount + "', '" + transactionEL.Isvoid + "')");
        }

        public bool Update(EL.Transactions.transactions transactionEL)
        {
            return Helper.executeNonQueryBool("update transactions set customerid = '" + transactionEL.Customerid + "', transactiondatetime = '" + transactionEL.Transactiondatetime + "', totalamount = '" + transactionEL.Totalamount + "', amounttendered = '" + transactionEL.Amounttendered + "', changeamount = '" + transactionEL.ChangeAmount + "', isvoid = '" + transactionEL.Isvoid + "' where transactionid = '" + transactionEL.Transactionid + "'");
        }

        public bool Delete(EL.Transactions.transactions transactionEL)
        {
            return Helper.executeNonQueryBool("delete from transactions where transactionid = '" + transactionEL.Transactionid + "'");
        }

        public DataTable TodaySales(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select COALESCE(sum(`TOTAL AMOUNT`), 0) AS `SALES` from transactions_view where `TRANSACTION DATE AND TIME` like '%" + keywords + "%' and `IS VOID` = 0");
        }

        public DataTable DailySales(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select * from transactions_view where `TRANSACTION DATE AND TIME` like '%" + keywords + "%' and `IS VOID` = 0");
        }
    }
}
