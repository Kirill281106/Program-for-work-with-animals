using System;

namespace ООП_курсач_новый
{
    internal class User
    {
        private string _login;
        private string _password;
        private string _role;
        public string Login 
        { get => _login;
            set => _login=value; }
        public string Password
        { get => _password;
            set => _password = value; }
        public string Role 
        { get => _role;
            set => _role = value; }
    }
}
