using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace grade_scores
{
    public class Person
    {
        public string lastName;
        public string firstName;
        public int grade;
        public Person(string ln, string fn, int gr)
        {
            lastName = ln;
            firstName = fn;
            grade = gr;
        }

        static public List<Person> sort(List<Person> list)
        {
            var outList = list.OrderByDescending(x => x.grade)
                .ThenBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList<Person>();
            return outList;
        }

        public static void Main(string[] args)
        {
            //check argument,
            if (!args.Any()) Trace.TraceError("Usage: grade-score input");
            var path = args[0];
            //check input file,
            if (!File.Exists(path))
            {
                Trace.TraceError("input file not found:" + path);
                throw new FileNotFoundException();
            }
            TextReader txread = File.OpenText(path);

            List<Person> list = new List<Person>();
            for (string line; (line = txread.ReadLine()) != null;)
            {
                string[] data = line.Split(',');
                if (data.Length != 3) Trace.TraceError(String.Format("not enough fields in file input: {0} , prog exit.", line));
                try
                {
                    int grade = Int32.Parse(data[2]);
                    Person p = new Person(data[0].Trim(), data[1].Trim(), grade);
                    list.Add(p);
                }
                catch (FormatException e)
                {
                    Trace.TraceError(String.Format("grade field input format error : {0} ;", data[2]) + e.Message);
                }
            }
            //order by grade, lastName, then firstName:
            StreamWriter fOut = new StreamWriter(@"names-graded.txt", false);
            var newList = Person.sort(list);
            foreach (var p in newList)
            {
                Console.WriteLine("{0}, {1}, {2}", p.lastName, p.firstName, p.grade);
                fOut.WriteLine("{0}, {1}, {2}", p.lastName, p.firstName, p.grade);
            }
            fOut.Flush();
            fOut.Close();
            Console.WriteLine("Finished: created names-graded.txt ");
        }
    }
}
