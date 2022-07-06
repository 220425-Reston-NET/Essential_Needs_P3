using StoreModel;

namespace StoreBL
{
    public class UserBL : IUserBL
    {
        private readonly IRepository<User> _userRepo;
        public UserBL(IRepository<User> p_userRepo)
        {
            _userRepo = p_userRepo;
        }
        public void AddUser(User u_use)
        {
            User foundedcustomer = SearchUserByName(u_use.Name);

            if (foundedcustomer == null)
            {
                _userRepo.Add(u_use);
            }
            else
            {
                throw new Exception("An accout with this Email address already exists");
            }
        }

        public List<User> GetAllUser()
        {
            List<User> currentListOfUser = _userRepo.GetAll();
            return currentListOfUser;
        }

        public User SearchUserByEmailAndPassword(string Email, string Password)
        {
            return _userRepo.GetAll().First(user => user.Email == Email && user.Password == Password);
        }

        public User SearchUserByName(string p_userName)
        {
            return _userRepo.GetAll().First(user => user.Name == p_userName);
        }

        public void UpdateUser(User u_use)
        {
                _userRepo.Update(u_use);
        }
    }
}