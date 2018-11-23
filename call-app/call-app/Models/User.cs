namespace call_app.Models
{
    public class User
    {
        public string Userid { get; set; }

        public User() { }

        public override string ToString()
        {
            return string.Format("User(userid={0})", Userid);
        }
    }
}
