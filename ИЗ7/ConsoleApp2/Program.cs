using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    public struct Quote
    {
        public string quote { set; get; }
        public int watches { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Quote> list1 = new List<Quote>();

            string file, text, text2, n;
            int number = 1, j = 1;

            Console.WriteLine("Enter name of the file: ");
            file = Console.ReadLine();
            Console.WriteLine("\n");
            string path = file + ".txt";

            try
            {
                StreamReader sRead = new StreamReader(path);
                while ((text = sRead.ReadLine()) != null)
                {
                    text2 = sRead.ReadLine();
                    number = Convert.ToInt32(text2);
                    list1.Add(new Quote { quote = text, watches = number });
                }
                sRead.Close();
            }
            catch
            {

            }
            

            while (j != 0)
            {
                Console.WriteLine("Введите число: \n  1 - Добавить цитату\n  2 - Показать все цитаты\n  3 - Показать определенную цитату\n  0 - Выход\n");
                j = Convert.ToInt32(Console.ReadLine());
                switch (j)
                {
                    case 1:
                        Console.WriteLine("Новая цитата: ");
                        n = Console.ReadLine();
                        list1.Add(new Quote { quote = n, watches = 0 });
                        Console.WriteLine("//Цитата добавлена// \n");
                        break;
                    case 2:
                        Console.WriteLine("All citatas: \n");
                        int h = 1;
                        foreach (var element in list1)
                        {
                            try
                            {
                                Console.WriteLine("Цитата[" + h + "] " + element.quote.Substring(0, 10) + "... - Просмотры = " + element.watches);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Цитата[" + h + "] " + element.quote + " - Просмотры = " + element.watches);
                            }
                            h++;
                        }
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        Console.WriteLine("Введите номер цитаты: ");
                        int a;
                        a = Convert.ToInt32(Console.ReadLine());
                        if ((a > 0) && (a <= list1.Count))
                        {
                            
                            Quote d = list1[a - 1];
                            d.watches = d.watches + 1;
                            list1[a - 1] = d;
                            Console.WriteLine("Цитата[" + a + "] " + list1[a - 1].quote + " - Просмотры = " + list1[a - 1].watches);
                        }
                        else
                        {
                            Console.WriteLine("Такой цитаты нет!");
                        }
                        Console.WriteLine("\n");
                        break;
                    case 0:
                        Console.WriteLine("Выход.\n");
                        break;
                    default:
                        Console.WriteLine("Переходите по другим номераам, ну что это такое...\n");
                        break;
                }
            }
            StreamWriter ssWrite = new StreamWriter(path, false);
            ssWrite.Close();

            for (int i = 0; i < list1.Count; i++)
            {
                StreamWriter sWrite = new StreamWriter(path, true);
                sWrite.WriteLine(list1[i].quote);
                sWrite.WriteLine(list1[i].watches);
                sWrite.Close();
            }
            Console.ReadLine();
        }
    }
}
