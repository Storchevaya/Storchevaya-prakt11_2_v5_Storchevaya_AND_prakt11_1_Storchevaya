using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prack_11_2_v5_
{
    public class ComplexNumber
    {
        private double real;
        private double imaginary;
        private double magnitude;
        private double phase;

        public enum RepresentationForm
        {
            Algebraic,
            Trigonometric,
            Exponential
        }

        public RepresentationForm CurrentForm { get; private set; }

        public double Real
        {
            get => real;
            private set
            {
                real = value;
                UpdatePolar();
            }
        }

        public double Imaginary
        {
            get => imaginary;
            private set
            {
                imaginary = value;
                UpdatePolar();
            }
        }

        public double Magnitude { get => magnitude; }
        public double Phase { get => phase; }

        public ComplexNumber(double real, double imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
            UpdatePolar();
            CurrentForm = RepresentationForm.Algebraic;
        }

        private void UpdatePolar()
        {
            magnitude = Math.Sqrt(real * real + imaginary * imaginary);

            if (Math.Abs(real) < 1e-15 && Math.Abs(imaginary) < 1e-15)
                phase = 0;
            else
                phase = Math.Atan2(imaginary, real);
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.real + b.real, a.imaginary + b.imaginary);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.real - b.real, a.imaginary - b.imaginary);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double newReal = a.real * b.real - a.imaginary * b.imaginary;
            double newImag = a.real * b.imaginary + a.imaginary * b.real;
            return new ComplexNumber(newReal, newImag);
        }

        public static ComplexNumber operator /(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.real * b.real + b.imaginary * b.imaginary;

            if (Math.Abs(denominator) < 1e-15)
                throw new DivideByZeroException("Деление на ноль невозможно");

            double newReal = (a.real * b.real + a.imaginary * b.imaginary) / denominator;
            double newImag = (a.imaginary * b.real - a.real * b.imaginary) / denominator;

            return new ComplexNumber(newReal, newImag);
        }

        public ComplexNumber Conjugate()
        {
            return new ComplexNumber(real, -imaginary);
        }

        public ComplexNumber Square()
        {
            return this * this;
        }

        public ComplexNumber Power(int n)
        {
            if (n == 0) return new ComplexNumber(1, 0);

            double newMagnitude = Math.Pow(magnitude, n);
            double newPhase = phase * n;

            return new ComplexNumber(
                newMagnitude * Math.Cos(newPhase),
                newMagnitude * Math.Sin(newPhase)
            );
        }

        public ComplexNumber[] SquareRoot()
        {
            return Root(2);
        }

        public ComplexNumber[] Root(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Степень корня должна быть положительной");

            double rootMagnitude = Math.Pow(magnitude, 1.0 / n);
            ComplexNumber[] roots = new ComplexNumber[n];

            for (int k = 0; k < n; k++)
            {
                double rootPhase = (phase + 2 * Math.PI * k) / n;
                roots[k] = new ComplexNumber(
                    rootMagnitude * Math.Cos(rootPhase),
                    rootMagnitude * Math.Sin(rootPhase)
                );
            }

            return roots;
        }

        public void SetForm(RepresentationForm form)
        {
            CurrentForm = form;
        }

        public string GetAlgebraicForm()
        {
            if (Math.Abs(imaginary) < 1e-15)
                return $"{real:0.###}";

            string sign = imaginary >= 0 ? "+" : "-";
            double absImag = Math.Abs(imaginary);

            if (Math.Abs(absImag - 1) < 1e-15)
                return $"{real:0.###} {sign} i";
            else
                return $"{real:0.###} {sign} {absImag:0.###}i";
        }

        public string GetTrigonometricForm()
        {
            return $"{magnitude:0.###}(cos({phase:0.###}) + i·sin({phase:0.###}))";
        }

        public string GetExponentialForm()
        {
            return $"{magnitude:0.###}·e^(i·{phase:0.###})";
        }

        public string GetAllForms()
        {
            return $"Алгебраическая: {GetAlgebraicForm()}\n" +
                   $"Тригонометрическая: {GetTrigonometricForm()}\n" +
                   $"Экспоненциальная: {GetExponentialForm()}";
        }

        public override string ToString()
        {
            return GetAlgebraicForm();
        }
    }
}
