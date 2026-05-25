using System;
using System.Windows.Forms;

namespace ООП_курсач_новый
{
    internal class Cow : Animal
    {
        private double _weight = 0;
        private DateTime _nextGraft;
        private double _feed = 0;
        private double _milkYield = 0;

        public Cow() { }

        public Cow(int number, string view, double weight, double feed, DateTime lastGraft,
                  DateTime nextGraft, double coefficientOfMeat, double litter)
        {
            Number = number;
            View = view;
            Weight = weight;
            Feed = feed;
            LastGraft = lastGraft;
            NextGraft = nextGraft;
            CoefficientOfMeat = coefficientOfMeat;
            _milkYield = litter;
        }

        public override double Weight
        {
            get => _weight;
            set
            {
                if (value <= 0 || value >= 1200)
                    throw new Exception("Вес не может быть отрицательным, равен 0, или больше 1200 кг");
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
                    else if ((value - LastGraft).TotalDays > 450)
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
                if (value <= 0 || value >= 20)
                    throw new Exception("Средняя суточная норма корма на 1 особь должна быть не отрицательной, равной 0, или больше 20 килограммов");
                else
                    _feed = value;
            }
        }
        public double MilkYield
        {
            get => _milkYield;
            set
            {
                if (value < 0 || value >= 50)
                    throw new Exception("Средний суточный удой 1 особи должен быть не отрицательным, равен 0, или больше 50 л");
                else
                    _milkYield=value;
            }
        }
        public override string ToString()
        {
            string lastGraftStr = LastGraft.ToString("dd.MM.yy");
            string nextGraftStr = NextGraft.ToString("dd.MM.yy");
            return $"№ особи {Number}; Вид {View}; Вес: {Weight}кг; Корм: {Feed}кг/день; Процент мяса на продажу {CoefficientOfMeat*100} или {MeatYield} кг; Удой с 1 особи {_milkYield} в сутки(среднее)";
        }
    }
}
