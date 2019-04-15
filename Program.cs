using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp3
{

    class Square
    {

        private int side;
        public int Side { get => side; set => side = value == 0 ? 1 : value; }


        public Square()
        {
        }
        
        

        public double Diagonal(int side) => Math.Sqrt(2 * Side * Side);


        public int Perimeter(int side) => 4 * Side;


        public int Area(int side) => Side * Side;


        public override string ToString()
        {
            return "\nSide: " + Side + "\nArea: " + Area(Side) + "\nPerimeter: " + Perimeter(Side) + "\nDiagonal: " + Diagonal(Side);
        }
    }


    class SquarePrism : Square
    {
        private int height;
        public int Height { get => height; set => height = value == 0 ? 1 : value; }


        public SquarePrism()
        {
        }


        public SquarePrism(int height)
        {
            Height = height;
        }


        public double DiagonalOfSide(int height, int side) => Math.Sqrt((Math.Pow((double)side, 2) + Math.Pow((double)height,2)));


        public int SizePrism(int height, int area) => height * area;


        public double SizePrism(double height, int area) => height * area;


        public double DiagonalPrism(int height, int side) => Math.Sqrt(Math.Pow(side, 2) + Math.Pow(DiagonalOfSide(Height, Side),2));


        public override string ToString()
        {
            return "\nHeight: " + Height + "\nBottom Side: " + Side + "\nSize: " + SizePrism(Height,Area(Side)) + "\nDiagonal of Prism: " + DiagonalPrism(Height,Side); 
        }



    }



    class Program
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
                        arrayPrism[i] = new SquarePrism { Height = Convert.ToInt32(Console.ReadLine())};
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


                if (arrayPrism[i].DiagonalPrism(arrayPrism[i].Height,arrayPrism[i].Side) > maxP)
                { 
                    maxP = arrayPrism[i].DiagonalPrism(arrayPrism[i].Height,arrayPrism[i].Side); 
                    numberMaxP = i;
                }
            } // заполнение массива призм объектами и поиск максимального


            using (StreamWriter sw = new StreamWriter(@"test.txt",true)) // дозаписываем в файл ответ
            {
                sw.WriteLine("Квадрат с максимальной площадью под номером: " + numberMaxS + "\n" + arraySquare[numberMaxS].ToString());
                sw.WriteLine("Призма с максимальной диагональю под номером: " + numberMaxP + "\n" + arrayPrism[numberMaxP].ToString());
            }


            Console.WriteLine("Квадрат с максимальной площадью под номером: " + numberMaxS + "\n" + arraySquare[numberMaxS].ToString());
            Console.WriteLine("Призма с максимальной диагональю под номером: " + numberMaxP + "\n" + arrayPrism[numberMaxP].ToString());
            Console.ReadLine();
        }
            
    }

}

