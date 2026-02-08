using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prakt11_1_Storchevaya
{
    public class Student
    {
        private string name;
        private double rost;
        private double ves;

        public Student()
        {
            name = "Неизвестно";
            rost = 0;
            ves = 0;
        }

        public void SetName(string n)
        {
            if (string.IsNullOrWhiteSpace(n))
            {
                name = "Неизвестно";
                return;
            }
            if (n.Length < 2)
            {
                name = "Короткое имя";
                return;
            }
            if (n.Length > 50)
            {
                name = n.Substring(0, 47) + "...";
                return;
            }
            name = n.Trim();
        }

        public string GetName()
        {
            return name;
        }

        public void SetRost(double r)
        {
            if (r < 50)
            {
                rost = 50;
            }
            if (r > 250)
            {
                rost = 250;
            }

            rost = r;
        }

        public double GetRost()
        {
            return rost;
        }

        public double GetVes()
        {
            return ves;
        }

        public void SetIVes(double v)
        {
            if (v < 20)
            {
                ves = 20;
                return;
            }
            if (v > 200)
            {
                ves = 200;
                return;
            }

            ves = v;
        }

        public string SetEat(double eda)
        {
            string result = "";
            if (eda < 0)
            {
                result = "отриц еда быть не может";
                return result;
            }
            if (eda > 50)
            {
                result = "больше 50 кг нельзя съесть";
                return result;
            }
            if (eda == 0)
            {
                result = "ничего не съел";
                return result;
            }

            double orR = rost;
            double orV = ves;

            if (eda > 5 && eda < 10)
            {
                rost -= 1;

                double kkal = eda * 1000 - 1600;
                if (kkal > 0)
                {
                    double weight = kkal * 0.7 / 1000;
                    ves += weight;
                    result += $" Съедено {eda:F2} кг. Вес увеличен на {weight:F2} кг, рост уменьшен на 1 см ";
                }
                else
                {
                    result += $" Съедено {eda:F2} кг. Калорий недостаточно для набора веса, рост уменьшен на 1 см ";
                }
            }

            else if (eda >= 10)
            {
                rost -= 2;

                double kkal = eda * 1000 - 1800;
                if (kkal > 0)
                {
                    double weight = kkal * 0.5 / 1000;
                    ves += weight;
                    result += $" Съедено {eda:F2} кг. Вес увеличен на {weight:F2} кг, рост уменьшен на 2 см ";
                }
                else
                {
                    result += $" Съедено {eda:F2} кг. Калорий недостаточно для набора веса, рост уменьшен на 2 см ";
                }
            }
            else
            {
                double kkal = eda * 1000;
                if (kkal > 0)
                {
                    double weight = kkal / 1000 * 0.3;
                    ves += weight;
                    result += $"Съедено {eda:F2} кг. Вес увеличен на {weight:F2} кг";
                }
            }
            if (ves > 200)
            {
                result += "Вес привышает 200 кг";
            }

            if (ves < 30)
            {
                result += "Вес меньше 30 кг";
            }
            return result;
        }
        public double GetIMT()
        {
            if (rost == 0) return 0;
            double height = rost / 100;
            return ves / (height * height);
        }
        public string GetWCateg()
        {
            double imt = GetIMT();

            if (imt < 16) return "Выраженный дефицит массы тела";
            if (imt < 18.5) return "Недостаточная масса тела";
            if (imt < 25) return "Нормальная масса тела";
            if (imt < 30) return "Избыточная масса тела";
            if (imt < 35) return "Ожирение 1 ст";
            if (imt < 40) return "Ожирение 2 ст";
            return "Ожирание 3 ст";
        }

        public string GetInfo()
        {
            return $"Студент: {name}\n" +
                   $"Рост: {rost}см\n" +
                   $"Вес: {ves}кг\n" +
                   $"ИМТ: {GetIMT():F1} ({GetWCateg()})";
        }

        public void Resert()
        {
            try
            {
                rost = 170;
                ves = 70;
            }
            catch (Exception)
            {
                rost = 170;
                ves = 70;
            }
        }
    }
}
