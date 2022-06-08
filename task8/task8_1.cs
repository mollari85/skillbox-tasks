using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class task8_1
    {
        private List<int> Numbers;
        private Random rn = new Random(DateTime.Now.Millisecond);
        public task8_1()
        {
            createList();
        }
        private void createList(int length=100)
        {
            Numbers = new List<int>();
            for (int i = 0; i <length; i++)
                 Numbers.Add(rn.Next(0, 100));
               // Numbers.Add(i);
        }
        public void PrintList()
        {
            int length = 10;
            int i = 0;
            while(i<Numbers.Count)
            {
               Console.Write($"{Numbers[i],4}");
                i++;
               if (i%length==0 & i!=0) Console.WriteLine();

            }
            Console.WriteLine();
        }
            public void DeleteNumbers(int min=25, int max=50)
        {
            Numbers.RemoveAll(i => i > min & i < max);
        }
                
        
    }
}
