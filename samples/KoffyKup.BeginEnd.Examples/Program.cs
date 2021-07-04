using KoffyKup.Code;
using System;
namespace KoffyKup.BeginEnd.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeExternsionsTest();
            BeginDoEndExample();
            BeginEndAgentExample();
            BeginEndWrapperExample();
            Console.ReadLine();
        }

        private static void CodeExternsionsTest()
        {
            CodeExtensions.Code(
            () =>
            {
                var i = 100;
                i++;
            }
            ).MeasureTime((x) => Console.WriteLine(x.CpuTime))
            .HandleException((ex) => Console.WriteLine(ex.Message))
            .PreAndPost(() => Console.WriteLine("PreAction"), () => Console.WriteLine("PostAction"))
            ();
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
