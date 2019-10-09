using System;
using System.Collections.Generic;
using System.Text;

namespace pos.DL.Registrations
{
    public class Categories
    {

        public Boolean Insert(pos.EL.Registrations.Categories category)
        {

            return Helper.executeNonQuery("insert into categories (categoryname) values ('" + category.Categoryname + "')");
        }

        public Boolean Update(pos.EL.Registrations.Categories category)
        {
            return Helper.executeNonQuery("update categories set categoryname = '" + category.Categoryname + "' where categoryid = '" + category.Categoryid + "' ");
        }

        public Boolean Delete(pos.EL.Registrations.Categories category)
        {
            return Helper.executeNonQuery("delete from categories where categoryid = '" + category.Categoryid + "'");
        }


        public System.Data.DataTable List(pos.EL.Registrations.Categories category)
        {
            String sQuery = "Select * from categories";
          
            return Helper.executeQuery(sQuery);
        }
        public pos.EL.Registrations.Categories Select(pos.EL.Registrations.Categories category)
        {

            String sQuery = "Select * from categories ";
            if (category.Categoryid > 0)
            {
                sQuery = sQuery + "and categoryid =" + category.Categoryid;
            }

            System.Data.DataTable dt = Helper.executeQuery(sQuery);
            if (dt.Rows.Count >= 1)
            {
                category.Categoryid = Convert.ToInt32(dt.Rows[0]["categoryid"].ToString());
                category.Categoryname = dt.Rows[0]["categoryname"].ToString();
                
            }
            return null;
        }
    }
}
