using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DL.Registrations
{
    public class categories
    {

        public DataTable List(string keywords)
        {
            return Helper.executeQuery("select * from categories_view where c like '%" + keywords + "%'");
        }

        public EL.Registrations.categories Select(EL.Registrations.categories categoryEL)
        {
            var dt = Helper.executeQuery("select * from categories where categoryid = '" + categoryEL.Categoryid + "'");

            if (dt.Rows.Count > 0)
            {
                categoryEL.Categoryid = Convert.ToInt32(dt.Rows[0]["categoryid"].ToString());
                categoryEL.Category = dt.Rows[0]["category"].ToString();
                return categoryEL;
            }
            else
            {
                return null;
            }
            
        }

        public long Insert(EL.Registrations.categories categoryEL)
        {
            return Helper.executeNonQueryLong("insert into categories values ('" + categoryEL.Category + "')");
        }

        public bool Update(EL.Registrations.categories categoryEL)
        {
            return Helper.executeNonQueryBool("update categories set category = '" + categoryEL.Category + "' where categoryid = '" + categoryEL.Categoryid + "'");
        }

        public bool Delete(EL.Registrations.categories categoryEL)
        {
            return Helper.executeNonQueryBool("delete from categories where categoryid = '" + categoryEL.Categoryid + "'");
        }

    }
}
