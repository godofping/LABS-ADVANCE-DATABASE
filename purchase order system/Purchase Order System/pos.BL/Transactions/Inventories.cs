using System.Data;
namespace pos.BL.Transactions
{
    public class Inventories
    {
        DL.Transactions.Inventories InventoryDL = new DL.Transactions.Inventories();
        public DataTable List(string keywords)
        {
            return InventoryDL.List(keywords);
        }

        public DataTable List(int id)
        {
            return InventoryDL.List(id);
        }

        public long Insert(EL.Transactions.Inventories inventory)
        {
            return InventoryDL.Insert(inventory);
        }

        public bool Update(EL.Transactions.Inventories inventory)
        {
            return InventoryDL.Update(inventory);
        }

    }
}
