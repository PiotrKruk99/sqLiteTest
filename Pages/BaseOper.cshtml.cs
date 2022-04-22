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

    public async Task<IActionResult> OnPostDeleteAsync()
    {
        var personId = Convert.ToInt32(Request.Form["personId"]);
        _context.Remove<Person>(_context.Persons.First<Person>(x => x.PersonId == personId));
        await _context.SaveChangesAsync();

        return RedirectToPage("./BaseOper");
    }

    public void OnPostEdit()
    {
        var personId = Convert.ToInt32(Request.Form["personId"]);
        Person = _context.Persons.First<Person>(x => x.PersonId == personId);

        Persons = _context.Persons.ToList<Person>();
    }

    public async Task<IActionResult> OnPostModifyAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var personId = Convert.ToInt32(Request.Form["personId"]);
        Person.PersonId = personId;
        _context.Persons.Update(Person);
        await _context.SaveChangesAsync();

        return RedirectToPage("./BaseOper");
    }

    public void OnGet()
    {
        Persons = _context.Persons.ToList<Person>();
    }
}
