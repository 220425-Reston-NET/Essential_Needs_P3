using StoreModel;

namespace StoreBL
{
    public class StoreBL : IStoreBL
    {
        private readonly IRepository<Store> _storeRepo;
        public StoreBL(IRepository<Store> p_storeRepo)
        {
            _storeRepo = p_storeRepo;
        }

        public List<Products> GetAllProducts(int p_pID)
        {
            throw new NotImplementedException();
        }

        public void UpdateStore(Store p_sID)
        {
            _storeRepo.Update(p_sID);
        }

       
    }
}