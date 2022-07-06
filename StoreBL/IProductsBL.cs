using StoreModel;

namespace StoreBL
{
    public interface IProductsBL{
        Products SearchProductByName(string p_pName);
        public List<Products> GetAllProducts(int p_pID);
        void ReplenishProductQuantity(int p_pID, int p_Quantity);
        void ReplenishProductsQuantity(int pID, int uID, int quantity);
    }
}