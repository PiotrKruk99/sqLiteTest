using Microsoft.EntityFrameworkCore;

namespace sqLiteTest.Pages;

public class DataContext : DbContext
{
    public DbSet<Person>? Persons { get; set; }

    public string DbPath { get; }

    public DataContext()
    {
        DbPath = @"/Data/base.db";
    }
}

public class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Person(string Name, string Surname, int Age)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.Age = Age;
    }
}