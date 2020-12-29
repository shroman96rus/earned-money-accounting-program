using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    public class Transaction
    {
        //Оюьявление переменных (комент к операции, сумма операции, дата операции)
       
        public int ID { get; set; }
        public string operationСomment { get; set; }
        public double summaOperation { get; set; }
        public DateTime dateOperation { get; set; }

        //Создаем конструктор
        public Transaction(DateTime dateOperation, double summaOperation, string operationСomment)
        {
            this.dateOperation = dateOperation;
            this.summaOperation = summaOperation;
            this.operationСomment = operationСomment;
        }

        public Transaction()
        {
            
        }
    }
}
