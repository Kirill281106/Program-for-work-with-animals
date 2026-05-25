using System;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class Pig : Animal
    {
        private double _weight = 0;
        private DateTime _nextGraft;
        private double _feed = 0;
        private double _litter = 0;
        public Pig() { }

        public Pig(int number, string view, double weight, double feed, DateTime lastGraft,
                  DateTime nextGraft, double coefficientOfMeat, double litter)
        {
            Number = number;
            View = view;
            Weight = weight;
            Feed = feed;
            LastGraft = lastGraft;
            NextGraft = nextGraft;
            CoefficientOfMeat = coefficientOfMeat;
            Litter = litter;
        }

        public override double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0 || value >= 650)
                    throw new Exception("Вес не может быть отрицательным, равен 0 или больше 650 кг");
                else
                    _weight = value;
            }
        }

        public override DateTime NextGraft
        {
            get => _nextGraft.Date;
            set
            {
                if (LastGraft.Year > 2000)
                {
                    if (value < LastGraft.Date)
                        throw new Exception("Дата запланированной прививки не может быть раньше сделанной");
                    else if ((value - LastGraft).Days > 420)
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
                if (value <= 0 || value >= 12)
                    throw new Exception("Средняя суточная норма корма на 1 особь не может быть отрицательной, равной 0 или больше 12 килограммов");
                else
                    _feed = value;
            }
        }
        public double Litter
        {
            get => _litter;
            set
            {
                if (value<=0 || value >= 17)
                    throw new Exception("Cредний суточный помёт 1 особи не может быть меньше либо равен 0 кг или больше 17 кг");
                else
                    _litter = value;
            }
        }
        public override string ToString()
        {
            string lastGraftStr = LastGraft.ToString("dd.MM.yy");
            string nextGraftStr = NextGraft.ToString("dd.MM.yy");
            return $"№ особи {Number}; Вид {View}; Вес: {Weight}кг; Корм: {Feed}кг/день; Процент мяса на продажу {CoefficientOfMeat*100} или {MeatYield} кг; Помёт с 1 особи {Litter} кг в сутки(среднее)";
        }
    }
}
