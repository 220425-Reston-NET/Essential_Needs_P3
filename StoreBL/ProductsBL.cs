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

        public List<Products> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public void ReplenishProductQuantity(int p_pID, int p_Quantity)
        {
            Products medTable = new Products();
            medTable.pID = p_pID;
            medTable.Quantity = p_Quantity;

            _prRepo.Update(medTable);
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

