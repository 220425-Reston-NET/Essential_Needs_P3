using StoreModel;

namespace StoreBL
{
    public interface IUserBL
    {
        void AddUser(User u_use);
        void UpdateUser(User u_use);
        User SearchUserByName(string p_userName);

        User SearchUserByEmailAndPassword(string Email, string Password);
        List<User> GetAllUser();
    }
}