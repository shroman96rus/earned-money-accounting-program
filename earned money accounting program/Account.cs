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
        private string name { get; set; }
        //Баланс оптеделется тем, что сумма баланса вычисляется в методе get путем добавления туда данных из листа alltransaction
        private double balance
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
            double balance = 0;

            StringBuilder transactionHistory = new StringBuilder();
           
            foreach (var item in allTransictions)
            {
                transactionHistory.Append($"{item.dateOperation.ToString("dd.MMM.yyyy")}\t{item.summaOperation}\t{item.operationСomment}\n");
                balance += item.summaOperation;
            }
            
            transactionHistory.Append($"Cумма заработанная на данный момент составляет:\t {balance}");
            
            Console.WriteLine(transactionHistory.ToString());

            //Создание текстового документа
            WriteText textCreate = new WriteText();
            textCreate.TextCreate(transactionHistory.ToString());

            //Создание таблицы XML
            CreateTable XML = new CreateTable();
            XML.CreateXML(allTransictions, this.balance);
            
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
