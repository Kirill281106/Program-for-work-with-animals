using System;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class Сhicken:Animal
    {
        private double _weight = 0;
        private DateTime _nextGraft;
        private double _feed = 0;
        private double _eagsYield = 0;

        public Сhicken() { }

        public Сhicken(int number, string view, double weight, double feed, DateTime lastGraft,
                  DateTime nextGraft, double coefficientOfMeat, double eags)
        {
            Number = number;
            View = view;
            Weight = weight;
            Feed = feed;
            LastGraft = lastGraft;
            NextGraft = nextGraft;
            CoefficientOfMeat = coefficientOfMeat;
            EagsYield = eags;
        }
        public override double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0 || value >= 10)
                    throw new Exception("Вес не может быть отрицательным, равен 0 или 10 кг");
                else
                    _weight = value;
            }
        }
        public override DateTime NextGraft
        {
            get => _nextGraft;
            set
            {
                if (LastGraft.Year > 2000)
                {
                    if (value < LastGraft)
                        throw new Exception("Дата запланированной прививки не может быть раньше сделанной");
                    else if ((value - LastGraft).TotalDays > 365)
                        throw new Exception("Слишком большой период между прививками");
                }
                _nextGraft = value;
            }
        }
        public override double Feed
        {
            get => _feed;
            set
            {
                if (value <= 0 || value >= 400)
                    throw new Exception("Средняя суточная норма корма на 1 особь не может быть отрицательной, равной 0 или больше 400 грамм");
                else
                    _feed = value;
            }
        }
        public double EagsYield
        {
            get => _eagsYield;
            set
            {
                if (value < 0 || value >= 8)
                    throw new Exception("Количество яиц в неделю не может быть отрицательной или более 8");
                else
                    _eagsYield = value;
            }
        }
        public override string ToString()
        {
            string lastGraftStr = LastGraft.ToString("dd.MM.yy");
            string nextGraftStr = NextGraft.ToString("dd.MM.yy");
            return $"№ особи {Number}; Вид {View}; Вес: {Weight}кг; Корм: {Feed}; Процент мяса на продажу {CoefficientOfMeat*100} или {MeatYield} кг; Яйца с 1 особи {EagsYield} в неделю(среднее)";
        }
    }
}
