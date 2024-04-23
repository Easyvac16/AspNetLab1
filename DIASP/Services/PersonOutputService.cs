using DIASP.Abstract;
using DIASP.Model;

namespace DIASP.Services
{
    public class PersonOutputService : IPersonOutputService
    {
        public void SaveToFile(Person person, string filePath)
        { 
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(person.ToString());
                sw.WriteLine("*************");
            }
        }

        public List<Person> LoadPerson(string filePath)
        {
            List<Person> persons = new List<Person>();
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (!line.Any(c => c == '*' || c == '?' || c == '%' || c == '$' || c == '#' || c == '@' || c == '!'))
                {
                    string[] parts = line.Split(' ');

                    string name = "", surname = "";
                    int age = 0;

                    for (int i = 0; i < parts.Length; i++)
                    {
                        string partValue = parts[i].Trim().Split(':')[1].Trim();

                        switch (parts[i].Split(':')[0].Trim())
                        {
                            case "Name":
                                name = partValue;
                                break;

                            case "Surname":
                                surname = partValue;
                                break;

                            case "Age":
                                int.TryParse(partValue, out age);
                                break;
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(surname) && age > 0)
                    {
                        persons.Add(new Person
                        {
                            Name = name,
                            Surname = surname,
                            Age = age
                        });
                    }
                }
            }
            return persons;
        }

    }
}
