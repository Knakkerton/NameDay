using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayLibrary
{
    public class DataReader
    {
        public List<Person> GetNameDayPeople(string date, string filepath)
        {
            List<Person> people = new List<Person>();

            List<string> lines = GetFileLines(filepath);

            foreach (string l in lines)
            {
                Console.WriteLine(l);
                string[] entries = l.Split(';');

                if (entries[0] == date)
                {
                    Person _person = new Person()
                    {
                        Date = entries[0],
                        Name = entries[1]
                    };

                    people.Add(_person);
                }
            }


            return people;
        }
        public List<string> GetFileLines(string filepath)
        {
            List<string> lines = new List<string>();

            try
            {
                lines = File.ReadAllLines(filepath).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }

            return lines;
        }

    }
}
