using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.ViewModel;
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


        public async Task<List<StudentTestReportVM>> GetTestStudentReport(int studentId)
        {
            List<StudentTestReportVM> studentTestReports = [];

            var getStudentTest = await context.Students.Where(x => x.Id == studentId)
                .Include(x => x.StudentTest).ToListAsync();
            var stdInfo = getStudentTest.First();
            //  var getAllStdTests = await context.StudentTest.Where(x => x.StudentId == studentId).ToListAsync();
            //var x = context.Tests
            //    .Include(x => x.TestSubjects).ThenInclude(x => x.TestSubjectResult)
            //    .Include(x => x.TestResult)
            //    .ToListAsync();
            foreach (var stdTest in getStudentTest.First().StudentTest)
            {
                var subjinfo = await context.TestSubject.FirstAsync(x => x.Id == stdTest.TestSubjectId);
                var subjinfoRes = await context.TestSubjectResult.Where(x => x.TestSubjectId == subjinfo.Id).ToListAsync();
                var testinfo = await context.Tests.FirstAsync(x => x.Id == subjinfo.TestId);
                var testinfoRes = await context.TestResult.Where(x => x.TestId == testinfo.Id).ToListAsync();

                StudentTestReportVM studentTestReport = new();
                studentTestReport.StudentName = stdInfo.FirstName + stdInfo.LastName;
                studentTestReport.BirthDate = stdInfo.BirthDate;
                //رقم التقييم
                studentTestReport.SerialNumber = stdTest.SerialNumber;
                //تاريخ التقييم
                studentTestReport.TestDate = stdTest.TestDate;
                //الزمني بالأشهر
                //studentTestReport.AgeInMonths = ,
                //العمر الزمني
                //studentTestReport.Age = ;
                //المجالات
                studentTestReport.Subject = subjinfo.Title;
                //القاعدي
                //studentTestReport.NumberCorrectAnswers = ;
                //الاضافي
                //studentTestReport.Additional = ;
                // النمائي بالأشهر
                //  studentTestReport.DevelopmentalAgeOfMounth = ,
                //العمر النمائي
                studentTestReport.DevelopmentalAge = studentTestReport.DevelopmentalAgeOfMounth / 12;
                //نسبة الاداء%
                studentTestReport.PerformancePercentage = stdTest.Mark;
                //نسبة الاداء كتابة
                studentTestReport.PerformanceDegree = subjinfoRes.FirstOrDefault(x => stdTest.Mark >= x.MinValue && stdTest.Mark <= x.MaxValue)?.Degree;
                //الفرق بالأشهر  بين ز - ن
                studentTestReport.DifferenceInMonths = studentTestReport.AgeInMonths - studentTestReport.DevelopmentalAgeOfMounth;
                //الفرق بالسنوات
                studentTestReport.DifferenceInYear = studentTestReport.DifferenceInMonths / 12;
                //التحقق
                //  studentTestReport.Verification = ,
                //المجموع
                //  studentTestReport.studentTestReport.TotalMarks = ;
                //التصنيف
                // studentTestReport.studentTestReport.RatingPercentage = ,
                //التصنيف درجة
                studentTestReport.RatingDegree = testinfoRes.FirstOrDefault(x => studentTestReport.TotalMarks >= x.MinValue && studentTestReport.TotalMarks <= x.MaxValue)?.Degree;



                studentTestReports.Add(studentTestReport);
            }


            return studentTestReports;
        }
    }
}
