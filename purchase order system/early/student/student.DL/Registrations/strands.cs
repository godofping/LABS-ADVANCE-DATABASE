using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace student.DL.Registrations
{
    public class strands
    {
        public DataTable List(string keyword)
        {
            return Helper.executeQuery("select * from strands_view where `C` like '%" + keyword + "%'");
        }

        public EL.Registrations.strands Select(EL.Registrations.strands strandEL)
        {
            var dt = Helper.executeQuery("select * from strands_view where `STRAND ID` = '" + strandEL.Strandid + "'");
            if (dt.Rows.Count > 0)
            {
                strandEL.Strandid = Convert.ToInt32(dt.Rows[0]["STRAND ID"].ToString());
                strandEL.Strand = dt.Rows[0]["STRAND"].ToString();
                strandEL.Stranddescription = dt.Rows[0]["DESCRIPTION"].ToString();
                return strandEL;
            }
            else
            {
                return null;
            }
        }

        public long Insert(EL.Registrations.strands strandEL)
        {
            return Helper.executeNonQueryLong("insert into strands (strand, stranddescription) values ('" + strandEL.Strand + "', '" + strandEL.Stranddescription + "')");
        }

        public bool Update(EL.Registrations.strands strandEL)
        {
            return Helper.executeNonQueryBool("update strands set strand = '" + strandEL.Strand + "', stranddescription = '" + strandEL.Stranddescription + "' where strandid = '" + strandEL.Strandid + "'");
        }

        public bool Delete(EL.Registrations.strands strandEL)
        {
            return Helper.executeNonQueryBool("delete from strands where strandid = '" + strandEL.Strandid + "'");
        }
    }
}
