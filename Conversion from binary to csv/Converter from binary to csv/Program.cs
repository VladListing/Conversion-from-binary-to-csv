using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_from_binary_to_csv
{
    class Program
    {
       

        
        

        static void Main(string[] args) 
        {


            try

            {
                //класс 'ConvertigBinaryToCSV' вычитывает данные из бинарного файла и генерирует конечный файл *.CSV   
                ConvertingBinaryToCSV convertingBinaryToCSV = new ConvertingBinaryToCSV();
                int result;
                List<TradeRecord> Collektion = convertingBinaryToCSV.fromBinaryFile(out result);
                convertingBinaryToCSV.toCSV(Collektion);


                // класс 'ConvertigBinaryToCSV' вычитывает данные из бинарного файла и генерирует конечный файл *.CSV
                //ConvertingBinaryToCSV convertingBinaryToCSV = new ConvertingBinaryToCSV();
                //convertingBinaryToCSV();
                //int result;
                //List<TradeRecord> Collektion = convertingBinaryToCSV.fromBinaryFile( out result);
                //convertingBinaryToCSV.toCSV(Collektion);

            }

            //сообщения о возникшем исключении
            catch (Exception m)
            {
                Console.WriteLine(m.Message);
            }
            Console.ReadLine();
           

        }
    }
}
