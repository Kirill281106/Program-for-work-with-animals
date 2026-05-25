using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class EditUsers : Form
    {
        WorkWithUsers workWithUsers = new WorkWithUsers();
        private bool isAddingUser = false;
        List<User> users = new List<User>();
        private bool isEditingMode = false;
        public EditUsers()
        {
            InitializeComponent();
            ShowUsersOnList();
            this.FormClosed += new FormClosedEventHandler(EditUsersClosed);
        }
        private void EditUsersClosed(object sender, FormClosedEventArgs e)
        {
            // Ищем главную форму и показываем её
            foreach (Form form in Application.OpenForms)
            {
                if (form is Main)
                {
                    form.Show();
                    break;
                }
            }
        }
        public void ShowUsersOnList()
        {
            try
            {
                listBox1.Items.Clear();
                users = workWithUsers.Users;
                foreach (User user in users)
                {
                    string list = $"{user.Login}({user.Role})";
                    listBox1.Items.Add(list);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ESC_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ShowElements();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                ShowElements();
                isEditingMode = true;
                string selectedItem = listBox1.SelectedItem.ToString();
                string login = selectedItem.Split('(')[0].Trim();
                User user = null;
                foreach (User u in users)
                {
                    if (u.Login == login)
                    {
                        user = u;
                        break;
                    }
                }
                if (user != null)
                {
                    textBox1.Text = user.Login;
                    textBox2.Text = user.Password;
                    comboBox1.Text = user.Role;
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку(нажмите на неё)","Внимание", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string login = selectedItem.Split('(')[0].Trim();
                DialogResult result = MessageBox.Show(
                     $"Вы уверены, что хотите удалить пользователя {login}?",
                      "Подтверждение удаления",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string answer = workWithUsers.DeleteUser(login);
                    if (answer == "Нельзя удалить последнего администратора")
                    {
                        MessageBox.Show("Нельзя удалить единственного администратора", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (answer == "Пользователь не найден")
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else if (answer == "Удалён")
                    {
                        MessageBox.Show("Успех!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowUsersOnList();
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку(нажмите на неё)", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string answer;
                if (isEditingMode)// это для изменение
                {
                    string selectedItem = listBox1.SelectedItem.ToString();
                    string oldLogin = selectedItem.Split('(')[0].Trim();
                    if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text)|| string.IsNullOrEmpty(comboBox1.Text))
                    {
                        MessageBox.Show("Ошибка! Возможно вы не заполнили все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        answer = workWithUsers.EditUser(oldLogin, textBox1.Text, textBox2.Text, comboBox1.Text);
                        if (answer == "Успех")
                        {
                            MessageBox.Show("Пользователь успешно обновлён", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            HideElements();
                            listBox1.Items.Clear();
                            ShowUsersOnList();
                            isEditingMode = false;
                        }
                        else if (answer == "Пароль занят")
                        {
                            MessageBox.Show("Пароль занят!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (answer == "Пользователь существует")
                        {
                            MessageBox.Show("Логин занят!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (answer== "Пользователь не найден")
                        {
                            MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else// а это для добавления
                {
                    answer = workWithUsers.CreateUser(textBox1.Text, textBox2.Text, comboBox1.Text);
                    if (answer == "Пользователь существует")
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (answer == "Создан")
                    {
                        isAddingUser = true;
                        MessageBox.Show($"Создан новый пользователь!{textBox1.Text}", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (isAddingUser)
                        {
                            HideElements();
                            listBox1.Items.Clear();
                            ShowUsersOnList();
                        }
                    }
                    else if (answer == "Пароль занят")
                    {
                        MessageBox.Show("Пароль занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (answer == "Не все поля заполнены")
                    {
                        MessageBox.Show("Ошибка! Возможно вы не заполнили все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowElements()
        {
            GroupUserBox.Visible = true;
            isAddingUser = true;

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
        }
        private void HideElements()
        {
            GroupUserBox.Visible = false;
            isAddingUser = false;
        }
    }
}
