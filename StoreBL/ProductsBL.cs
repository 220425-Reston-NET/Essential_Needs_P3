using StoreModel;

namespace StoreBL
{
    public class ProductsBL : IProductsBL
    {
        // ================================================
        private readonly IRepository<Products> _prRepo;
        public ProductsBL(IRepository<Products> p_prRepo)
        {
            _prRepo = p_prRepo;
        }
        // ================================================

        public List<Products> GetAllProducts(int p_pID)
        {
            return _prRepo.GetAll();
        }

        

        public void ReplenishProductQuantity(int p_pID, int p_Quantity)
        {
            Products productsTable = new Products();
            productsTable.pID = p_pID;
            productsTable.Quantity = p_Quantity;

            _prRepo.Update(productsTable);
        }

        public void ReplenishProductsQuantity(int pID, int uID, int quantity)
        {
            throw new NotImplementedException();
        }

        public Products SearchProductByName(string p_pName)
        {
            return _prRepo.GetAll().First(Products => Products.pName == p_pName);
        }
    }
}

