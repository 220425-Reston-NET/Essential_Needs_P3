namespace StoreModel;

public class Store
{
    public int sID { get; set; }
    public string Name { get; set; }
    public List<Products> Products { get; set; }
    public List<User> User { get; set; }
    public Store()
    {
        sID = 0;
        Name = "Default";
        Products = new List<Products>();
        User = new List<User>();
        
    }
}
