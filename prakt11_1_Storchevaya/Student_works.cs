using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prakt11_1_Storchevaya
{
    public partial class Student_work : Form
    {
        private Student stud = new Student();
        public Student_work()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stud = new Student();
            stud.SetName(textBox1.Text);
            stud.SetRost((double)numericUpDown1.Value);
            stud.SetIVes((double)numericUpDown2.Value);

            double eda = (double)numericUpDown3.Value;

            string result = "Расчет веса студента\n\n";
            result += $"Имя: {stud.GetName()}\n";
            result += $"Рост: {stud.GetRost()} см\n";
            result += $"Начальный вес: {stud.GetVes():F2} кг\n";
            result += $"Съедено еды: {eda} кг\n\n";

            double orRost = stud.GetRost();
            double orVes = stud.GetVes();

            string eatRes = stud.SetEat(eda);
            result += $"До еды: рост {orRost} см, вес {orVes} кг\n";
            result += $"После еды: рост {stud.GetRost()} см, вес {stud.GetVes()} кг\n";
            result += $"{eatRes}\n\n";
            result += $"ИМТ: {stud.GetIMT():F1} ({stud.GetWCateg()})\n\n";

            richTextBox1.Text = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
    }
}
