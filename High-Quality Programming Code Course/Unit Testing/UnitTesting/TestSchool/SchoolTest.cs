using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestSchoolCreate()
        {
            School school = new School("uzu");
            Assert.AreEqual("uzu", school.Name);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestSchoolCreateNullName()
        {
            School school = new School(null);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestSchoolCreateEmptyName()
        {
            School school = new School("   ");
        }

        [TestMethod]
        public void TestSchoolEnrolStudent()
        {
            School school = new School("uzu");
            Student s = new Student("Ivan", 11111);
            school.EnrolStudent(s);
            Assert.AreEqual(1, school.StudentsCount);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestSchoolEnrolNullStudent()
        {
            School school = new School("uzu");
            school.EnrolStudent(null);
            Assert.AreEqual(1, school.StudentsCount);
        }

        [TestMethod]
        public void TestSchoolCurrentNumber()
        {
            School school = new School("uzu");
            Student s1 = new Student("Ivan", 11111);
            Student s2 = new Student("Pesho", 1112);
            school.EnrolStudent(s1);
            school.EnrolStudent(s2);
            Assert.AreEqual(10002, school.CurrentNumber);
        }

        [TestMethod]
        public void TestSchoolEnrolMaxNumberOfStudent()
        {
            School school = new School("uzu");
            int numberOfStudents = School.MAX_NUMBER - School.MIN_NUMBER + 1;
            for (int i = 1; i <= numberOfStudents; i++)
            {
                Student s = new Student("Ivan", i);
                school.EnrolStudent(s);
            }
            Assert.AreEqual(numberOfStudents, school.StudentsCount);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestSchoolEnrolMoreThanMaxNumberOfStudent()
        {
            School school = new School("uzu");
            int numberOfStudents = School.MAX_NUMBER - School.MIN_NUMBER + 1;
            numberOfStudents++;
            for (int i = 1; i <= numberOfStudents; i++)
            {
                Student s = new Student("Ivan", i);
                school.EnrolStudent(s);
            }
            Assert.AreEqual(numberOfStudents, school.StudentsCount);
        }

        [TestMethod]
        public void TestSchoolToString()
        {
            Student s = new Student("Ivan", 11111);
            Assert.AreEqual(
                string.Format("Student name: {0} id: {1} number: {2}", s.Name, s.Id, "[]"),
                s.ToString());
        }

        [TestMethod]
        public void TestSchoolToStringEnroledStudent()
        {
            School school = new School("uzu");
            Student s = new Student("Ivan", 11111);
            s.Enrol(school);
            Assert.AreEqual(
                string.Format("Student name: {0} id: {1} number: {2}", s.Name, s.Id, s.Number),
                s.ToString());
        }
    }
}
