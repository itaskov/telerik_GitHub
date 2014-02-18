using System;

public class Student : IComparable<Student>
{
    private string name;

    private int id;

    public Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public string Name
    {
        get 
        { 
            return this.name; 
        }

        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid value!", "name");
            }

            this.name = value;
        }
    }

    public int Id
    {
        get 
        { 
            return this.id; 
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Cannot be null negative!", "egn");
            }

            if (value.ToString().Length > 5)
            {
                throw new ArgumentException("Invalid length!", "egn");
            }

            this.id = value;
        }
    }

    public int Number { get; private set; }

    public void Enrol(School school)
    {
        if (school == null)
        {
            throw new NullReferenceException("School cannot be null!");
        }
        
        this.Number = school.EnrolStudent(this);
    }

    public override string ToString()
    {
        return string.Format(
            "Student name: {0} id: {1} number: {2}", 
            this.name, 
            this.id,
            this.Number == 0 ? "[]" : this.Number.ToString());
    }

    public int CompareTo(Student student)
    {
        return this.id.CompareTo(student.id);
    }
}