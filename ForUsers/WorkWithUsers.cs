using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class WorkWithUsers : UserFile
    {
        private string _fileName = "Users.json";
        private List<User> _users = new List<User>();
        public List<User> Users => _users;
        public WorkWithUsers()
        {
            InitializeFile();
        }
        public void InitializeFile()
        {
            try
            {
                _users = LoadUsersFromFile();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string LoginToAccount(string login, string password)
        {
            User userRole = null;
            foreach (User user in _users)
            {
                if (user.Login == login && user.Password == password)
                {
                    userRole = user;
                    break;
                }
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) { return null; }
            else if (userRole != null) return userRole.Role;
            else return "Пользователь отсутствует";
        }

        public string FormCreateUsers(string login, string password)
        {
            foreach (User user in _users)
            {
                if (user.Login == login)
                {
                    return "Пользователь существует";
                }
            }
            foreach (User user in _users)
            {
                if (user.Password == password)
                {
                    return "Пароль занят";
                }
            }
            User newUser = new User
            {
                Login = login,
                Password = password,
                Role = "user"
            };
            _users.Add(newUser);
            string jsonString = JsonSerializer.Serialize(_users);
            File.WriteAllText(_fileName, jsonString);
            return "Создан";
        }

        public string CreateUser(string login,string password,string role)
        {
            if (string.IsNullOrEmpty(login)||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(role))
            {
                return "Не все поля заполнены";
            }
            foreach (User user in _users)
            {
                if (user.Login == login)
                {
                    return "Пользователь существует";
                }
            }
            foreach (User user in _users)
            {
                if (user.Password == password)
                {
                    return "Пароль занят";
                }
            }
                User newUser = new User
                {
                    Login = login,
                    Password = password,
                    Role = role
                };
                _users.Add(newUser);
                string jsonString = JsonSerializer.Serialize(_users);
                File.WriteAllText(_fileName, jsonString);
                return "Создан";
        }

        public string DeleteUser(string login)
        {
            try
            {
                User userToDelete = null;
                foreach (User user in _users)
                {
                    if (user.Login == login)
                    {
                        userToDelete = user;
                        break;
                    }
                }
                if (userToDelete == null)
                {
                    return "Пользователь не найден";
                }
                if (userToDelete.Role == "admin")
                {
                    int adminCount = 0;
                    foreach (User user in _users)
                    {
                        if (user.Role == "admin")
                        {
                            adminCount++;
                        }
                    }
                    if (adminCount <= 1)
                    {
                        return "Нельзя удалить последнего администратора";
                    }
                }
                _users.Remove(userToDelete);

                string jsonString = JsonSerializer.Serialize(_users);
                File.WriteAllText(_fileName, jsonString);

                return "Удалён";
            }
            catch (Exception ex)
            {
                return $"Ошибка удаления: {ex.Message}";
            }
        }

        public string EditUser(string oldLogin, string login,string password,string role)
        {
            User userToEdit = null;
            foreach (User user in _users)
            {
                if (user.Login == oldLogin)
                {
                    userToEdit = user;
                    break;
                }
            }
            if (oldLogin != login)
            {
                foreach (User u in _users)
                {
                    if (u.Login == login)
                    {
                        return "Пользователь существует";
                    }
                }
            }
            else
            {
                foreach (User user in _users)
                {
                    if (user.Password == password && user.Login != oldLogin)
                    {
                        return "Пароль занят";
                    }
                }
            }
            userToEdit.Login = login;
            userToEdit.Password = password;
            userToEdit.Role = role;

            string jsonString = JsonSerializer.Serialize(_users);
            File.WriteAllText(_fileName, jsonString);

            return "Успех";
        }
    }
}
