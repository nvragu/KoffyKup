using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoffyKup.BeginEnd.Test
{
    public class Tracer : BeginEndWrapper
    {
        List<string> _messages;
        bool _isInitialized = false;
        public Tracer(List<string> messages)
        {
            _messages = messages;
            _isInitialized = true;
            base.Begin();
        }
        public override void Begin()
        {
            if(_isInitialized)
                _messages.Add("Begin");
        }

        public override void End()
        {
            _messages.Add("End");
        }
    }
}
