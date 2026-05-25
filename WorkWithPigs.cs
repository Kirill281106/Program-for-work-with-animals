using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class WorkWithPigs : Pig
    {
        private AnimalFile animalFile = new AnimalFile();
        private List<Pig> pigs = new List<Pig>();
        private string _pigsFile = "Pigs.json";
        public WorkWithPigs()
        {
            InitializePigsFile();
        }
        public void InitializePigsFile()
        {
            try
            {
                pigs = animalFile.ListPigsFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файла: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string CreateNewPig(Pig pig)
        {
            try
            {
                bool exists = false;
                foreach (Pig p in pigs)
                {
                    if (p.Number == pig.Number)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    return "Животное с таким номером уже существует";
                }

                pigs.Add(pig);
                animalFile.SavePigsToFile(pigs);
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
        public string DeletePig(int num)
        {
            try
            {
                Pig pigToDelete = null;
                foreach (Pig p in pigs)
                {
                    if (p.Number == num)
                    {
                        pigToDelete = p;
                        break;
                    }
                }
                if (pigToDelete == null)
                {
                    return "Запись не найдена";
                }
                pigs.Remove(pigToDelete);

                string jsonString = JsonSerializer.Serialize(pigs);
                File.WriteAllText(_pigsFile, jsonString);

                return "Удалён";
            }
            catch (Exception ex)
            {
                return $"Ошибка удаления: {ex.Message}";
            }
        }
        public string EditPig(Pig pig)
        {
            try
            {
                pigs.Add(pig);
                animalFile.SavePigsToFile(pigs);
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
        public Pig GetPigByNumber(int number)
        {
            try
            {
                foreach (Pig p in pigs)
                {
                    if (p.Number == number)
                    {
                        return p;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при поиске свиньи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
