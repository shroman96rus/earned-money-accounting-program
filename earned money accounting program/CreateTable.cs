using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace earned_money_accounting_program
{
    class CreateTable
    {

        //Создание XML файла на основе полученных данных
        public void CreateXML(List<Transaction> allTransictions, double acountBalance)
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
            XElement balEllement = new XElement("Summa", acountBalance);
            balance.Add(balNameAttr);
            balance.Add(balEllement);
            tables.Add(balance);
            xdoc.Add(tables);

            xdoc.Save(@"C:\Users\User\Desktop\111\result\tabliza.xml");
        }

        public void CreateXMLForDataBase()
        {
            using (UserContext db = new UserContext())
            {
                var test = db.Database.SqlQuery<Transaction>("SELECT * FROM Transactions");

                XDocument xdoc = new XDocument();
                XElement tables = new XElement("table");
                foreach (var item in test)
                {
                    XElement id = new XElement("Transaction");
                    XAttribute dateNameAttr = new XAttribute("Date", item.dateOperation.ToString("dd.MMMM.yyyy"));
                    XElement operationCountElem = new XElement("Summa", item.summaOperation.ToString());
                    XElement operationNoteElem = new XElement("Comment", item.operationСomment);

                // добавляем атрибут и элементы в первый элемент
                    id.Add(dateNameAttr);
                    id.Add(operationCountElem);
                    id.Add(operationNoteElem);
                    tables.Add(id);
                }
                XElement balance = new XElement("Transaction");
                XAttribute balNameAttr = new XAttribute("Date", "Cумма заработанная на данный момент составляет:");
                var summa = db.Transactions.Sum(p => p.summaOperation);
                XElement balEllement = new XElement("Summa", summa);
                balance.Add(balNameAttr);
                balance.Add(balEllement);
                tables.Add(balance);
                xdoc.Add(tables);

                xdoc.Save(@"C:\Users\User\Desktop\111\result\tabliza Data Base.xml");

                Console.WriteLine("Таблица XML на основе данных из БД создана");

            }
        }

    }
}
