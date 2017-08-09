/*
 * Everything That Has A Beginning Has An End : Agent Smith
 */

using System;

namespace KoffyKup.BeginEnd
{
    public class BeginEnd<T> : IBeginEnd<T>
    {
        T _instance; Action<T> _beginAction; Action<T> _endAction;
        public BeginEnd(T instance, Action<T> beginAction, Action<T> endAction)
        {
            _instance = instance; _beginAction = beginAction; _endAction = endAction;
            Begin();
        }
        public virtual void Begin()
        {
            _beginAction(_instance);
        }

        public void Dispose()
        {
            End();
        }

        public virtual void End()
        {
            _endAction(_instance);
        }
    }
}
