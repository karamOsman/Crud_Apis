namespace hireAPI.Models
{
    public class ProductCategory
    {
   
        public int Id { get; set; }
        public string Arabic_Name { get; set; }
        public string English_Name { get; set; }

        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Status { get; set; }
        public int Creation_user_id { get; set; }
        public DateTime Creation_date { get; set; } = DateTime.Now;

        public string Update_User { get; set; }
        public DateTime Update_Date { get; set; }

        public string Category { get; set; }


        public IEnumerable<Products>? CategoryProducts { get; set; }

        public ProductCategory(int id, string arabic_Name, string english_Name, DateTime start_Date, DateTime end_Date, string status, int creation_user_id, DateTime creation_date, string update_User, DateTime update_Date,string category)
        {
            Id = id;
            Arabic_Name = arabic_Name;
            English_Name = english_Name;
            Start_Date = start_Date;
            End_Date = end_Date;
            Status = status;
            Creation_user_id = creation_user_id;
            Creation_date = creation_date;
            Update_User = update_User;
            Update_Date = update_Date;
            Category = category;
            //CategoryProducts = categoryProducts;
        }


    }
}
