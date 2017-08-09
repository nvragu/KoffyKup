
namespace KoffyKup.BeginEnd
{
    public class SampleUsage
    {
        public SampleUsage()
        {
            var message = "Before";
            using (new BeginEnd<string>(message, x => x = "Began", x => x = "After End"))
            {

            }
        }
    }

}