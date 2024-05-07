using System;

// Інтерфейси користувача
public interface IUserInterface
{
    void DisplayUserInterface();
}

// Інтерфейси .NET
public interface IDotNetInterface
{
    void DotNetFunctionality();
}

// Базовий клас - Організація
public class Organization : IUserInterface
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Employees { get; set; }

    // Конструктори
    public Organization() : this("Невідомо", "Невідомий", 0) { }

    public Organization(string name, string type, int employees)
    {
        Name = name;
        Type = type;
        Employees = employees;
        Console.WriteLine($"Конструктор Organization для {Name}");
    }

    // Деструктор
    ~Organization()
    {
        Console.WriteLine($"Деструктор Organization для {Name}");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Назва: {Name}");
        Console.WriteLine($"Тип: {Type}");
        Console.WriteLine($"Кількість співробітників: {Employees}");
    }

    public virtual void DisplayUserInterface()
    {
        Console.WriteLine("Організаційний інтерфейс користувача");
    }
}

// Похідний клас - Страхова компанія
public class InsuranceCompany : Organization, IDotNetInterface
{
    public string? InsuranceType { get; set; }

    // Конструктори
    public InsuranceCompany() : base() { }

    public InsuranceCompany(string name, string type, int employees, string insuranceType)
        : base(name, type, employees)
    {
        InsuranceType = insuranceType;
        Console.WriteLine($"Конструктор InsuranceCompany для {Name}");
    }

    // Деструктор
    ~InsuranceCompany()
    {
        Console.WriteLine($"Деструктор InsuranceCompany для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип страхування: {InsuranceType}");
    }

    public void DotNetFunctionality()
    {
        Console.WriteLine("Функціональність .NET для страхової компанії");
    }
}

// Похідний клас - Нафтогазова компанія
public class OilGasCompany : Organization, IDotNetInterface
{
    public string? Industry { get; set; }

    // Конструктори
    public OilGasCompany() : base() { }

    public OilGasCompany(string name, string type, int employees, string industry)
        : base(name, type, employees)
    {
        Industry = industry;
        Console.WriteLine($"Конструктор OilGasCompany для {Name}");
    }

    // Деструктор
    ~OilGasCompany()
    {
        Console.WriteLine($"Деструктор OilGasCompany для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Галузь: {Industry}");
    }

    public void DotNetFunctionality()
    {
        Console.WriteLine("Функціональність .NET для нафтогазової компанії");
    }
}

// Похідний клас - Завод
public class Factory : Organization, IDotNetInterface
{
    public string? ProductionType { get; set; }

    // Конструктори
    public Factory() : base() { }

    public Factory(string name, string type, int employees, string productionType)
        : base(name, type, employees)
    {
        ProductionType = productionType;
        Console.WriteLine($"Конструктор Factory для {Name}");
    }

    // Деструктор
    ~Factory()
    {
        Console.WriteLine($"Деструктор Factory для {Name}");
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип виробництва: {ProductionType}");
    }

    public void DotNetFunctionality()
    {
        Console.WriteLine("Функціональність .NET для заводу");
    }
}


/////////////////////////////////////////////////////////////////////////

// Інтерфейс для персони
public interface IPersona
{
    void ShowInfo();
    int CalculateAge();
}

// Базовий клас - Персона
public abstract class Person : IPersona
{
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Faculty { get; set; }



    // Конструктор
    public Person(string lastName, DateTime birthDate, string faculty)
    {
        LastName = lastName;
        BirthDate = birthDate;
        Faculty = faculty;
    }

    // Метод для виведення інформації
    public virtual void ShowInfo()
    {
        Console.WriteLine($"Прізвище: {LastName}");
        Console.WriteLine($"Дата народження: {BirthDate.ToShortDateString()}");
        Console.WriteLine($"Факультет: {Faculty}");
    }

    // Метод для визначення віку
    public int CalculateAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - BirthDate.Year;
        if (today < BirthDate.AddYears(age))
            age--;
        return age;
    }
}

// Похідний клас - Абітурієнт
public class Applicant : Person
{
    // Конструктор
    public Applicant(string lastName, DateTime birthDate, string faculty)
        : base(lastName, birthDate, faculty)
    {
    }

    // Перевизначений метод для виведення інформації
    public override void ShowInfo()
    {
        Console.WriteLine("Інформація про абітурієнта:");
        base.ShowInfo();
    }
}

