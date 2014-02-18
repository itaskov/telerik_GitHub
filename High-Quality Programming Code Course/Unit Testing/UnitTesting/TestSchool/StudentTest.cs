using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSchool
{
    [TestClass]
    public class StudentTest
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestStudentCreateNullName()
        {
            Student s = new Student(null, 11111);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestStudentCreateNegativeId()
        {
            Student s = new Student("Ivan", -11111);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestStudentCreateBiggerId()
        {
            Student s = new Student("Ivan", 111111);
        }

        [TestMethod]
        public void TestStudentNumber()
        {
            School school = new School("uzu");
            Student s = new Student("Ivan", 11111);
            s.Enrol(school);
            Assert.AreEqual(10000, s.Number);
        }

        [TestMethod]
        public void TestStudentEnrol()
        {
            School school = new School("uzu");
            Student s = new Student("Ivan", 11111);
            s.Enrol(school);
            Assert.AreEqual(10000, s.Number);
        }

        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestStudentEnrolNullSchool()
        {
            Student s = new Student("Ivan", 11111);
            s.Enrol(null);
        }
    }
}
