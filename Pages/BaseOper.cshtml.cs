using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sqLiteTest.Pages;

public class BaseOperModel : PageModel
{
    private readonly DataContext _context;

    public BaseOperModel(DataContext context)
    {
        _context = context;
        Person = new Person();
        Persons = new List<Person>();
    }

    [BindProperty]
    public Person Person { get; set; }

    [BindProperty]
    public List<Person> Persons { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Persons.Add(Person);
        await _context.SaveChangesAsync();

        return RedirectToPage("./BaseOper");
    }

    public void OnGet()
    {
        Persons = _context.Persons.ToList<Person>();
    }
}
