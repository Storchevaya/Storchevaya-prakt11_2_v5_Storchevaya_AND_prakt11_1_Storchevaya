using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prack_11_2_v5_
{
    public partial class Form1 : Form
    {
        private ComplexNumber numberA;
        private ComplexNumber numberB;
        public Form1()
        {
            InitializeComponent();
            InitializeNumbers();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;
            button7.Click += button7_Click;
            button8.Click += button8_Click;
            button9.Click += button9_Click;
            button10.Click += button10_Click;
            button11.Click += button11_Click;
        }
        private void InitializeNumbers()
        {
            try
            {
                //начальные значения в TextBox
                textBox1.Text = "3";  
                textBox4.Text = "4"; 
                textBox3.Text = "1";  
                textBox2.Text = "2"; 
            }
            catch { }
        }
        private bool LoadNumbersFromTextBoxes()
        {
            try
            {
                double realA = double.Parse(textBox1.Text.Replace('.', ','));
                double imagA = double.Parse(textBox4.Text.Replace('.', ','));
                double realB = double.Parse(textBox3.Text.Replace('.', ','));
                double imagB = double.Parse(textBox2.Text.Replace('.', ','));

                numberA = new ComplexNumber(realA, imagA);
                numberB = new ComplexNumber(realB, imagB);

                return true;
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка загрузки чисел: {ex.Message}\n");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA + numberB;
                richTextBox1.AppendText($"Сложение: {numberA} + {numberB} = {result}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка сложения: {ex.Message}\n");
            }
        }

        //Вычитание
        private void button2_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA - numberB;
                richTextBox1.AppendText($"Вычитание: {numberA} - {numberB} = {result}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка вычитания: {ex.Message}\n");
            }
        }

        //Умножение
        private void button3_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA * numberB;
                richTextBox1.AppendText($"Умножение: {numberA} × {numberB} = {result}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка умножения: {ex.Message}\n");
            }
        }

        //Деление
        private void button4_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA / numberB;
                richTextBox1.AppendText($"Деление: {numberA} ÷ {numberB} = {result}\n");
            }
            catch (DivideByZeroException)
            {
                richTextBox1.AppendText($"Ошибка: деление на ноль!\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка деления: {ex.Message}\n");
            }
        }

        //Сопряжение A
        private void button5_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA.Conjugate();
                richTextBox1.AppendText($"Сопряжение A: conj({numberA}) = {result}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка сопряжения: {ex.Message}\n");
            }
        }

        //Загрузить числа
        private void button6_Click(object sender, EventArgs e)
        {
            if (LoadNumbersFromTextBoxes())
            {
                richTextBox1.AppendText($"Числа загружены:\nA = {numberA}\nB = {numberB}\n");
            }
        }

        //Квадрат A
        private void button7_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber result = numberA.Square();
                richTextBox1.AppendText($"Квадрат A: ({numberA})² = {result}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка возведения в квадрат: {ex.Message}\n");
            }
        }

        //Формы записи A
        private void button8_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                richTextBox1.AppendText($"Формы записи числа A:\n");
                richTextBox1.AppendText($"{numberA.GetAllForms()}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка: {ex.Message}\n");
            }
        }

        //Формы записи B
        private void button9_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                richTextBox1.AppendText($"Формы записи числа B:\n");
                richTextBox1.AppendText($"{numberB.GetAllForms()}\n");
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка: {ex.Message}\n");
            }
        }

        //Очистить
        private void button10_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        //Корень A
        private void button11_Click(object sender, EventArgs e)
        {
            if (!LoadNumbersFromTextBoxes()) return;

            try
            {
                ComplexNumber[] roots = numberA.SquareRoot();
                richTextBox1.AppendText($"Квадратные корни из A ({numberA}):\n");

                for (int i = 0; i < roots.Length; i++)
                {
                    richTextBox1.AppendText($"Корень {i + 1}: {roots[i]}\n");
                }
            }
            catch (Exception ex)
            {
                richTextBox1.AppendText($"Ошибка извлечения корня: {ex.Message}\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
