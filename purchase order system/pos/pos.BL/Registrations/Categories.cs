using System.Data;

namespace pos.BL.Registrations
{
    public class Categories
    {
        public bool Insert(pos.EL.Registrations.Categories category)
        {
            pos.DL.Registrations.Categories categoryDL = new pos.DL.Registrations.Categories();

            if (categoryDL.Insert(category))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Update(pos.EL.Registrations.Categories category)
        {

            pos.DL.Registrations.Categories categoryDL = new pos.DL.Registrations.Categories();

            if (categoryDL.Update(category))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool Delete(pos.EL.Registrations.Categories category)
        {

            pos.DL.Registrations.Categories categoryDL = new pos.DL.Registrations.Categories();

            if (categoryDL.Delete(category))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable List(pos.EL.Registrations.Categories category)
        {
            pos.DL.Registrations.Categories categoryDL = new pos.DL.Registrations.Categories();
            return categoryDL.List(category);
        }
        public pos.EL.Registrations.Categories Select(pos.EL.Registrations.Categories category)
        {
            pos.DL.Registrations.Categories categoryDL = new pos.DL.Registrations.Categories();
            return categoryDL.Select(category);
        }
    }
}
