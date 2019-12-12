using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.EL.Registrations
{
    public class products
    {
        int productid;
        int categoryid;
        string productname;
        string description;
        float price;
        int stocks;

        public int Productid
        {
            get
            {
                return productid;
            }

            set
            {
                productid = value;
            }
        }

        public int Categoryid
        {
            get
            {
                return categoryid;
            }

            set
            {
                categoryid = value;
            }
        }

        public string Productname
        {
            get
            {
                return productname;
            }

            set
            {
                productname = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Stocks
        {
            get
            {
                return stocks;
            }

            set
            {
                stocks = value;
            }
        }
    }
}
