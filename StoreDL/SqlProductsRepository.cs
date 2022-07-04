using Microsoft.Data.SqlClient;
using StoreModel;

namespace StoreBL
{
    public class SqlProductsRepository : IRepository<Products>
    {
        // =============Dependancy injection================
        private readonly string _connectionString;

        public SqlProductsRepository(string p_connectionString)
        {
            this._connectionString = p_connectionString;
        }
        // ================================================
        public void Add(Products p_resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(Products p_resource)
        {
            String SQLQuery = @"DELETE FROM Medicine WHERE pID = @pID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                command.Parameters.AddWithValue("@pID", p_resource.pID);


                command.ExecuteNonQuery();
            }
        }

        public List<Products> GetAll()
        {
            String SQLQuery = @"select * from Products";
            List<Products> listofProducts = new List<Products>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLQuery, con);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listofProducts.Add(new Products()
                    {
                        pID = reader.GetInt32(0),
                        pName = reader.GetString(1),
                        pPrice1oz = reader.GetInt32(2),
                        pPrice4oz = reader.GetInt32(3),
                        Quantity = reader.GetInt32(4)
                    });
                }
                return listofProducts;
            }
        }

        public void Update(Products p_resource)
        {
            string SQLquery = @"update Product
                                set Quantity = @Quantity, uID = @uID
                                where pID = @pID ";
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();

                SqlCommand command = new SqlCommand(SQLquery, con);

                command.Parameters.AddWithValue("@pID", p_resource.pID);
                command.Parameters.AddWithValue("@Quantity", p_resource.Quantity);
                command.Parameters.AddWithValue("@pID", p_resource.uID);
                command.ExecuteNonQuery();
            }
        }
    }
}