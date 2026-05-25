using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class UserFile : User
    {
        private string _fileName = "Users.json";
        public List<User> LoadUsersFromFile()
        {
                List<User> users = new List<User>();
                try
                {
                    if (!File.Exists(_fileName))
                    {
                        User defaultUser = new User
                        {
                            Login = "user",
                            Password = "user",
                            Role = "user"
                        };
                        User adminUser = new User
                        {
                            Login = "admin",
                            Password = "admin",
                            Role = "admin"
                        };
                        users.Add(defaultUser);
                        users.Add(adminUser);

                        // Сохраняем в файл
                        string jsonString = JsonSerializer.Serialize(users);
                        File.WriteAllText(_fileName, jsonString);
                    }
                    else
                    {
                        // Загружаем из файла
                        string jsonString = File.ReadAllText(_fileName);
                        List < User > user = JsonSerializer.Deserialize<List<User>>(jsonString);
                        if (user != null)
                        {
                            users = user;
                        }
                        else
                        {
                            users = new List<User>();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return users;
        }
    }
}
