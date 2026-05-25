using System;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class Create : Form
    {
        WorkWithUsers workWithUsers = new WorkWithUsers();
        private string answerCreate = "";
        public Create()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NewLogin.Text) || string.IsNullOrEmpty(NewPassword.Text))
            {
                MessageBox.Show("Возможно вы не заполнили все поля пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                answerCreate = workWithUsers.FormCreateUsers(NewLogin.Text, NewPassword.Text);
                try
                {
                    if (answerCreate == "Пользователь существует")
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if(answerCreate == "Пароль занят")
                    {
                        MessageBox.Show("Пароль занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Main main = new Main("user");
                        main.Show();
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка создания нового пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Вход f1 = new Вход();
            f1.Show();
            this.Close();
        }
    }
}
