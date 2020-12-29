using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace earned_money_accounting_program
{
    class WriteText
    {

        //Создание текстового документа на основе полученных данных
        public void TextCreate(string translation)
        {
            FileInfo file = new FileInfo(@"C:\Users\User\Desktop\111\result\test.txt");
            if (file.Exists)
            {
                // запись в существующий файл
                using (StreamWriter sw = new StreamWriter(@"C:\Users\User\Desktop\111\result\test.txt", true))
                {
                    sw.WriteLine("\nДата\t\tСумма\tКомментарий\n");
                    sw.WriteLine(translation);
                    sw.Close();
                }

            }
            else
            {
                //создать новый файл
                string writePut = @"C:\Users\User\Desktop\111\result\test.txt";
                using (StreamWriter sw = new StreamWriter(writePut))
                {
                    sw.WriteLine("Дата\t\tСумма\tКомментарий");
                    sw.WriteLine(translation);
                    sw.Close();
                }

            }
        }

    }
}
