using System;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class Вход : Form
    {
        private string _role1 = "user";
        WorkWithUsers workWithUsers = new WorkWithUsers();
        public Вход()
        {
            InitializeComponent();
            workWithUsers.InitializeFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _role1 = workWithUsers.LoginToAccount(LoginTB.Text, PasswordTB.Text);
            if (_role1 == "Пользователь отсутствует")
            {
                MessageBox.Show("Пользователь с введёнными данными отсутвует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (_role1 == null)
            {
                MessageBox.Show("Возможно вы не заполнили все поля ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Main main = new Main(_role1);
                main.Show();
                this.Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Create create = new Create();
            create.Show();
            this.Hide();
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если закрывается главная форма логина - завершаем приложение
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
            else
            {
                bool hasMainForm = false;
                foreach (Form form in Application.OpenForms)
                {
                    if (form is Main)
                    {
                        hasMainForm = true;
                        break;
                    }
                }
                if (!hasMainForm)
                {
                    Application.Exit();
                }
            }
        }
    }
}
