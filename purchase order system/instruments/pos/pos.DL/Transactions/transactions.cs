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
                transactionEL.Transactiondatetime = dt.Rows[0]["transactiondateandtime"].ToString();
                transactionEL.Totalamount = Convert.ToSingle(dt.Rows[0]["totalamount"].ToString());
                transactionEL.Amounttendered = Convert.ToSingle(dt.Rows[0]["amounttendered"].ToString());
                transactionEL.Change = Convert.ToSingle(dt.Rows[0]["change"].ToString());
                transactionEL.Isvoid = Convert.ToInt32(dt.Rows[0]["isvoid"].ToString());

                return transactionEL;
            }
            else
            {
                return null;
            }

        }

        public long Insert(EL.Registrations.categories categoryEL)
        {
            categoryEL.Category = MySql.Data.MySqlClient.MySqlHelper.EscapeString(categoryEL.Category);
            return Helper.executeNonQueryLong("insert into categories (category) values ('" + categoryEL.Category + "')");
        }

        public bool Update(EL.Registrations.categories categoryEL)
        {
            categoryEL.Category = MySql.Data.MySqlClient.MySqlHelper.EscapeString(categoryEL.Category);
            return Helper.executeNonQueryBool("update categories set category = '" + categoryEL.Category + "' where categoryid = '" + categoryEL.Categoryid + "'");
        }

        public bool Delete(EL.Registrations.categories categoryEL)
        {
            return Helper.executeNonQueryBool("delete from categories where categoryid = '" + categoryEL.Categoryid + "'");
        }
    }
}
