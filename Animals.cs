using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ООП_курсач_новый
{
    public partial class AnimalsConstruction : Form
    {
        private Main main;
        private List<Cow> CowsFromListBox;
        private List<Pig> PigsFromListBox;
        private List<Сhicken> ChickenFromListBox;
        private AnimalFile animalFile = new AnimalFile();
        private WorkWithPigs withPigs = new WorkWithPigs();
        private WorkWithCows workWithCows = new WorkWithCows();
        private WorkWithChickens workWithChickens = new WorkWithChickens();
        private int _num; private string _view; private double _weight; private double _feedInOneDay; private DateTime _lastGraft; private DateTime _nextGraft; private double _coeffOfMeat; private double _coeffOfYieldProduction;
        private string _whatWeDoing;
        public string TypeAnimal {  get; set; }
        public AnimalsConstruction(Main main,string typeAnimal)
        {
            InitializeComponent();
            this.main = main;
            TypeAnimal = typeAnimal;
            ShowAnimalsFromListBox(TypeAnimal);
        }
        private void HideElements()
        {
            groupForAnimals.Visible = false;
        }
        private void ESC_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
        private void AnimalsConstruction_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
            this.Close();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            ShowElements(TypeAnimal);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            _whatWeDoing = "изменяем";
            ShowElements(TypeAnimal);
            ReadFromListBoxText();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string num = (selectedItem.Split(';')[0]).Split(' ')[2].Trim();
                DialogResult result = MessageBox.Show(
                     $"Вы уверены, что хотите удалить запись {num}?",
                      "Подтверждение удаления",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                        MessageBox.Show("Успех!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (TypeAnimal == "свиньи")
                    {
                        withPigs.DeletePig(int.Parse(num));
                    }
                    else if (TypeAnimal == "коровы")
                    {
                        workWithCows.DeleteCow(int.Parse(num));
                    }
                    else if (TypeAnimal == "куры")
                    {
                        workWithChickens.DeleteСhicken(int.Parse(num));
                    }
                        ShowAnimalsFromListBox(TypeAnimal);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку(нажмите на неё)");
            }
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            if (!ReadDataFromTextBoxes())
                return;
            
            if (_whatWeDoing == "изменяем")
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string num = (selectedItem.Split(';')[0]).Split(' ')[2].Trim();
                if (TypeAnimal == "свиньи")
                {
                    withPigs.DeletePig(int.Parse(num));
                    withPigs.InitializePigsFile();
                }
                else if (TypeAnimal == "коровы")
                {
                    workWithCows.DeleteCow(int.Parse(num));
                    workWithCows.InitializeCowsFile();
                }
                else if (TypeAnimal == "куры")
                {
                    workWithChickens.DeleteСhicken(int.Parse(num));
                    workWithChickens.InitializeChickensFile();
                }
            }
            
            if (TypeAnimal == "свиньи")
            {
                SavePigData();
            }
            else if (TypeAnimal == "коровы")
            {
                SaveCowData();
            }
            else if (TypeAnimal == "куры")
            {
                SaveChickenData();
            }
        }

        private void ShowElements(string TypeAnimal)
        {
            ClearTB();
            label1.Text = "Введите номер";
            label2.Text = "Введите название вида";
            label3.Text = "Введите вес";
            label5.Text = "Введите дату последней прививки";
            label6.Text = "Введите дату следующей прививки";
            label7.Text = "Введите процент полезного мяса";
            if (TypeAnimal == "свиньи")
            {
                label4.Text = "Введите количесвто пищи в день(кг)";
                label8.Text = "Введите количество навоза в день";
            }
            else if (TypeAnimal == "коровы")
            {
                label4.Text = "Введите количесвто пищи в день(кг)";
                label8.Text = "Введите средний удой в день";
            }
            else if (TypeAnimal == "куры")
            {
                label4.Text = "Введите количесвто пищи в день(гр)";
                label8.Text = "Введите количество яиц в неделю";
            }
            groupForAnimals.Visible = true;
        }
        private bool ReadFromListBoxText()
        {
            try
            {
                if (listBox1.SelectedItem == null)
                    throw new Exception("Выберите строку для изменения нажав по ней") ;
                else
                {
                    string line = listBox1.SelectedItems[0].ToString();
                    string[] parts = line.Split(';');
                    NumberTB.Text = parts[0].Split(' ')[2].Trim();
                    ViewTB.Text = parts[1].Split(' ')[2].Trim();
                    weightTB.Text = parts[2].Split(' ')[2].Replace("кг", "").Trim();
                    CountFeedTB.Text = parts[3].Split(' ')[2].Replace("кг/день", "").Trim();
                    
                    if (TypeAnimal == "свиньи")
                    {
                        Pig pigList = withPigs.GetPigByNumber(int.Parse(NumberTB.Text));
                        if (pigList != null)
                        {
                            LastGraftTB.Text = pigList.LastGraft.ToString("dd.MM.yyyy");
                            NextGraftTB.Text = pigList.NextGraft.ToString("dd.MM.yyyy");
                            double coefficient = pigList.CoefficientOfMeat;
                            CoefficientOfMeatTB.Text = (coefficient * 100).ToString();
                            YieldProductionTB.Text = pigList.Litter.ToString();
                        }
                    }
                    else if (TypeAnimal == "коровы")
                    {
                        Cow CowList = workWithCows.GetCowByNumber(int.Parse(NumberTB.Text));
                        if (CowList != null)
                        {
                            LastGraftTB.Text = CowList.LastGraft.ToString("dd.MM.yyyy");
                            NextGraftTB.Text = CowList.NextGraft.ToString("dd.MM.yyyy");
                            double coefficient = CowList.CoefficientOfMeat;
                            CoefficientOfMeatTB.Text = (coefficient * 100).ToString();
                            YieldProductionTB.Text = CowList.MilkYield.ToString();
                        }
                    }
                    else if (TypeAnimal == "куры")
                    {
                        Сhicken ChickenList = workWithChickens.GetChickenByNumber(int.Parse(NumberTB.Text));
                        if (ChickenList != null)
                        {
                            LastGraftTB.Text = ChickenList.LastGraft.ToString("dd.MM.yyyy");
                            NextGraftTB.Text = ChickenList.NextGraft.ToString("dd.MM.yyyy");
                            double coefficient = ChickenList.CoefficientOfMeat;
                            CoefficientOfMeatTB.Text = (coefficient * 100).ToString();  
                            YieldProductionTB.Text = ChickenList.EagsYield.ToString();
                        }
                    }
                }
                    return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public void ShowAnimalsFromListBox(string TypeAnimal)
        {
            if (TypeAnimal == "свиньи")
            {
                listBox1.Items.Clear();
                PigsFromListBox = animalFile.ListPigsFromFile();
                foreach (Pig pigs in PigsFromListBox)
                {
                    listBox1.Items.Add(pigs);
                }
            }
            else if (TypeAnimal == "коровы")
            {
                listBox1.Items.Clear();
                CowsFromListBox = animalFile.ListCowFromFile();
                foreach (Cow cow in CowsFromListBox)
                {
                    listBox1.Items.Add(cow);
                }
            }
            else if (TypeAnimal == "куры")
            {
                listBox1.Items.Clear();
                ChickenFromListBox = animalFile.ListСhickensFromFile();
                foreach (Сhicken chicken in ChickenFromListBox)
                {
                    listBox1.Items.Add(chicken);
                }
            }
        }
        private void ClearTB()
        {
            NumberTB.Text = "";
            ViewTB.Text = "";
            weightTB.Text = "";
            CountFeedTB.Text = "";
            LastGraftTB.Text = "";
            NextGraftTB.Text = "";
            CoefficientOfMeatTB.Text = "";
            YieldProductionTB.Text = "";
        }
        private void SavePigData()
        {
            try
            {
                Pig newPig = new Pig();
                newPig.Number = _num;
                newPig.View = _view;
                newPig.Weight = _weight;
                newPig.Feed = _feedInOneDay;
                newPig.LastGraft = _lastGraft.Date;
                newPig.NextGraft = _nextGraft.Date;
                newPig.CoefficientOfMeat = _coeffOfMeat;
                newPig.Litter = _coeffOfYieldProduction;

                string result = withPigs.CreateNewPig(newPig);

                if (result == "Успех")
                {
                    string message = _whatWeDoing == "изменяем" 
                        ? "Свинья успешно изменена!" 
                        : "Свинья успешно добавлена!";
                    MessageBox.Show(message, "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTB();
                    HideElements();
                    ShowAnimalsFromListBox(TypeAnimal);
                    _whatWeDoing = "";
                }
                else
                {
                    MessageBox.Show(result, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveCowData()
        {
            try
            {
                Cow newCow = new Cow();
                newCow.Number = _num;
                newCow.View = _view;
                newCow.Weight = _weight;
                newCow.Feed = _feedInOneDay;
                newCow.LastGraft = _lastGraft;
                newCow.NextGraft = _nextGraft;
                newCow.CoefficientOfMeat = _coeffOfMeat;
                newCow.MilkYield = _coeffOfYieldProduction;

                string result = workWithCows.CreateNewCow(newCow);

                if (result == "Успех")
                {
                    string message = _whatWeDoing == "изменяем" 
                        ? "Корова успешно изменена!" 
                        : "Корова успешно добавлена!";
                    MessageBox.Show(message, "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTB();
                    HideElements();
                    ShowAnimalsFromListBox(TypeAnimal);
                    _whatWeDoing = "";
                }
                else
                {
                    MessageBox.Show(result, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveChickenData()
        {
            try
            {
                Сhicken newChicken = new Сhicken();
                newChicken.Number = _num;
                newChicken.View = _view;
                newChicken.Weight = _weight;
                newChicken.Feed = _feedInOneDay;
                newChicken.LastGraft = _lastGraft;
                newChicken.NextGraft = _nextGraft;
                newChicken.CoefficientOfMeat = _coeffOfMeat;
                newChicken.EagsYield = _coeffOfYieldProduction;

                string result = workWithChickens.CreateNewСhicken(newChicken);

                if (result == "Успех")
                {
                    string message = _whatWeDoing == "изменяем" 
                        ? "Курица успешно изменена!" 
                        : "Курица успешно добавлена!";
                    MessageBox.Show(message, "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTB();
                    HideElements();
                    ShowAnimalsFromListBox(TypeAnimal);
                    _whatWeDoing = "";
                }
                else
                {
                    MessageBox.Show(result, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ReadDataFromTextBoxes()
        {
            try
            {
                if (string.IsNullOrEmpty(NumberTB.Text) || string.IsNullOrEmpty(ViewTB.Text) || string.IsNullOrEmpty(NumberTB.Text) || string.IsNullOrEmpty(CountFeedTB.Text) || string.IsNullOrEmpty(LastGraftTB.Text) || string.IsNullOrEmpty(NextGraftTB.Text) || string.IsNullOrEmpty(CoefficientOfMeatTB.Text) || string.IsNullOrEmpty(YieldProductionTB.Text))
                    throw new Exception("Не все поля заполнены");
                else
                {
                    _num = int.Parse(NumberTB.Text);
                    _view = ViewTB.Text;
                    _weight = double.Parse(weightTB.Text);
                    _feedInOneDay = double.Parse(CountFeedTB.Text);
                    _lastGraft = DateTime.Parse(LastGraftTB.Text);
                    _nextGraft = DateTime.Parse(NextGraftTB.Text);
                    _coeffOfMeat = double.Parse(CoefficientOfMeatTB.Text) / 100;
                    _coeffOfYieldProduction = double.Parse(YieldProductionTB.Text);
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Проверьте правильность введенных данных!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}