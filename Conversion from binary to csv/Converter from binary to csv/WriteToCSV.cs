using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converter_from_binary_to_csv
{


    public class WriteToCSV: IWriteToCSV
    {
       
        //коструктоp пользовательский_1
        public  WriteToCSV(List<TradeRecord> trades_, string path_CSV_)
        {
            string patch_CSV = path_CSV_;
            List<TradeRecord> trades = trades_;
        }

        //коструктоp пользовательский_2
        public WriteToCSV( string path_CSV_)
        {
            string patch_CSV = path_CSV_;
            
        }

        public void toCSV()
        {
            
        }
        

        
        //метод 'toCSV' получает коллекцию структурированных данных  и генерирует из нее конечный файл *.CSV , возвращает количество записаных в файл строк
          public int toCSV(List<TradeRecord> trades, string path_CSV)
        {
            int counter = 0;//переменая счетчика
            int counter_ = 0;//переменая счетчика возвращаемая

            
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path_CSV) ) 
                {

                    foreach (TradeRecord t in trades)
                    {
                        file.Write(t.id);
                        file.Write(";");
                        file.Write(t.account);
                        file.Write(";");
                        file.Write(t.volume);
                        file.Write(";");
                        file.Write(t.comment);

                        file.WriteLine(";");

                        counter++;
                        //Console.WriteLine("id: {0}      счет: {1}     уровень: {2}       комментарий: {3} ", t.id, t.account, t.volume, t.comment);
                    }

                    Console.WriteLine();
                    Console.WriteLine(" в файл:   {0}      cконвертировано :   {1} строк ", path_CSV, counter);
                    
                    counter = 0;
                    counter_ = counter;

            }
                      
          return counter_;//возвращаем во вне количество записаных в файл строк
        }
    }
}
