namespace Facebook
{
    public class User
    {
        private string login;
        private string pass;

        public User(string login, string pass)
        {
            this.Login = login;
            this.pass = pass;
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }
    }
}