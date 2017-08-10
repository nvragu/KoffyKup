/*
 * "Everything That Has A Beginning Has An End" : Agent Smith
 */
namespace KoffyKup.BeginEnd
{
    /// <summary>
    /// "Everything That Has A Beginning Has An End" : Agent Smith
    /// </summary>
    public class BeginEndWrapper : IBeginEnd
    {
        public BeginEndWrapper()
        {
            Begin();
        }
        public virtual void Begin()
        {
            ;
        }

        public void Dispose()
        {
            End();
        }

        public virtual void End()
        {
            ;
        }
    }
}
