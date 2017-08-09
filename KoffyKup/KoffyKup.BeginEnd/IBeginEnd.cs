using System;
namespace KoffyKup.BeginEnd
{
    public interface IBeginEnd : IDisposable
    {
        void Begin();
        void End();
    }

}