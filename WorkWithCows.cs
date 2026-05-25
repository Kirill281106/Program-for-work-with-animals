using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class WorkWithCows : Cow
    {
        private AnimalFile animalFile = new AnimalFile();
        private List<Cow> cows = new List<Cow>();
        private string _cowsFile = "Cows.json";
        public WorkWithCows()
        {
            InitializeCowsFile();
        }
        public void InitializeCowsFile()
        {
            try
            {
                cows = animalFile.ListCowFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CreateNewCow(Cow cow)
        {
            try
            {
                bool exists = false;
                foreach (Cow cow1 in cows)
                {
                    if (cow1.Number == cow.Number)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    return "Животное с таким номером уже существует";
                }

                cows.Add(cow);
                animalFile.SaveCowsToFile(cows);
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
        public string DeleteCow(int num)
        {
            try
            {
                Cow cowToDelete = null;
                foreach (Cow cow1 in cows)
                {
                    if (cow1.Number == num)
                    {
                        cowToDelete = cow1;
                        break;
                    }
                }
                if (cowToDelete == null)
                {
                    return "Запись не найдена";
                }
                cows.Remove(cowToDelete);

                string jsonString = JsonSerializer.Serialize(cows);
                File.WriteAllText(_cowsFile, jsonString);

                return "Удалён";
            }
            catch (Exception ex)
            {
                return $"Ошибка удаления: {ex.Message}";
            }
        }
        public string EditCow(Cow cow)
        {
            try
            {
                cows.Add(cow);
                animalFile.SaveCowsToFile(cows);
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
        public Cow GetCowByNumber(int number)
        {
            try
            {
                foreach (Cow c in cows)
                {
                    if (c.Number == number)
                    {
                        return c;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске коровы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
