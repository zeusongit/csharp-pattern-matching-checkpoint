using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpPatternMatchingCheckpoint
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TestsBefore
        {

            [TestMethod]
            public void Test1()
            {
                //Arrange
                var passingStudent = new Student("Jane", "Doe", true, 'B');
                var failingStudent = new Student("Jane", "Doe", true, 'D');

                //Act
                bool passResult = getPassOrFail_ByPropertyPatternMatching(passingStudent);
                bool failResult = getPassOrFail_ByPropertyPatternMatching(failingStudent);

                //Assert
                Assert.AreEqual(true, passResult && !failResult);
            }

            [TestMethod]
            public void Test2()
            {
                //Arrange
                var passingStudent = new Student("Jane", "Doe", true, 'B');
                var failingStudent = new Student("Jane", "Doe", true, 'D');

                //Act
                bool passResult = getPassOrFail_ByTuplePatternMatching(passingStudent);
                bool failResult = getPassOrFail_ByTuplePatternMatching(failingStudent);

                //Assert
                Assert.AreEqual(true, passResult && !failResult);
            }

            [TestMethod]
            public void Test3()
            {
                //Arrange
                var passingStudent = new Student("Jane", "Doe", true, 'B');
                var failingStudent = new Student("Jane", "Doe", true, 'D');

                //Act
                bool passResult = getPassOrFail_ByPositionalPatternMatching(passingStudent);
                bool failResult = getPassOrFail_ByPositionalPatternMatching(failingStudent);

                //Assert
                Assert.AreEqual(true, passResult && !failResult);
            }

            public static bool getPassOrFail_ByPropertyPatternMatching(Student student) =>
            student switch
            {
                { Grade: 'A', TuitionPaid: true } => true,
                { Grade: 'B', TuitionPaid: true } => true,
                { Grade: 'C', TuitionPaid: true} => true,
                _ => false

            };

            public static bool getPassOrFail_ByTuplePatternMatching(Student student) =>
            (student.Grade, student.TuitionPaid) switch
            {
                ('A', true) => true,
                ('B', true) => true,
                ('C', true) => true,
                (_,_) => false
            };

            public static bool getPassOrFail_ByPositionalPatternMatching(Student student) =>
            student switch
            {
                var (g,t) when g=='A' && t =>true,
                var (g, t) when g == 'B' && t => true,
                var (g, t) when g == 'C' && t => true,
                _ => false,
            };
        }

        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool TuitionPaid { get; set; }
            public char Grade { get; set; }

            public Student(string firstName, string lastName, bool tuitionPaid, char grade) =>
                (FirstName, LastName, TuitionPaid, Grade) = (firstName, lastName, tuitionPaid, grade);
            public void Deconstruct(out int grade, out bool tuitionpaid) =>
                (grade, tuitionpaid) = (Grade, TuitionPaid);
        }
    }
}
