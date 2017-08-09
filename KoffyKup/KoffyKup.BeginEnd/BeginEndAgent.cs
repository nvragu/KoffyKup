/*
 * "Everything That Has A Beginning Has An End" : Agent Smith
 */

using System;

namespace KoffyKup.BeginEnd
{
    /// <summary>
    /// "Everything That Has A Beginning Has An End" : Agent Smith
    /// </summary>
    public class BeginEndAgent : IBeginEnd
    {
        Action _beginAction; Action _endAction;
        public BeginEndAgent(Action beginAction, Action endAction)
        {
            _beginAction = beginAction; _endAction = endAction;
            Begin();
        }
        public virtual void Begin()
        {
            _beginAction();
        }

        public void Dispose()
        {
            End();
        }

        public virtual void End()
        {
            _endAction();
        }
    }
}
