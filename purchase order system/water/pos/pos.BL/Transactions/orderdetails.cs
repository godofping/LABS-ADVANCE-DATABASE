﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pos.BL.Transactions
{
    public class orderdetails
    {
        pos.DL.Transactions.orderdetails orderdetailDL = new pos.DL.Transactions.orderdetails();

        public DataTable List(int id)
        {
            return orderdetailDL.Select(id);
        }

        
        public long Insert(pos.EL.Transactions.orderdetails orderdetailEL)
        {
            return orderdetailDL.Insert(orderdetailEL);
        }
    }
}
