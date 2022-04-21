using Microsoft.EntityFrameworkCore;

namespace sqLiteTest.Pages;

public class DataContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public string DbPath { get; }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        // var folder = Environment.SpecialFolder.LocalApplicationData;
        // var path = Environment.GetFolderPath(folder);
        DbPath = "Data/base.db";
        //DbPath = System.IO.Path.Join(path, "base.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public Person(string Name = "", string Surname = "", int Age = 0)
    {
        this.Name = Name;
        this.Surname = Surname;
        this.Age = Age;
    }

    public Person()
    {
        this.Name = "";
        this.Surname = "";
        this.Age = 0;
    }
}