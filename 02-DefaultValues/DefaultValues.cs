using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DefaultValues
{
    class DefaultValues
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var dict = new Dictionary<string, string>();

            while (inputLine != "end")
            {
                var splitted = inputLine.Split(new[] {'-', '>', ' '}, StringSplitOptions.RemoveEmptyEntries);

                var getFirst = splitted[0];
                var getSecond = splitted[1];

               
                if (dict.ContainsKey(getFirst))
                {
                    dict[getFirst] = getSecond;
                }
                else
                {
                    dict.Add(getFirst, getSecond);
                }

                inputLine = Console.ReadLine();
            }

            var defaultValue = Console.ReadLine();

            Console.WriteLine();

            var withoutNull = dict
                .Where(w => !w.Value.Contains("null"))
                .OrderByDescending(w => w.Value.Length)
                .ToDictionary(w => w.Key, w => w.Value);


            var replaced = dict
                .Where(w => w.Value.Contains("null"))
                .ToDictionary(w => w.Key, w => defaultValue);

            foreach (var pair in withoutNull)
            {
                var key = pair.Key;
                var val = pair.Value;

                Console.WriteLine($"{key} <-> {val}");
            }

            foreach (var pair in replaced)
            {
                var key = pair.Key;
                var val = pair.Value;

                Console.WriteLine($"{key} <-> {val}");
            }
        }
    }
}
