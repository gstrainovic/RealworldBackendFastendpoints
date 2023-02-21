public class UserResponse
{
    public User user { get; set; }
    public class User
    {
        public string email { get; set; }
        public string token { get; set; }
        public string username { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
    }
}
