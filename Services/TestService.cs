using Alrazi.HttpParameters;
using Alrazi.Models;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class TestService(Context context)
    {
        public async Task<List<Test>> GetAvalableTestForStudent(int studentId)
        {
            var std = await context.Students.FindAsync(studentId);
            List<Test> tests = await context.Tests.Where(x => x.StudentType == std.StudentStatus).Include(x => x.TestSubjects).ToListAsync();
            return tests;
        }
        public async Task AddTestStudent(AddTestStudentVM testStudentVM)
        {
            List<StudentTest> StudentTest = [];
            var serialNumber = testStudentVM.SerialNumber;

            var x = context.StudentTest.Where(x => x.StudentId == testStudentVM.StudentId);
            if (x.Any())
                serialNumber = x.Max(x => x.SerialNumber);

            serialNumber++;
            for (int i = 0; i < testStudentVM.TestSubjectId.Length; i++)
            {
                StudentTest.Add(new StudentTest()
                {
                    StudentId = testStudentVM.StudentId,
                    SerialNumber = serialNumber,
                    TestSubjectId = testStudentVM.TestSubjectId[i],
                    NumberCorrectAnswers = testStudentVM.NumberCorrectAnswers[i],
                    Mark = testStudentVM.Mark[i],
                });
            }


            context.StudentTest.AddRange(StudentTest);
            await context.SaveChangesAsync();
        }


        //public async Task<Tuple<bool, string>> GetTestStudent(string username, string password)
        //{

        //}
    }
}
