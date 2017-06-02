using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Converter_from_binary_to_csv
{

       //в рамках одного класса:'ConvertingBinaryToCSV' 
       //реализуем заново оба метода:
       // - 'fromBinaryFile' 
       //  - 'toCSV'


    public class ConvertingBinaryToCSV : IConvertingBinaryToCSV
    {
        public string path_dat_ = Path.Default.path_dat; //путь и имя бинарного файла со структурами
        public string path_CSV_ = Path.Default.path_csv;  //путь и имя  создаваемого файла с разделителями, типа *.CSV
        
        //коструктоp пользовательский
        public ConvertingBinaryToCSV()
        {
                    
        }

        public void fromBinaryFile()
        {
            
        }

        public void toCSV()
        {
            
        }
       



        //метод 'fromBinaryFile' , вычитывает данные из бинарного потока и возвращает коллекцию структурированных данных  
        public List<TradeRecord> fromBinaryFile( out int result)
        {


            //создаем экземпляр коллекции , содержащую набор элементов типа структуры TradeRecod
            List<TradeRecord> trades = new List<TradeRecord>();

            int i = 0;//переменная счетчика

            //инициация потока
            using (BinaryReader reader = new BinaryReader(File.Open(path_dat_, FileMode.Open), Encoding.ASCII))
            {

                Console.WriteLine("выполняется чтение из бинарного файла:{0}", path_dat_);
                reader.BaseStream.Position = 0;// устанавливаем "курсор" на 0-вую позицию в читаемом бинарном файле


                // считываем через цикл каждое значение полей строк структуры "TradeRecord" из бинарного файла
                while (reader.PeekChar() > -1)// пока не достигнут конец файла
                {
                    int id_ = reader.ReadInt32();
                    int account_ = reader.ReadInt32();
                    double volume_ = reader.ReadDouble();
                    string comment_ = reader.ReadString();


                    //вывод в консоль вычитаных полей (значительно увеличивает время обработки)
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

            return trades;//возвращаем коллекцию 
        }

        
        



        //метод 'toCSV' получает коллекцию структурированных данных  и генерирует из нее конечный файл *.CSV 
        public int toCSV(List<TradeRecord> trade)
        {
            int i = 0;//переменая счетчика
            int result = 0;//счетчик количества строк выгруженных в файл *.CSV
            //секция критичная в части исключений
           

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path_CSV_))
                {

                    foreach (TradeRecord t in trade)
                    {
                        file.Write(t.id);
                        file.Write(";");
                        file.Write(t.account);
                        file.Write(";");
                        file.Write(t.volume);
                        file.Write(";");
                        file.Write(t.comment);

                        file.WriteLine(";");

                        i++;
                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                    Console.WriteLine();
                    Console.WriteLine(" в файл:   {0}      cконвертировано :   {1} строк ", path_CSV_, i);

                result = i;
                i = 0;

                }
            return result;//возвращаем количество строк выгруженных 
        }
       
    }
}
        
    
