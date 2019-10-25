using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace pos.DL.Registrations
{
    public class Supplies
    {
        public DataTable List(string keywords)
        {
            return Helper.executeQuery("select * from supplies_view where `Supply Name` like '%" + keywords + "%' or `Supply Unit` like '%" + keywords + "%' or `Supply Unit Price` like '%" + keywords + "%' or `Supply Stocks` like '%" + keywords + "%' ");
        }

        public DataTable List(int id)
        {
            return Helper.executeQuery("select * from supplies_view where `Supply ID` = " + id + "");
        }

        public long Insert(EL.Registrations.Supplies supply)
        {
            return Helper.executeNonQueryLong("insert into supplies (supplyname, supplyunit, supplyunitprice, supplystocks) values ('" + supply.Supplyname + "', '" + supply.Supplyunit + "', '" + supply.Supplyunitprice + "', '" + supply.Supplystocks + "')");
        }

        public bool Edit(EL.Registrations.Supplies supply)
        {
            return Helper.executeNonQueryBool("update supplies set supplyname = '" + supply.Supplyname + "', supplyunit = '" + supply.Supplyunit + "', supplyunitprice =  '" + supply.Supplyunitprice + "'  where supplyid = " + supply.Supplyid + "");
        }

        public bool Delete(EL.Registrations.Supplies supply)
        {
            return Helper.executeNonQueryBool("delete from supplies where supplyid = " + supply.Supplyid + "");
        }

    }
}
