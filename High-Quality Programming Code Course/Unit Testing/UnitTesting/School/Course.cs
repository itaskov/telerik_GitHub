using System;
using System.Collections.Generic;
using System.Text;

public class Course
{
    private const int MAX_STUDENT_COUNT = 29;
    
    private string name;

    private int currentStudentCount;

    private List<Student> studentsList = new List<Student>();

    public Course(string name)
    {
        this.Name = name;
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

    public bool Join(Student student)
    {
        bool joined = true;
        if (student.Number == 0)
        {
            throw new ArgumentException("Student must be enrolled in school first!", "student.Number");
        }

        if (this.currentStudentCount > MAX_STUDENT_COUNT)
        {
            joined = false;
            return joined;
        }

        this.studentsList.Add(student);
        this.currentStudentCount++;
        
        return joined;
    }

    public bool Leave(Student student)
    {
        bool leaved = true;
        if (this.studentsList.Contains(student))
        {
            this.studentsList.Remove(student);
            this.currentStudentCount--;
        }
        else
        {
            throw new ArgumentException("Cannot leave before join.", "student");
        }

        return leaved;
    }

    public int GetAvailablePositions()
    {
        return MAX_STUDENT_COUNT - this.currentStudentCount;
    }

    public override string ToString()
    {
        return string.Join("\n", this.studentsList);
    }
}