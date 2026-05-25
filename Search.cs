using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class Search : Form
    {
        private Main main;
        private AnimalFile animalFile = new AnimalFile();
        
        public Search(Main main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void SearchBT_Click(object sender, EventArgs e)
        {
            SearchMethod();
        }

        private void SearchMethod()
        {
            listBox1.Items.Clear();
            
            string numberText = textBox1.Text.Trim();
            string viewText = textBox2.Text.Trim();
            string dateText = textBox3.Text.Trim();
            
            if (string.IsNullOrEmpty(numberText) && string.IsNullOrEmpty(viewText) && string.IsNullOrEmpty(dateText))
            {
                MessageBox.Show("Пожалуйста, введите хотя бы один критерий поиска", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            bool hasNumber = false;
            int searchNumber = 0;
            
            if (!string.IsNullOrEmpty(numberText))
            {
                if (ParseNumber(numberText, out searchNumber))
                {
                    hasNumber = true;
                }
                else
                {
                    return;
                }
            }

            bool hasDate = false;
            DateTime searchDate = DateTime.MinValue;
            if (!string.IsNullOrEmpty(dateText))
            {
                if (ParseDate(dateText, out searchDate))
                {
                    hasDate = true;
                }
                else
                {
                    return;
                }
            }
            
            List<Animal> foundAnimals = new List<Animal>();
            
            List<Cow> cows = animalFile.ListCowFromFile();
            if (cows != null)
            {
                foreach (Cow cow in cows)
                {
                    bool IsSearch = true;
                    
                    if (hasNumber)
                    {
                        if (cow.Number != searchNumber)
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && !string.IsNullOrEmpty(viewText))
                    {
                        if (!cow.View.ToLower().Contains(viewText.ToLower()))
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && hasDate)
                    {
                        if (cow.NextGraft.Year < 2000 || cow.NextGraft == DateTime.MinValue)
                        {
                            IsSearch = false;
                        }
                        else
                        {
                            if (cow.NextGraft.Date != searchDate.Date)
                            {
                                IsSearch = false;
                            }
                        }
                    }
                    
                    if (IsSearch)
                    {
                        foundAnimals.Add(cow);
                    }
                }
            }
            
            List<Pig> pigs = animalFile.ListPigsFromFile();
            if (pigs != null)
            {
                foreach (Pig pig in pigs)
                {
                    bool IsSearch = true;
                    
                    if (hasNumber)
                    {
                        if (pig.Number != searchNumber)
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && !string.IsNullOrEmpty(viewText))
                    {
                        if (!pig.View.ToLower().Contains(viewText.ToLower()))
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && hasDate)
                    {
                        if (pig.NextGraft.Year < 2000 || pig.NextGraft == DateTime.MinValue)
                        {
                            IsSearch = false;
                        }
                        else
                        {
                            if (pig.NextGraft.Date != searchDate.Date)
                            {
                                IsSearch = false;
                            }
                        }
                    }
                    
                    if (IsSearch)
                    {
                        foundAnimals.Add(pig);
                    }
                }
            }
            
            List<Сhicken> chickens = animalFile.ListСhickensFromFile();
            if (chickens != null)
            {
                foreach (Сhicken chicken in chickens)
                {
                    bool IsSearch = true;
                    
                    if (hasNumber)
                    {
                        if (chicken.Number != searchNumber)
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && !string.IsNullOrEmpty(viewText))
                    {
                        if (!chicken.View.ToLower().Contains(viewText.ToLower()))
                        {
                            IsSearch = false;
                        }
                    }
                    
                    if (IsSearch && hasDate)
                    {
                        if (chicken.NextGraft.Year < 2000 || chicken.NextGraft == DateTime.MinValue)
                        {
                            IsSearch = false;
                        }
                        else
                        {
                            if (chicken.NextGraft.Date != searchDate.Date)
                            {
                                IsSearch = false;
                            }
                        }
                    }
                    
                    if (IsSearch)
                    {
                        foundAnimals.Add(chicken);
                    }
                }
            }
            
            if (foundAnimals.Count == 0)
            {
                MessageBox.Show("Животные по заданным критериям не найдены", "Результат поиска", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                foreach (Animal animal in foundAnimals)
                {
                    string lastGraftStr = "Не установлена";
                    if (animal.LastGraft.Year >= 2000 && animal.LastGraft != DateTime.MinValue)
                    {
                        lastGraftStr = animal.LastGraft.ToString("dd.MM.yyyy");
                    }
                    
                    string nextGraftStr = "Не установлена";
                    if (animal.NextGraft.Year >= 2000 && animal.NextGraft != DateTime.MinValue)
                    {
                        nextGraftStr = animal.NextGraft.ToString("dd.MM.yyyy");
                    }
                    
                    string fullInfo = "";
                    if (animal is Cow cow)
                    {
                        fullInfo = $"КОРОВА - № особи {cow.Number}; Вид {cow.View}; Вес: {cow.Weight}кг; Корм: {cow.Feed}кг/день; Процент мяса на продажу {cow.CoefficientOfMeat*100}% или {cow.MeatYield} кг; Удой с 1 особи {cow.MilkYield} л в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                    }
                    else if (animal is Pig pig)
                    {
                        fullInfo = $"СВИНЬЯ - № особи {pig.Number}; Вид {pig.View}; Вес: {pig.Weight}кг; Корм: {pig.Feed}кг/день; Процент мяса на продажу {pig.CoefficientOfMeat*100}% или {pig.MeatYield} кг; Помёт с 1 особи {pig.Litter} кг в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                    }
                    else if (animal is Сhicken chicken)
                    {
                        fullInfo = $"КУРИЦА - № особи {chicken.Number}; Вид {chicken.View}; Вес: {chicken.Weight}кг; Корм: {chicken.Feed}кг/день; Процент мяса на продажу {chicken.CoefficientOfMeat*100}% или {chicken.MeatYield} кг; Яйца с 1 особи {chicken.EagsYield} в неделю(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                    }
                    
                    listBox1.Items.Add(fullInfo);
                }
            }
        }

        private bool ParseNumber(string numberText, out int number)
        {
            number = 0;
            try
            {
                number = int.Parse(numberText);
                return true;
            }
            catch
            {
                MessageBox.Show("Неверный формат номера животного", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ParseDate(string dateText, out DateTime date)
        {
            date = DateTime.MinValue;
            try
            {
                date = DateTime.Parse(dateText);
                return true;
            }
            catch
            {
                MessageBox.Show("Неверный формат даты. Используйте формат дд.мм.гггг", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
