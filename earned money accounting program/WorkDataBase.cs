using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    //Освежить данные по разделу Enum
    enum Month
    {
        Январь = 1,
        Февраль = 2,



    }

    class WorkDataBase
    {
        //Чтение Базы Данных
        public void ReadDB()
        {
            using (UserContext db = new UserContext())
            {
                var test = db.Database.SqlQuery<Transaction>("SELECT * FROM Transactions");

                Console.WriteLine("Номер п/п\t |Дата операции\t |Сумма операции\t|Комментарий");
                foreach (var item in test)
                {
                    Console.WriteLine($"{item.ID}\t\t |{item.dateOperation.ToString("dd.MMMM.yyyy")}\t " +
                        $"|{item.summaOperation}\t\t\t|{item.operationСomment}");
                }
                Console.WriteLine(db.Database.Connection.ConnectionString);
            }

        }

        public void WorkDB()
        {
            using (UserContext db = new UserContext())
            {
                DateTime month = new DateTime();
                month = Convert.ToDateTime("01.08.2020");
                var test = db.Database.SqlQuery<Transaction>("SELECT * FROM Transactions").Where(i => i.dateOperation > month);
                Console.WriteLine("Номер п/п\t |Дата операции\t |Сумма операции\t|Комментарий");
                foreach (var item in test)
                {
                    Console.WriteLine($"{item.ID}\t\t |{item.dateOperation.ToString("dd.MMMM.yyyy")}\t " +
                        $"|{item.summaOperation}\t\t\t|{item.operationСomment}");
                }
                Console.WriteLine(db.Database.Connection.ConnectionString);




            }
        }
    }
}
