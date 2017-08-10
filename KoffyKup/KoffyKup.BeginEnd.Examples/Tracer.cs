using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffyKup.BeginEnd.Examples
{
    public class Tracer : BeginEndWrapper
    {
        bool _isInitialized = false;
        public Tracer()
        {
            _isInitialized = true;
            Begin();
        }
        public override void Begin()
        {
            if (_isInitialized)
                Console.WriteLine("1 BeginEndWrapper Before Begin");
        }

        public override void End()
        {
            Console.WriteLine("3 BeginEndWrapper End");
        }
    }
}
