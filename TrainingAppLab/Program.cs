

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
    }
}

class Organization
{
    public string? Name { get; set; }

    public string GetName()
    {
        return "";
    }
}

class Trainer
{
    public Organization Organization { get; set; } = new Organization();

    public List<Training> Training { get; set; } = new List<Training>();

    public Trainee Trainee { get; set; } = new Trainee();

    public string GetOrganization()
    {
        return "";
    }
}

class Trainee
{
    public List<Training> Training { get; set; } = new List<Training>();
}

abstract class Training
{
    public Course? Course { get; set; }

    public int GetNumberOfTrainee()
    {
        return 0;
    }

    public string GetTrainingOrganizationName()
    {
        return "Test";
    }

    public int GetTrainingDurationInHrs()
    {
        return 1;
    }
}

class Course
{
    public List<Module> Modules = new List<Module>();
    public List<Module> GetCourses()
    {
        return Modules;
    }
}

class Module
{
    public List<Unit> Units = new List<Unit>();
    public List<Unit> GetUnits()
    {
        return Units;
    }
}

class Unit
{
    public int DurationHrs { get; set; }

    public List<Topic> Topics = new List<Topic>();

    public int GetDuration()
    {
        return DurationHrs;
    }
}

class Topic
{
    public string? Name { get; set; }
}
