﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    namespace Converter_from_binary_to_csv
{
    //описание структуры 'TradeRecord'
    [StructLayout(LayoutKind.Sequential, Pack = 1)]// размещение в неуправляемый код
    public struct TradeRecord //обьявление структуры "TradeRecord"
    {

        public int id;
        public int account;
        public double volume;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)] //маршалинг в неуправляемый код
        public string comment;


        //конструктор структуры "TradeRecord"
        public TradeRecord(int a, int b, double c, string d)
        {
            id = a;
            account = b;
            volume = c;
            comment = d;
        }

    }
   

    public class ReaderFromBinaryFiles : IReaderFromBinaryFiles
    {

        //коструктоp пользовательский
        public ReaderFromBinaryFiles()
        {
            
        }

        public void fromBinaryFile()
        {

        }

        public string path_dat_ = Path.Default.path_dat; //путь и имя бинарного файла со структурами

        //метод 'fromBinaryFile' , вычитывает данные из бинарного потока и возвращает коллекцию структурированных данных  
        public List<TradeRecord>  fromBinaryFile( out int result )
        {

            //создаем экземпляр коллекции , содержащую набор элементов типа структуры TradeRecod
            List<TradeRecord> trades = new List<TradeRecord>();

             

            int i = 0;//переменная счетчика
            
            //инициация потока
            using (BinaryReader reader = new BinaryReader(File.Open(path_dat_, FileMode.Open), Encoding.ASCII))
            {

                Console.WriteLine("выполняется чтение из бинарного файла:{0}", path_dat_ );

                reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле


                // считываем через цикл каждое значение полей строк структуры "TradeRecord" из бинарного файла
                while (reader.PeekChar() > -1)// пока не достигнут конец файла
                {
                    int id_ = reader.ReadInt32();
                    int account_ = reader.ReadInt32();
                    double volume_ = reader.ReadDouble();
                    string comment_ = reader.ReadString();


                    //вывод в консоль вычитаных полей (для отладки)
                    //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", id, account, volume, comment);

                    // инециализируем поля структуры находящейся в коллекции
                    trades.Add(new TradeRecord() { id = id_, account = account_, volume = volume_, comment = comment_ });

                    i++;
                    //Console.WriteLine("вычитанно строк: {0} ", i);
                }
                Console.WriteLine();
                Console.WriteLine("вычитано строк: {0}", i);
                result = i;
                i = 0;

            }

            return trades;//возвращаем коллекцию c данными
            
        }
    }
}