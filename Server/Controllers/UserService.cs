namespace webapi
{
    public class UserService
    {
        public User GetUser()
        {
            return new User { Firstname = "zzi", Lastname = "zhang" };
        }
    }
}
