using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DL.Transactions
{
    public class productsintransactions
    {
        public DataTable List(string keywords)
        {
            keywords = MySql.Data.MySqlClient.MySqlHelper.EscapeString(keywords);
            return Helper.executeQuery("select `PRODUCT NAME`, `QUANTITY`, `PRICE` from productsintransactions_view where `TRANSACTION ID` = '" + keywords + "'");
        }

        public EL.Transactions.productsintransactions Select(EL.Transactions.productsintransactions productsintransactionEL)
        {
            var dt = Helper.executeQuery("select * from productsintransactions where productintransactionid = '" + productsintransactionEL.Productintransactionid + "'");

            if (dt.Rows.Count > 0)
            {
                productsintransactionEL.Productintransactionid = Convert.ToInt32(dt.Rows[0]["productintransactionid"].ToString());
                productsintransactionEL.Transactionid = Convert.ToInt32(dt.Rows[0]["transactionid"].ToString());
                productsintransactionEL.Productid = Convert.ToInt32(dt.Rows[0]["productid"].ToString());
                productsintransactionEL.Soldprice = Convert.ToSingle(dt.Rows[0]["soldprice"].ToString());
                productsintransactionEL.Quantity = Convert.ToInt32(dt.Rows[0]["quantity"].ToString());
                productsintransactionEL.Amount = Convert.ToSingle(dt.Rows[0]["amount"].ToString());

                return productsintransactionEL;
            }
            else
            {
                return null;
            }

        }

        public long Insert(EL.Transactions.productsintransactions productsintransactionEL)
        {
            Console.WriteLine("insert into productsintransactions (transactionid, productid, soldprice, quantity, amount) values ('" + productsintransactionEL.Transactionid + "', '" + productsintransactionEL.Productid + "', '" + productsintransactionEL.Soldprice + "', '" + productsintransactionEL.Quantity + "', '" + productsintransactionEL.Amount + "')");
            return Helper.executeNonQueryLong("insert into productsintransactions (transactionid, productid, soldprice, quantity, amount) values ('" + productsintransactionEL.Transactionid + "', '" + productsintransactionEL.Productid + "', '" + productsintransactionEL.Soldprice + "', '" + productsintransactionEL.Quantity + "', '" + productsintransactionEL.Amount + "')");
        }

        public bool Update(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return Helper.executeNonQueryBool("update productsintransactions set transactionid = '" + productsintransactionEL.Transactionid + "', productid = '" + productsintransactionEL.Productid + "', soldprice = '" + productsintransactionEL.Soldprice + "', quantity = '" + productsintransactionEL.Quantity + "', amount = '" + productsintransactionEL.Amount + "' where productintransactionid = '" + productsintransactionEL.Productintransactionid + "'");
        }

        public bool Delete(EL.Transactions.productsintransactions productsintransactionEL)
        {
            return Helper.executeNonQueryBool("delete from productsintransactions where productintransactionid = '" + productsintransactionEL.Productintransactionid + "'");
        }
    }
}
