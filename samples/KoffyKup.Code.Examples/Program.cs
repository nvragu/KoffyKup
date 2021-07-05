using KoffyKup.Code;
using System;
namespace KoffyKup.BeginEnd.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeExternsionsExample();
            Console.ReadLine();
        }

        private static void CodeExternsionsExample()
        {
            CodeExtensions.Code(
            () =>
            {
                var i = 100;
                i++;
                throw new Exception("General exception");
            }
            ).MeasureTime((x) => Console.WriteLine(x.CpuTime))
            .HandleException((ex) => Console.WriteLine(ex.Message))
            .PreAndPost(() => Console.WriteLine("PreAction"), () => Console.WriteLine("PostAction"))
            ();
        }
    }
}
