using Microsoft.Data.SqlClient;
using StoreBL;
using StoreModel;

namespace StoreDL
{
    public class SqlStoreRepository : IRepository<Store>
    {
        // =============Dependancy injection================
        private readonly string _connectionString;
        // ================================================
        public SqlStoreRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }

        public void Add(Store p_resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(Store p_resource)
        {
            throw new NotImplementedException();
        }

        public List<Store> GetAll()
        {
            String SQLQuery = @"select * from Store";
            List<Store> listofUser = new List<Store>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofUser.Add(new Store()
                    {
                        sID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Products = GiveProductsToStore(reader.GetInt32(0))
                    });
                }
                return listofUser;
            }
        }
        private List<Products> GiveProductsToStore(int uID)
        {
            string SQLquery = @"select * from Store s
                                inner join Products p on p.sID = s.sID
                                where s.sID = @uID";

            List<Products> ListOfProducts = new List<Products>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@uID", uID);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ListOfProducts.Add(new Products()
                    {
                        pID = reader.GetInt32(5),
                        pName = reader.GetString(6),
                        pPrice1oz = reader.GetInt32(7),
                        pPrice4oz =reader.GetInt32(8),
                        Quantity = reader.GetInt32(9)
                    });

                }
            }
            return ListOfProducts;
        }

        public void Update(Store p_resource)
        {
            throw new NotImplementedException();
        }
       
    }
}