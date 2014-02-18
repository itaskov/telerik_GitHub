using System;

public class SchoolSystem
{
    public static void Main()
    {
        School uzu = new School("South-West University");

        Student s1 = new Student("Ivan Taskov", 78070);
        s1.Enrol(uzu);

        Student s2 = new Student("Pesho Peshev", 88031);
        s2.Enrol(uzu);

        Student s3 = new Student("Iva Ivanova", 82041);

        Console.WriteLine("students:");
        Console.WriteLine(s1);
        Console.WriteLine(s2);
        Console.WriteLine(s3);
        Console.WriteLine();

        Console.WriteLine("school:");
        Console.WriteLine(uzu);
        Console.WriteLine();

        Course hqc = new Course("High quality code");
        hqc.Join(s1);
        hqc.Join(s2);
        ////hqc.Join(s3);

        hqc.Leave(s1);

        Console.WriteLine("course:");
        Console.WriteLine(hqc);
    }
}