using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public static string path = null;
        public int counter = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != null)
            {
                label1.Enabled = label2.Enabled = label3.Enabled = false;
                textBox1.Visible = textBox1.Enabled = Next.Visible = true;

            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label1.Enabled = label2.Enabled = label3.Enabled = false;
            textBox1.Visible = textBox1.Enabled = Next.Visible = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                counter++;
                path = textBox1.Text;
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {

                    }
                }
                catch
                {
                    MessageBox.Show("Не верно указан путь");
                    counter--;
                }
                textBox1.Visible = textBox1.Enabled = false;
                textBox2.Visible = textBox2.Enabled = true;

            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                path = textBox1.Text;
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        File.WriteAllText(path, String.Empty);
                        textBox1.Visible = textBox1.Enabled = false;
                        textBox2.Visible = textBox2.Enabled = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Не верно указан путь");
                    counter--;
                }
                
            }
            if (counter == 2)
            {
                using (StreamWriter sr = new StreamWriter(path, true))
                {
                    int flag = 0;
                    try
                    {
                        flag = Convert.ToInt32(textBox2.Text);
                        sr.WriteLine(textBox2.Text);
                        textBox2.Visible = textBox2.Enabled = false;
                        textBox3.Visible = textBox3.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Не верные данные");
                        counter--;
                    }
                    
                }                
            }
            if (counter == 3)
            {
                using (StreamWriter sr = new StreamWriter(path, true))
                {
                    int flag = 0;
                    try
                    {
                        flag = Convert.ToInt32(textBox3.Text);
                        sr.WriteLine(textBox3.Text);
                        textBox3.Visible = textBox3.Enabled = false;
                        //textBox4.Visible = textBox4.Enabled = true;
                    }
                    catch
                    {
                        MessageBox.Show("Не верные данные");
                        counter--;
                    }
                    
                }
                
            }





        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                counter++;

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    int flag;
                    try
                    {
                        flag = Convert.ToInt32(textBox2.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Не верно введенные данные, перепроверьте поле ввода");
                        counter--;
                    }
                    sw.WriteLine((textBox2.Text));
                    sw.Close();
                }
                textBox2.Visible = textBox2.Enabled = false;
                textBox3.Visible = textBox3.Enabled = true;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                counter++;
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    int flag;
                    try
                    {
                        flag = Convert.ToInt32(textBox3.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Не верно введенные данные, перепроверьте поле ввода");
                        counter--;
                    }
                    sw.WriteLine((textBox3.Text));
                    sw.Close();
                }
                textBox3.Visible = textBox3.Enabled = false;
                //textBox4.Visible = textBox4.Enabled = true;
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = null;
            textBox3.ForeColor = Color.Black;
        }

       
    }
}
 






        /*private void textBox1_Leave(object sender, EventArgs e)
        {
            path = textBox1.Text;         
        }


        /*private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {            
            try
            {                
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    int flag;
                    if (e.KeyChar == 13)
                    {
                        try
                        {
                            flag = Convert.ToInt32(textBox2.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Не верно введенные данные, перепроверьте второе поле");
                        }
                        sw.WriteLine((textBox2.Text));
                        textBox2.Text = null;                        
                    }
                    sw.Close();
                };
            }
            catch
            {
                MessageBox.Show("Не верно указан путь"); 
            }
            
            
        }

 
    }
}

//C:\Users\Игорь\source\repos\2 лаба сifhg\WindowsFormsApp2\bin\Debug\test.txt

/*class Program
{
    static void Main(string[] args)
    {

        int amountOfSquares = 0;
        string amountOfPrisms = null; // строка т.к. при считывании из файла не прийдется конвертировать все строки в int

        try
        {
            using (StreamReader sr = new StreamReader(@"test.txt"))
            {

                amountOfSquares = Convert.ToInt32(sr.ReadLine()); // считываем количество квадратов(первая строка)
                amountOfPrisms = sr.ReadLine();  //считываем количество призм (вторая строка)              
            }
        }
        catch
        {
            Console.WriteLine("THE FILE COULD NOT BE READ");
        } // считываем данные из файла




        Square[] arraySquare = new Square[amountOfSquares]; // создаем массив объектов для квадратов
        int maxS = 0;
        int numberMaxS = 0;
        bool flag = false;

        for (int i = 0; i < amountOfSquares; i++)
        {
            Console.WriteLine($"Введите длину стороны квадрата");
            do
            {
                try
                {
                    arraySquare[i] = new Square { Side = Convert.ToInt32(Console.ReadLine()) };
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка!Введите корректное значение.");
                }
            } while (flag == false);// проверка на верность ввода значений
            flag = false;

            if (arraySquare[i].Area(arraySquare[i].Side) > maxS)
            {
                numberMaxS = i;
                maxS = arraySquare[i].Area(arraySquare[i].Side);
            }
        } // заполнение массива квадратов объектами и поиск максимального




        int iamountOfPrisms = Convert.ToInt32(amountOfPrisms);
        SquarePrism[] arrayPrism = new SquarePrism[iamountOfPrisms]; // создаем массив объектов для призм
        double maxP = 0;
        int numberMaxP = 0;

        for (int i = 0; i < iamountOfPrisms; i++)
        {
            Console.WriteLine($"Введите высоту призмы и длину стороны основания");
            do
            {
                try
                {
                    arrayPrism[i] = new SquarePrism { Height = Convert.ToInt32(Console.ReadLine()) };
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка!Введите корректное значение для высоты.");
                }
            } while (flag == false);
            flag = false;
            do
            {
                try
                {
                    arrayPrism[i].Side = Convert.ToInt32(Console.ReadLine());
                    flag = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка!Введите корректное значение для стороны основания.");
                }
            } while (flag == false);
            flag = false;


            if (arrayPrism[i].DiagonalPrism(arrayPrism[i].Height, arrayPrism[i].Side) > maxP)
            {
                maxP = arrayPrism[i].DiagonalPrism(arrayPrism[i].Height, arrayPrism[i].Side);
                numberMaxP = i;
            }
        } // заполнение массива призм объектами и поиск максимального


        using (StreamWriter sw = new StreamWriter(@"test.txt", true)) // дозаписываем в файл ответ
        {
            sw.WriteLine("Квадрат с максимальной площадью под номером: " + numberMaxS + "\n" + arraySquare[numberMaxS].ToString());
            sw.WriteLine("Призма с максимальной диагональю под номером: " + numberMaxP + "\n" + arrayPrism[numberMaxP].ToString());
        }


        Console.WriteLine("Квадрат с максимальной площадью под номером: " + numberMaxS + "\n" + arraySquare[numberMaxS].ToString());
        Console.WriteLine("Призма с максимальной диагональю под номером: " + numberMaxP + "\n" + arrayPrism[numberMaxP].ToString());
        Console.ReadLine();
    }

}
*/
