using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreModel;
public class User
{
    private int _uID;
    public int uID
    {
        get{ return _uID; }
        set
        {
            if (value > 0)
            {
                _uID = value;
            }
            else
            {
                throw new ValidationException("uID needs to be above 0.");
            }
        }
    }

    private string _name;
    public string Name
    {
        get{ return _name; }
        set
        {
            if (!Regex.IsMatch(value, @"^[a-z A-Z ]+$ "))
            {
                _name = value;
            }
            else
            {
                throw new ValidationException("Can only have letters");
            }
        }
    }

    public string Address { get; set; }


    public string Email { get; set; }
   
    public string Password { get; set; }
    public List<Products> Products { get; set; }
    public User()
    {
        uID = 1;
        Name = "Israel Ng'Andu";
        Address = "1234 Extra Far";
        Email = "israelng@gmail.com";
        Password = "password123";
        Products = new List<Products>();
    }

    public override string ToString()
    {
        return $"===User info===/nuID: {uID}Name: {Name}/nAddress: {Address}/nEmail: {Email}/nPassword: {Password}/nProducts: {Products}/n===========================";
    }
}
