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
        
        //Все транзакции записываются в лист
        List<Transaction> allTransictions = new List<Transaction>();

        //Создание базы данных
        public void CreateDB()
        {
            
            using(UserContext db = new UserContext())
            {
                
                foreach (var transaction in allTransictions)
                {
                    db.Transactions.Add(transaction); 
                    
                }
                db.SaveChanges();
               
            }
        }

        //Чтение Базы Данных
        public void ReadDB()
        {
            //using (PhoneContext db = new PhoneContext())
            //{
            //    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@name", "%Samsung%");
            //    var phones = db.Database.SqlQuery<Phone>("SELECT * FROM Phones WHERE Name LIKE @name", param);
            //    foreach (var phone in phones)
            //        Console.WriteLine(phone.Name);
            //}
            using (UserContext db = new UserContext())
            {
                var test = db.Database.SqlQuery<Transaction>("SELECT * FROM Transactions ");
                foreach (var item in test)
                {
                    Console.WriteLine($"Номер п/п: {item.ID}\t Дата операции: {item.dateOperation}\t " +
                        $"Сумма операции: {item.summaOperation}\t Комментарий: {item.operationСomment}");
                }
                Console.WriteLine(db.Database.Connection.ConnectionString);
            }

        }

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
