using System.Collections;

namespace Higher_or_lower
{
    public class Program
    {
        


        static void Main(string[] args)
        {
            BoxingExample();
        }

        public static string RefAndOutExample(int id)
        {
            // In Main
            //int i = 1;
            //Console.WriteLine("Previous value of integer i:" + i.ToString());
            //string test = GetNextName(i);
            //Console.WriteLine("Current value of integer i:" + i.ToString());

            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }

        public static void BoxingExample()
        {
            // Legacy collection: ArrayList holds 'object'
            ArrayList list = new ArrayList();

            int a = 5;
            double b = 3.14;

            // Boxing: wrap value types into objects
            list.Add(a);      // boxing
            list.Add(b);      // boxing

            // Unboxing: retrieve and cast back to exact types
            int a2 = (int)list[0];       // unboxing
            double b2 = (double)list[1]; // unboxing

            Console.WriteLine(a2 * 2);   // 10
            Console.WriteLine(b2 + 1);   // 4.14

        }
    }
}
