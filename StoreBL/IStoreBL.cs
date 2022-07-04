using StoreModel;

namespace StoreBL 
{
    public interface IStoreBL{
        void UpdateStore(Store p_sID);
        public List<Products> GetAllProducts(int p_pID);
    }
}