// Похідний клас - Студент
public class Student : Person
{
    public int Course { get; set; }

    // Конструктор
    public Student(string lastName, DateTime birthDate, string faculty, int course)
        : base(lastName, birthDate, faculty)
    {
        Course = course;
    }

    // Перевизначений метод для виведення інформації
    public override void ShowInfo()
    {
        Console.WriteLine("Інформація про студента:");
        base.ShowInfo();
        Console.WriteLine($"Курс: {Course}");
    }
}

// Похідний клас - Викладач
public class Teacher : Person
{
    public string Position { get; set; }
    public int Experience { get; set; }

    // Конструктор
    public Teacher(string lastName, DateTime birthDate, string faculty, string position, int experience)
        : base(lastName, birthDate, faculty)
    {
        Position = position;
        Experience = experience;
    }

    // Перевизначений метод для виведення інформації
    public override void ShowInfo()
    {
        Console.WriteLine("Інформація про викладача:");
        base.ShowInfo();
        Console.WriteLine($"Посада: {Position}");
        Console.WriteLine($"Стаж: {Experience} років");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("\t\t\tTask 1 ");
        Console.WriteLine("Створення об'єктів організацій:");
        InsuranceCompany? insuranceCompany = new InsuranceCompany("Страхова Компанія \"Підкова\"", "Фінанси", 100, "Медичне");
        OilGasCompany? oilGasCompany = new OilGasCompany("Нафтогазова Компанія \"ГазЕкспорт\"", "Енергетика", 500, "Нафтова та газова");
        Factory? factory = new Factory("Завод \"ТехноПласт\"", "Виробництво", 250, "Пластикові вироби");

        Console.WriteLine("\nВиведення інформації про організації:");
        Console.WriteLine("Інформація про страхову компанію:");
        insuranceCompany.Show();
        insuranceCompany.DotNetFunctionality();
        Console.WriteLine("\nІнформація про нафтогазову компанію:");
        oilGasCompany.Show();
        oilGasCompany.DotNetFunctionality();
        Console.WriteLine("\nІнформація про завод:");
        factory.Show();
        factory.DotNetFunctionality();

        Console.WriteLine("\nВидаляємо об'єкти:");
        insuranceCompany = null;
        oilGasCompany = null;
        factory = null;
        GC.Collect();

        //////////////////////////////////////////////////////////////

        Console.WriteLine("\t\t\tTask 2");
        Console.WriteLine("Створення об'єктів:");
        Applicant applicant = new("Петров", new DateTime(2002, 5, 15), "Фізика");
        Student student = new("Іванов", new DateTime(2000, 10, 25), "Інформатика", 2);
        Teacher teacher = new("Сидорова", new DateTime(1975, 3, 8), "Математика", "Доцент", 15);


        Console.WriteLine("\nВиведення інформації:");
        applicant.ShowInfo();
        Console.WriteLine();
        student.ShowInfo();
        Console.WriteLine();
        teacher.ShowInfo();

        Console.WriteLine("\nВік абітурієнта: " + applicant.CalculateAge());
        Console.WriteLine("Вік студента: " + student.CalculateAge());
        Console.WriteLine("Вік викладача: " + teacher.CalculateAge());

        Console.WriteLine("\nСтворення бази з персон:");
        Person[] persons = new Person[]
        {
            new Applicant("Петров", new DateTime(2002, 5, 15), "Фізика"),
            new Student("Іванов", new DateTime(2000, 10, 25), "Інформатика", 2),
            new Teacher("Сидорова", new DateTime(1975, 3, 8), "Математика", "Доцент", 15),
            new Student("Петрова", new DateTime(2001, 8, 12), "Інформатика", 3),
            new Teacher("Іванова", new DateTime(1980, 7, 20), "Математика", "Професор", 20)
        };

        Console.WriteLine("\nПовна інформація з бази:");
        foreach (var person in persons)
        {
            person.ShowInfo();
            Console.WriteLine();
        }

        Console.WriteLine("\nПошук персон за вказаним діапазоном віку (20-30 років):");
        int minAge = 20;
        int maxAge = 30;
        foreach (var person in persons)
        {
            int age = person.CalculateAge();
            if (age >= minAge && age <= maxAge)
            {
                person.ShowInfo();
                Console.WriteLine($"Вік: {age}");
                Console.WriteLine();
            }
        }
    }
}