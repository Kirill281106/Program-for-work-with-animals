using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class AnimalFile
    {
        private string _cowsFile = "Cows.json";
        private string _pigsFile = "Pigs.json";
        private string _chickensFile = "Chickens.json";
        public List<Cow> CowsInFile => ListCowFromFile() ?? new List<Cow>();
        public List<Pig> PigsInFile => ListPigsFromFile() ?? new List<Pig>();
        public List<Сhicken> СhickenInFile => ListСhickensFromFile() ?? new List<Сhicken>();

        private JsonSerializerOptions GetJsonOptions()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };
        }

        public List<Cow> ListCowFromFile()
        {
            List<Cow> allCowsInFile = new List<Cow>();
            try
            {
                if (!File.Exists(_cowsFile))
                {
                    File.WriteAllText(_cowsFile, "[]");
                    MessageBox.Show("Файл отсутствует, создан новый файл", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string cowsInFile = File.ReadAllText(_cowsFile);
                    List<Cow> cows = JsonSerializer.Deserialize<List<Cow>>(cowsInFile, GetJsonOptions());
                    if (cows != null)
                    {
                        allCowsInFile = cows;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке коров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return allCowsInFile;
        }
        public List<Pig> ListPigsFromFile()
        {
            List<Pig> allPigsInFile = new List<Pig>();
            try
            {
                if (!File.Exists(_pigsFile))
                {
                    File.WriteAllText(_pigsFile, "[]");
                    MessageBox.Show("Файл отсутствует, создан новый файл", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string pigsInFile = File.ReadAllText(_pigsFile);
                    List<Pig> pigs = JsonSerializer.Deserialize<List<Pig>>(pigsInFile, GetJsonOptions());
                    if (pigs != null)
                    {
                        allPigsInFile = pigs;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке свиней: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return allPigsInFile;
        }
        public List<Сhicken> ListСhickensFromFile()
        {
            List<Сhicken> allChickensInFile = new List<Сhicken>();
            try
            {
                if (!File.Exists(_chickensFile))
                {
                    File.WriteAllText(_chickensFile, "[]");
                    MessageBox.Show("Файл отсутствует, создан новый файл", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string chickensInFile = File.ReadAllText(_chickensFile);
                    List<Сhicken> chickens = JsonSerializer.Deserialize<List<Сhicken>>(chickensInFile, GetJsonOptions());
                    if (chickens != null)
                    {
                        allChickensInFile = chickens;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке кур: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return allChickensInFile;
        }
        public bool SavePigsToFile(List<Pig> pigs)
        {
            try
            {
                string json = JsonSerializer.Serialize(pigs, GetJsonOptions());
                File.WriteAllText(_pigsFile, json);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении свиней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SaveCowsToFile(List<Cow> cows)
        {
            try
            {
                string json = JsonSerializer.Serialize(cows, GetJsonOptions());
                File.WriteAllText(_cowsFile, json);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении коров", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public bool SaveChickenToFile(List<Сhicken> chicken)
        {
            try
            {
                string json = JsonSerializer.Serialize(chicken, GetJsonOptions());
                File.WriteAllText(_chickensFile, json);
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении кур", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}