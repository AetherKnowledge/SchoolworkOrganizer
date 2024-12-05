using Newtonsoft.Json.Linq;

namespace Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> subjects = new Dictionary<string, int>();
            subjects.Add("Math", 1);
            subjects.Add("Science", 2);
            subjects.Add("History", 3);
            subjects.Add("English", 4);

            JObject json = new JObject();
            json.Add("username", "JohnDoe");
            json.Add("subjects", JObject.FromObject(subjects));
            Console.WriteLine(json.ToString());

        }
    }
}
