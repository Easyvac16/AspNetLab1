using DIASP.Abstract;
using DIASP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIASP.Pages
{
    public class PersonModel : PageModel
    {
        private readonly IPersonOutputService _personOutputService;
        public Person Person { get; set; }

        public List<Person> Persons { get; set; } = new List<Person>();

        public PersonModel(IPersonOutputService personOutputService)
        {
            _personOutputService = personOutputService;
        }
        public void OnGet() 
        {
            /*Person = new Person()
            {
                Age = 15,
                Surname = "tes2t",
                Name = "test2",
            };

            _personOutputService.SaveToFile(Person, "person.txt");*/
            Persons = _personOutputService.LoadPerson("person.txt");

        }
    }
}
