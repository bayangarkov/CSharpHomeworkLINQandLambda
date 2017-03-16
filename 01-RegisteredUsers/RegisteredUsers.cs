using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace EmptyProject
{
    class RegisteredUsers
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            var dict = new Dictionary<string, DateTime>();

            while (inputLine != "end")
            {
                var splitted = inputLine.Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var getName = splitted[0];
                var getDate = splitted[1];

                DateTime convertedDate = DateTime.ParseExact(getDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                dict[getName] = convertedDate;

                inputLine = Console.ReadLine();
            }

            var result = dict
                .Reverse()
                .OrderBy(n => n.Value)
                .Take(5)
                .OrderByDescending(n => n.Value);


            foreach (var pair in result)
            {
                var key = pair.Key;
                var val = pair.Value;

                Console.WriteLine($"{key}");
            }
        }
    }
}
