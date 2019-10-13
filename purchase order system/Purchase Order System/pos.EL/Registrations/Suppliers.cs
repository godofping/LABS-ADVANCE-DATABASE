namespace pos.EL.Registrations
{
    public class Suppliers
    {
        int supplierid;
        string supplier;
        int contactdetailid;
        int isdeleted;
      

        public int Supplierid { get => supplierid; set => supplierid = value; }
        public string Supplier { get => supplier; set => supplier = value; }
        public int Contactdetailid { get => contactdetailid; set => contactdetailid = value; }
        public int Isdeleted { get => isdeleted; set => isdeleted = value; }
    }
}
