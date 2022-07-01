using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace StoreModel;

public class Products
{
    public string Store { get; set; }
    public int pPrice1oz { get; set; }
    public int pPrice4oz { get; set; }
    private int _pID;
    public int pID
    {
        get{ return _pID; }
        set
        {
            if (value > 0)
            {
                _pID = value;
            }
            else
            {
                throw new ValidationException("pID needs to be above 0.");
            }
        }
    }

    private string ? _pName;
    public string ? pName
    {
        get{ return _pName; }
        set
        {
            if (Regex.IsMatch(value, @"^[a-zA-Z ]+$"))
            {
                _pName = value;
            }
            else
            {
                throw new ValidationException("Can only have letters");
            }
        }
    }

    private int _quantity;
    public int Quantity
    {
        get{ return _quantity; }
        set
        {
            if (value > 0)
            {
                _quantity = value;
            }
            else
            {
                throw new ValidationException("Quantity needs to be above 0.");

            }
        }
    }

    public Products()
    {
        Store = "";
        pName = "";
        pPrice1oz = 0;
        pPrice4oz = 0;

    }

    public int uID{ get; set; }
    public override string ToString()
    {
        return $"===Products info===\nStore: {Store}\npName: {pName}\npPrice1oz: {pPrice1oz}\npPrice4oz: {pPrice4oz}\nQuantity: {Quantity}\n=======";
    }

}