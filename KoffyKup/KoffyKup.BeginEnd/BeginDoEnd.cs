/*
 * "Everything That Has A Beginning Has An End" : Agent Smith
 */
using System;

namespace KoffyKup.BeginEnd
{
    /// <summary>
    /// "Everything That Has A Beginning Has An End" : Agent Smith
    /// </summary>
    public static class BeginDoEnd
    {
        public static Beginner Begin(Action beginBlock)
        {
            return new Beginner(beginBlock);
        }
    }

    public sealed class Beginner
    {
        Action _beginBlock;
        public Beginner(Action beginBlock)
        {
            _beginBlock = beginBlock;
        }
        public Doer Do(Action doBlock)
        {
            return new Doer(_beginBlock, doBlock);
        }
    }
    public sealed class Doer
    {
        Action _beginBlock, _doBlock;
        public Doer(Action beginBlock, Action doBlock)
        {
            _beginBlock = beginBlock; _doBlock = doBlock;
        }
        public void End(Action endBlock)
        {
            using (new BeginEndAgent(_beginBlock, endBlock))
            {
                _doBlock.Invoke();
            }
        }
    }

}
