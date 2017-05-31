using Converter_from_binary_to_csv;
using Generator__binary_files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Generator__binary_files //Converter_from_binary_to_csv 
{
    
    class Program
    {
        static void Main(string[] args) // точка входа
        {
            Console.WriteLine("");
            Console.WriteLine("Введите количество строк для создаваемого бинарного файла  'D:\\Trade.dat' : ");
            Console.WriteLine("");

            string r = Console.ReadLine();
            int quantityTradeRecodLine = Convert.ToInt32(r);//количество элементов массива  содержашего структуры типа TradeRecod----х
            string path = @"D:\\Trade.dat";  //путь и имя будующего бинарного файла содержащего  структуры
            int counter = 0;//счетчик

            RandomString rnd = new RandomString();

            //создание экземпляра структуры и инициализфция полей (присвоение значений)
            TradeRecord[] trades = new TradeRecord[quantityTradeRecodLine]; // создание экземпяра структуры "TradeRecord" на X строк

            for (int i = 0; i < quantityTradeRecodLine; i++)
            {
                trades[i] = new TradeRecord(0 + i, 777, 640 + i, rnd.ArrayRand());
            }
           


            //секция критичная в части исключений
            try
            {
                //создание экземпляра BinaryWriter (запись  в бинарный файл)
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))// открывает поток для записи структур в файл
                {

                  
                    foreach (TradeRecord t in trades)
                    {
                        writer.Write(t.id);
                        writer.Write(t.account);
                        writer.Write(t.volume);
                        writer.Write(t.comment);

                        counter = counter + 1;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("в бинарный файл 'D:\\Trade.dat' записано   {0}  строк(и) структуры 'trade'", counter);

                    counter = 0;

                    

                }
            }

            //вывод сообщения о возновении исключения
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
            
        }
    }
}
