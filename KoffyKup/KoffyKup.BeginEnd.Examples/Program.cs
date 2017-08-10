using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffyKup.BeginEnd.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            BeginDoEndExample();
            BeginEndAgentExample();
            BeginEndWrapperExample();
            Console.ReadLine();
        }

        private static void BeginEndAgentExample()
        {
            using (new BeginEndAgent(() => Console.WriteLine("1 BeginDoEnd Before Begin"), () => Console.WriteLine("3 BeginDoEnd End")))
            {
                Console.WriteLine("2 BeginDoEnd Began");
            }
        }

        private static void BeginDoEndExample()
        {
            BeginDoEnd.Begin(() =>
               Console.WriteLine("1 BeginDoEnd Before Begin")
           ).Do(() =>
               Console.WriteLine("2 BeginDoEnd Began")
           ).End(() =>
               Console.WriteLine("3 BeginDoEnd End")
           );
        }

        private static void BeginEndWrapperExample()
        {
            using (new Tracer())
            {
                Console.WriteLine("2 BeginEndWrapper Began");
            }
        }
    }
}
