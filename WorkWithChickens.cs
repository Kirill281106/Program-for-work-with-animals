using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class WorkWithChickens : Сhicken
    {
        private AnimalFile animalFile = new AnimalFile();
        private List<Сhicken> chickens = new List<Сhicken>();
        private string _chickensFile = "Chickens.json";
        public WorkWithChickens()
        {
            InitializeChickensFile();
        }
        public void InitializeChickensFile()
        {
            try
            {
                chickens = animalFile.ListСhickensFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CreateNewСhicken(Сhicken chicken)
        {
            try
            {
                bool exists = false;
                foreach (Сhicken c in chickens)
                {
                    if (c.Number == chicken.Number)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    return "Животное с таким номером уже существует";
                }

                chickens.Add(chicken);
                animalFile.SaveChickenToFile(chickens);
                return "Успех";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"Ошибка при сохранении: {ex.Message}";
            }
        }
        public string DeleteСhicken(int num)
        {
            try
            {
                Сhicken chickenToDelete = null;
                foreach (Сhicken ch in chickens)
                {
                    if (ch.Number == num)
                    {
                        chickenToDelete = ch;
                        break;
                    }
                }
                if (chickenToDelete == null)
                {
                    return "Запись не найдена";
                }
                chickens.Remove(chickenToDelete);

                string jsonString = JsonSerializer.Serialize(chickens);
                File.WriteAllText(_chickensFile, jsonString);

                return "Удалён";
            }
            catch (Exception ex)
            {
                return $"Ошибка удаления: {ex.Message}";
            }
        }
        public string EditСhicken(Сhicken chicken)
        {
            try
            {
                chickens.Add(chicken);
                animalFile.SaveChickenToFile(chickens);
                return "Успех";
            }
            catch (ArgumentException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return $"Ошибка при сохранении: {ex.Message}";
            }
        }
        public Сhicken GetChickenByNumber(int number)
        {
            try
            {
                foreach (Сhicken ch in chickens)
                {
                    if (ch.Number == number)
                    {
                        return ch;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске курицы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
