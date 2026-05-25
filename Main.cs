using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    public partial class Main : Form
    {
        private List<Animal> MainAnimalsList = new List<Animal>();
        
        public Main(string role1)
        {
            InitializeComponent();
            this.FormClosed += Main_Closed;
            if (role1 == "admin")
                ShowAdminElemets();
            else
                ShowUserElements();
        }
        private void ShowUserElements()
        {
            животныеToolStripMenuItem.Visible = true;
            прививкиToolStripMenuItem.Visible = true;
            поискToolStripMenuItem.Visible = true;
        }
        private void ShowAdminElemets()
        {
            ShowUserElements();
            пользователиToolStripMenuItem.Visible = true;
            учётЖивотныхToolStripMenuItem.Visible= true;
        }
        private void Main_Closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUsers editUsers = new EditUsers();
            editUsers.Show();
            this.Hide();
        }

        private void коровыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnimalsConstruction animals = new AnimalsConstruction(this,"коровы");
            animals.Show();
        }

        private void свиньиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AnimalsConstruction animals = new AnimalsConstruction(this, "свиньи");
            animals.Show();
        }

        private void курыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnimalsConstruction animals = new AnimalsConstruction(this, "куры");
            this.Hide();
            animals.Show();
        }

        private void прививкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Grafts grafts = new Grafts(this);
            grafts.Show();
            this.Hide();
        }

        private void животныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AnimalFile animalFile = new AnimalFile();
            listBox1.Items.Clear();
            MainAnimalsList.Clear();
            
            // полная инфа про коров
            List<Cow> cows = animalFile.ListCowFromFile();
            foreach (Cow cow in cows)
            {
                string lastGraftStr = "";
                if (cow.LastGraft.Year >= 2000 && cow.LastGraft != DateTime.MinValue)
                {
                    lastGraftStr = cow.LastGraft.ToString("dd.MM.yyyy");
                }
                
                string nextGraftStr = "";
                if (cow.NextGraft.Year >= 2000 && cow.NextGraft != DateTime.MinValue)
                {
                    nextGraftStr = cow.NextGraft.ToString("dd.MM.yyyy");
                }
                
                string fullInfo = $"№ особи {cow.Number}; Вид {cow.View}; Вес: {cow.Weight}кг; Корм: {cow.Feed}кг/день; Процент мяса на продажу {cow.CoefficientOfMeat*100}% или {cow.MeatYield} кг; Удой с 1 особи {cow.MilkYield} л в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                listBox1.Items.Add(fullInfo);
                MainAnimalsList.Add(cow);
            }
            
            // для свиней
            List<Pig> pigs = animalFile.ListPigsFromFile();
            foreach (Pig pig in pigs)
            {
                string lastGraftStr = "";
                if (pig.LastGraft.Year >= 2000 && pig.LastGraft != DateTime.MinValue)
                {
                    lastGraftStr = pig.LastGraft.ToString("dd.MM.yyyy");
                }
                
                string nextGraftStr = "";
                if (pig.NextGraft.Year >= 2000 && pig.NextGraft != DateTime.MinValue)
                {
                    nextGraftStr = pig.NextGraft.ToString("dd.MM.yyyy");
                }
                
                string fullInfo = $"№ особи {pig.Number}; Вид {pig.View}; Вес: {pig.Weight}кг; Корм: {pig.Feed}кг/день; Процент мяса на продажу {pig.CoefficientOfMeat*100}% или {pig.MeatYield} кг; Помёт с 1 особи {pig.Litter} кг в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                listBox1.Items.Add(fullInfo);
                MainAnimalsList.Add(pig);
            }
            
            // кур
            List<Сhicken> chickens = animalFile.ListСhickensFromFile();
            foreach (Сhicken chicken in chickens)
            {
                string lastGraftStr = "";
                if (chicken.LastGraft.Year >= 2000 && chicken.LastGraft != DateTime.MinValue)
                {
                    lastGraftStr = chicken.LastGraft.ToString("dd.MM.yyyy");
                }
                
                string nextGraftStr = "";
                if (chicken.NextGraft.Year >= 2000 && chicken.NextGraft != DateTime.MinValue)
                {
                    nextGraftStr = chicken.NextGraft.ToString("dd.MM.yyyy");
                }
                
                string fullInfo = $"№ особи {chicken.Number}; Вид {chicken.View}; Вес: {chicken.Weight}кг; Корм: {chicken.Feed}кг/день; Процент мяса на продажу {chicken.CoefficientOfMeat*100}% или {chicken.MeatYield} кг; Яйца с 1 особи {chicken.EagsYield} в неделю(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                listBox1.Items.Add(fullInfo);
                MainAnimalsList.Add(chicken);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите тип сортировки", "Внимание", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedSort = comboBox1.SelectedItem.ToString();
            
            if (selectedSort != "По номеру" && selectedSort != "По названию(алфавиту)" && selectedSort != "По предстоящей прививки")
            {
                MessageBox.Show("Неизвестный тип сортировки", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            List<Animal> allAnimals = new List<Animal>();
            foreach (Animal animal in MainAnimalsList)
            {
                allAnimals.Add(animal);
            }

            SortBySelectSort(allAnimals, selectedSort);
            UpdateListBox(allAnimals);
        }

        private void SortBySelectSort(List<Animal> animals, string sortType)
        {
            IComparer<Animal> comparer = null;
            
            if (sortType == "По номеру")
            {
                comparer = new SortByNumber();
            }
            else if (sortType == "По названию(алфавиту)")
            {
                comparer = new SortByView();
            }
            else if (sortType == "По предстоящей прививки")
            {
                comparer = new SortByNextGraft();
            }
            
            if (comparer != null)
            {
                SortWithComparer(animals, comparer);
            }
        }

        private void SortWithComparer(List<Animal> animals, IComparer<Animal> comparer)
        {
            for (int i = 0; i < animals.Count - 1; i++)
            {
                for (int j = 0; j < animals.Count - i - 1; j++)
                {
                    if (comparer.Compare(animals[j], animals[j + 1]) > 0)
                    {
                        Animal temp = animals[j];
                        animals[j] = animals[j + 1];
                        animals[j + 1] = temp;
                    }
                }
            }
        }

        private void UpdateListBox(List<Animal> animals)
        {
            listBox1.Items.Clear();
            foreach (Animal animal in animals)
            {
                string lastGraftStr = "";
                if (animal.LastGraft.Year >= 2000 && animal.LastGraft != DateTime.MinValue)
                {
                    lastGraftStr = animal.LastGraft.ToString("dd.MM.yyyy");
                }
                
                string nextGraftStr = "";
                if (animal.NextGraft.Year >= 2000 && animal.NextGraft != DateTime.MinValue)
                {
                    nextGraftStr = animal.NextGraft.ToString("dd.MM.yyyy");
                }
                
                string fullInfo = "";
                if (animal is Cow cow)
                {
                    fullInfo = $"№ особи {cow.Number}; Вид {cow.View}; Вес: {cow.Weight}кг; Корм: {cow.Feed}кг/день; Процент мяса на продажу {cow.CoefficientOfMeat*100}% или {cow.MeatYield} кг; Удой с 1 особи {cow.MilkYield} л в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                }
                else if (animal is Pig pig)
                {
                    fullInfo = $"№ особи {pig.Number}; Вид {pig.View}; Вес: {pig.Weight}кг; Корм: {pig.Feed}кг/день; Процент мяса на продажу {pig.CoefficientOfMeat*100}% или {pig.MeatYield} кг; Помёт с 1 особи {pig.Litter} кг в сутки(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                }
                else if (animal is Сhicken chicken)
                {
                    fullInfo = $"№ особи {chicken.Number}; Вид {chicken.View}; Вес: {chicken.Weight}кг; Корм: {chicken.Feed}кг/день; Процент мяса на продажу {chicken.CoefficientOfMeat*100}% или {chicken.MeatYield} кг; Яйца с 1 особи {chicken.EagsYield} в неделю(среднее); Последняя прививка: {lastGraftStr}; Следующая прививка: {nextGraftStr}";
                }
                
                listBox1.Items.Add(fullInfo);
            }
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search(this);
            searchForm.Show();
            this.Hide();
        }
    }
}
