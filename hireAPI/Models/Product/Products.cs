namespace hireAPI.Models
{
    public class Products
    {

        public int Id { get; set; }

        public string Arabic_Name { get; set; }
        public string English_Name { get; set; }

        public double price { get; set; }
        public string manufacturer { get; set; }
        public int Creation_user_id { get; set; }
        public DateTime Creation_Date { get; set; } = DateTime.Now;

        public string Update_User { get; set; }
        public DateTime Update_Date { get; set; }


        public string Status { get; set; }
        public DateTime AssignDate { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }

        public User? User { get; set; }

        public ProductCategory? Category { get; set; }


        public Products(int id, string arabic_Name, string english_Name, double price, string manufacturer, int creation_user_id, DateTime creation_Date, string update_User, DateTime update_Date, string status, DateTime assignDate, int categoryId, string? description, User? user, ProductCategory? category)
        {
            Id = id;
            Arabic_Name = arabic_Name;
            English_Name = english_Name;
            this.price = price;
            this.manufacturer = manufacturer;
            Creation_user_id = creation_user_id;
            Creation_Date = creation_Date;
            Update_User = update_User;
            Update_Date = update_Date;
            Status = status;
            AssignDate = assignDate;
            CategoryId = categoryId;
            Description = description;
            User = user;
            Category = category;
        }
        public enum StatusList
        {
            Open,
            Close,
            InProgress,
            Done

        }
        public Products()
        {

        }

    }
}

