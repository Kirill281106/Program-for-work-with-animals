using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class Grafts : Form
    {
        private Main main;
        private List<Cow> CowsFromListBox;
        private List<Pig> PigsFromListBox;
        private List<Сhicken> ChickenFromListBox;
        private AnimalFile animalFile = new AnimalFile();
        private WorkWithCows workWithCows = new WorkWithCows();
        private WorkWithPigs workWithPigs = new WorkWithPigs();
        private WorkWithChickens workWithChickens = new WorkWithChickens();
        private int selectedAnimalNumber = -1;
        private string selectedAnimalType = "";
        
        public Grafts(Main main)
        {
            InitializeComponent();
            this.main = main;
            ShowOnListBox();
        }
        public void Grafts_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
            this.Close();
        }
        private string FormatDate(DateTime date)
        {
            if (date == DateTime.MinValue || date.Year < 2000)
                return "Не установлена";
            return date.ToString("dd.MM.yyyy");
        }

        public void ShowOnListBox()
        {
            listBox1.Items.Clear();
            
            PigsFromListBox = animalFile.ListPigsFromFile();
            if (PigsFromListBox != null)
            {
                foreach (Pig pig in PigsFromListBox)
                {
                    string lastGraftStr = FormatDate(pig.LastGraft);
                    string nextGraftStr = FormatDate(pig.NextGraft);
                    string info = $"№{pig.Number} - {pig.View} | Последняя прививка: {lastGraftStr} | Следующая прививка: {nextGraftStr}";
                    listBox1.Items.Add(info);
                }
            }
            
            CowsFromListBox = animalFile.ListCowFromFile();
            if (CowsFromListBox != null)
            {
                foreach (Cow cow in CowsFromListBox)
                {
                    string lastGraftStr = FormatDate(cow.LastGraft);
                    string nextGraftStr = FormatDate(cow.NextGraft);
                    string info = $"№{cow.Number} - {cow.View} | Последняя прививка: {lastGraftStr} | Следующая прививка: {nextGraftStr}";
                    listBox1.Items.Add(info);
                }
            }
            
            ChickenFromListBox = animalFile.ListСhickensFromFile();
            if (ChickenFromListBox != null)
            {
                foreach (Сhicken chicken in ChickenFromListBox)
                {
                    string lastGraftStr = FormatDate(chicken.LastGraft);
                    string nextGraftStr = FormatDate(chicken.NextGraft);
                    string info = $"№{chicken.Number} - {chicken.View} | Последняя прививка: {lastGraftStr} | Следующая прививка: {nextGraftStr}";
                    listBox1.Items.Add(info);
                }
            }
        }

        private void ESC_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedAnimalNumber == -1)
            {
                MessageBox.Show("Пожалуйста, выберите животное из списка", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, введите дату предстоящей прививки", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DateTime nextGraftDate = DateTime.Parse(textBox1.Text);
                DateTime currentDate = DateTime.Now;

                if (selectedAnimalType == "свиньи")
                {
                    Pig pig = workWithPigs.GetPigByNumber(selectedAnimalNumber);
                    if (pig != null)
                    {
                        workWithPigs.DeletePig(selectedAnimalNumber);
                        pig.LastGraft = currentDate;
                        pig.NextGraft = nextGraftDate;
                        workWithPigs.CreateNewPig(pig);
                        MessageBox.Show("Прививка успешно обновлена!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (selectedAnimalType == "коровы")
                {
                    Cow cow = workWithCows.GetCowByNumber(selectedAnimalNumber);
                    if (cow != null)
                    {
                        workWithCows.DeleteCow(selectedAnimalNumber);
                        cow.LastGraft = currentDate;
                        cow.NextGraft = nextGraftDate;
                        workWithCows.CreateNewCow(cow);
                        MessageBox.Show("Прививка успешно обновлена!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (selectedAnimalType == "куры")
                {
                    Сhicken chicken = workWithChickens.GetChickenByNumber(selectedAnimalNumber);
                    if (chicken != null)
                    {
                        workWithChickens.DeleteСhicken(selectedAnimalNumber);
                        chicken.LastGraft = currentDate;
                        chicken.NextGraft = nextGraftDate;
                        workWithChickens.CreateNewСhicken(chicken);
                        MessageBox.Show("Прививка успешно обновлена!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                textBox1.Text = "";
                selectedAnimalNumber = -1;
                selectedAnimalType = "";
                ShowOnListBox();
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат даты. Используйте формат дд.мм.гггг", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении прививки: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;

            string selectedItem = listBox1.SelectedItem.ToString();
            
            // Номер - вид | Последняя прививка | Следующая прививка
            string[] parts = selectedItem.Split('|');
            if (parts.Length < 1)
                return;

            string firstPart = parts[0].Trim();
            string[] numberParts = firstPart.Split('-');
            if (numberParts.Length < 2)
                return;

            string numberStr = numberParts[0].Replace("№", "").Trim();
            
            try
            {
                selectedAnimalNumber = int.Parse(numberStr);
                
                // Определяем тип животного по спискам
                selectedAnimalType = "";
                
                if (PigsFromListBox != null)
                {
                    foreach (Pig pig in PigsFromListBox)
                    {
                        if (pig.Number == selectedAnimalNumber)
                        {
                            selectedAnimalType = "свиньи";
                            break;
                        }
                    }
                }
                
                if (selectedAnimalType == "" && CowsFromListBox != null)
                {
                    foreach (Cow cow in CowsFromListBox)
                    {
                        if (cow.Number == selectedAnimalNumber)
                        {
                            selectedAnimalType = "коровы";
                            break;
                        }
                    }
                }
                
                if (selectedAnimalType == "" && ChickenFromListBox != null)
                {
                    foreach (Сhicken chicken in ChickenFromListBox)
                    {
                        if (chicken.Number == selectedAnimalNumber)
                        {
                            selectedAnimalType = "куры";
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе животного: {ex.Message}", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
