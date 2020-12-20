using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace earned_money_accounting_program
{
    class Account
    {
        public string name { get; set; }
        //Баланс оптеделется тем, что сумма баланса вычисляется в методе get путем добавления туда данных из листа alltransaction
        public double balance
        {
            get
            {
               double balance = 0;
                foreach (var item in allTransictions)
                {
                    balance += item.summaOperation;
                }

                return balance;
            }

        }
        

        //Конструктор создания акаунта
        public Account(string name)
        {
            this.name = name;
        }

        List<Transaction> allTransictions = new List<Transaction>();

        //Метод отвечающий за пополнение баланса при оплате за работу
        public void PayForWork(DateTime date, double payment, string note)
        {
            var pay = new Transaction(date, payment, note);
            allTransictions.Add(pay);
            
        }

        //Метод отвечающий за уменьшение баланса при оплате различных услуг
        public void PaymentForWork(DateTime date, double payment, string note)
        {
        
            var pay = new Transaction(date, -payment, note);
            allTransictions.Add(pay);
        
        }
        
        //вывод истории всех операций
        public void history()
        {
            StringBuilder transactionHistory = new StringBuilder();
            double balance = 0;
            foreach (var item in allTransictions)
            {
                transactionHistory.Append($"{item.dateOperation.ToString("dd.MMM.yyyy")}\t{item.summaOperation}\t{item.operationСomment}\n");
                balance += item.summaOperation;
            }
            transactionHistory.Append($"Cумма заработанная на данный момент составляет:\t {balance}");
            Console.WriteLine(transactionHistory.ToString());
            TextCreate(transactionHistory.ToString());
        }

        //Создание XML файла на основе полученных данных
        public void CreateTable()
        {

            XDocument xdoc = new XDocument();
            XElement tables = new XElement("table");
            foreach (var item in allTransictions)
            {
                XElement id = new XElement("Transaction");
                XAttribute dateNameAttr = new XAttribute("Date", item.dateOperation.ToString("dd.MMMM.yyyy"));
                XElement operationCountElem = new XElement("Summa", item.summaOperation.ToString());
                XElement operationNoteElem = new XElement("Comment", item.operationСomment);
                

                //// добавляем атрибут и элементы в первый элемент
                id.Add(dateNameAttr);
                id.Add(operationCountElem);
                id.Add(operationNoteElem);
                tables.Add(id);
            }
            XElement balance = new XElement("Transaction");
            XAttribute balNameAttr = new XAttribute("Date", "Cумма заработанная на данный момент составляет:");
            XElement balEllement = new XElement("Summa", this.balance);
            balance.Add(balNameAttr);
            balance.Add(balEllement);
            tables.Add(balance);
            xdoc.Add(tables);

            xdoc.Save(@"C:\Users\User\Desktop\111\result\tabliza.xml");
        }

        //Создание текстового документа на основе полученных данных
        public void TextCreate(string translation)
        {
            
            FileInfo file = new FileInfo(@"C:\Users\User\Desktop\111\result\test.txt");
            if (file.Exists)
            {
                // запись в файл
                using (FileStream fstream = new FileStream(@"C:\Users\User\Desktop\111\result\test.txt", FileMode.Append))
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(translation);
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                    byte[] arrayn = System.Text.Encoding.Default.GetBytes("\n");
                    fstream.Write(array, 0, arrayn.Length);
                }
                
            }
            else
            {
                string writePut = @"C:\Users\User\Desktop\111\result\test.txt";
                using (StreamWriter sw = new StreamWriter(writePut))
                {
                    sw.WriteLine("Дата\t||\tСумма\t||Комментарий");
                    sw.WriteLine(translation);
                    sw.WriteLine("This is a test");
                    sw.Close();
                } 
                
            }

            

        }

        //Чтение входящих данных из текстового файла
        public void TextRead()
        {
            string readPut = @"C:\Users\User\Desktop\111\input\user.txt";
            StreamReader sr = new StreamReader(readPut);
            string textDocument;
            while ((textDocument = sr.ReadLine())!= null)
            {
                string[] array = textDocument.Split('\t');
                DateTime date = new DateTime();
                double summa;
                string note;
                date = Convert.ToDateTime(array[0]);
                summa = Convert.ToDouble(array[1]);
                note = array[2];
                if (summa < 0)
                {
                    PaymentForWork(date, -summa, note);
                }
                else
                {
                    PayForWork(date, summa, note);
                }
            }
            Console.WriteLine(textDocument);
        }

        public void PrintAccount()
        {
            Console.WriteLine("Созданный аккаунт называется:\t {0}", this.name);
        }


    }
}
