using System;
using System.Data;
namespace pos.DL.Transactions
{
    public class Inventories
    {

        public DataTable List(string keywords)
        {
            string sQuery = "select * from inventories_view where `Product SKU` like '%" + keywords + "%' or `Product Name` like '%" + keywords + "%' or `Product Description` like '%" + keywords + "%' or `Product Price` like '%" + keywords + "%' or `Category Name` like '%" + keywords + "%' or `Sub Category Name` like '%" + keywords + "%'  or `Quantity In Stocks` like '%" + keywords + "%' or `Reorder Level` like '%" + keywords + "%'";
            return Helper.executeQuery(sQuery);
        }

        public DataTable List(int id)
        {
            string sQuery = "select * from inventories_view where subcategoryid = " + id + "";
            return Helper.executeQuery(sQuery);
        }

        public long Insert(EL.Transactions.Inventories inventoryEL)
        {
            return Helper.executeNonQueryLong("insert into inventories (productid, quantityinstocks, reorderlevel, inventorylastupdated) values ('" + inventoryEL.Productid + "', '" + inventoryEL.Quantityinstocks + "', '" + inventoryEL.Reorderlevel + "', '" + DateTime.Today.ToString("yyyy-MM-dd") + "' )");
        }

        public bool Update(EL.Transactions.Inventories inventoryEL)
        {
            return Helper.executeNonQueryBool("update inventories set reorderlevel = '" + inventoryEL.Reorderlevel + "', inventorylastupdated = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'  where inventoryid = '" + inventoryEL.Inventoryid + "'");
        }

    }
}
