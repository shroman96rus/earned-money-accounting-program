using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace earned_money_accounting_program
{
    class For_lessons
    {

        public DateTime test  { get; set; }

        //For_lessons(DateTime test)
        //{
        //    this.test = test;
        //}

        public void printDT()
        {
            Console.WriteLine(test.ToString("dd,MMM,yy"));
        }

    }
}
