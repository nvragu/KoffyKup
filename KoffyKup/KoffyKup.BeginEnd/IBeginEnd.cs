using System;
namespace KoffyKup.BeginEnd
{
    public interface IBeginEnd : IDisposable
    {
        void Begin();
        void End();
    }

    public interface IBeginEnd<T> : IBeginEnd
    {
    }
}