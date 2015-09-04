using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int messages = 0; 
            try
            {
                PipeLink.Sender.SendMessage(messages);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}
