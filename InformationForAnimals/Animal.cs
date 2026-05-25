using System;

namespace ООП_курсач_новый
{
    abstract class Animal
    {
        private int _numberForAnimal = 0;
        private DateTime _lastGraft;
        private string _view = "";
        private double _meatYield = 0;
        private double _coefficientOfMeat = 0;

        public int Number
        {
            get => _numberForAnimal;
            set
            {
                if (value <= 0)
                    throw new Exception("Номер животного не может быть отрицательным либо равным 0");
                else
                    _numberForAnimal = value;
            }
        }
        public DateTime LastGraft
        {
            get => _lastGraft;
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Предыдущая прививка не может быть сделана в будущем");
                else if (value.Year < DateTime.Now.Year - 3)
                    throw new Exception("Прививка не может быть сделана 3 года назад, слишком долгий период");
                else
                    _lastGraft = value;
            }
        }
        public string View
        {
            get => _view;
            set
            {
                    _view = value;
            }
        }
        public double CoefficientOfMeat
        {
            get => _coefficientOfMeat;
            set
            {
                if (value < 0.1 || value >= 0.9)
                    throw new Exception("Коэффициент мяса на массу 1 особи не может быть меньше 10% или больше 89%");
                else
                    _coefficientOfMeat = value;
            }
        }
        public double MeatYield
        {
            get => _meatYield;
            set
            {
                if (Weight * _coefficientOfMeat <= 0)
                    throw new Exception("Средняя масса получаемого мяса с 1 особи не может быть отрицательной или равно 0");

                else if (Weight * _coefficientOfMeat / 100 >= Weight)
                    throw new Exception("Средняя масса получаемого мяса с 1 особи не может быть больше массы самого животного");

                else
                    _meatYield = Weight * _coefficientOfMeat;
            }
        }
        public abstract DateTime NextGraft { get; set; }
        public abstract double Feed { get; set; }
        public abstract double Weight { get; set; }
    }
}
