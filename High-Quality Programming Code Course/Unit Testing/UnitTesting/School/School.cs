using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class School
{
    public const int MIN_NUMBER = 10000;

    public const int MAX_NUMBER = 99999;

    private int currentNumber = MIN_NUMBER;

    private string name;

    private SortedList<int, Student> studentsList = new SortedList<int, Student>();

    public School(string name)
    {
        this.Name = name;
    }

    public int CurrentNumber
    {
        get { return this.currentNumber; }
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
                throw new ArgumentException("Cannot be null or empty!", "name");
            }

            this.name = value;
        }
    }
    
    public int StudentsCount
    {
        get
        {
            return this.studentsList.Count;
        }
    }

    public Student this[int index]
    {
        get
        {
            if ((index < 0) || (index >= this.studentsList.Count))
            {
                throw new ArgumentException("Invalid account index.");
            }

            Student student = this.studentsList.Values[index];
            return student;
        }
    }

    public int EnrolStudent(Student newStudent)
    {
        if (newStudent == null)
        {
            throw new NullReferenceException("Param newStudent cannot be null!");
        }
        
        if (this.currentNumber > MAX_NUMBER)
        {
            throw new ArgumentException("Max student number has reached!", "MAX_NUMBER");
        }

        bool isIdExists = this.studentsList.ContainsKey(newStudent.Id);
        if (isIdExists)
        {
            throw new ArgumentException("Duplicated egn!", "newStudent.Egn");
        }
        
        this.studentsList.Add(newStudent.Id, newStudent);
        int studentNumber = this.currentNumber;
        this.currentNumber++;

        return studentNumber;
    }

    public override string ToString()
    {
        return string.Join("\n", this.studentsList.Values);
    }
}