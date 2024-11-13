using Alrazi.Models.Test;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class TestService(Context context)
    {

        public async Task<List<TestPortage>> GetTestPortage(int studentId)
        {
            var getTest = await context.TestPortages
                                        .Where(x => x.StudentId == studentId)
                                        .Include(x => x.TestPortageDetails)
                                        .OrderBy(x => x.SerialNumber)
                                        .ToListAsync();
            return getTest;
        }
        public async Task AddTestPortage(TestPortage testPortage)
        {
            int serialNumber = 0;
            var stdTest = context.TestPortages.Where(x => x.StudentId == testPortage.StudentId);
            if (stdTest.Any())
                serialNumber = stdTest.Any() ? stdTest.Max(x => x.SerialNumber) + 1 : 1;

            context.TestPortages.Add(testPortage);
            await context.SaveChangesAsync();
        }



        public async Task<List<TestStanfordBinet>> GetStanfordBinet(int studentId)
        {
            var getTest = await context.TestStanfordBinets
                                        .Where(x => x.StudentId == studentId)
                                        .Include(x => x.TestStanfordBinetDetails)
                                        .OrderBy(x => x.SerialNumber)
                                        .ToListAsync();
            return getTest;
        }
        public async Task AddTestStanfordBinet(TestStanfordBinet testStanfordBinet)
        {
            int serialNumber = 0;
            var stdTest = context.TestStanfordBinets.Where(x => x.StudentId == testStanfordBinet.StudentId);
            if (stdTest.Any())
                serialNumber = stdTest.Any() ? stdTest.Max(x => x.SerialNumber) + 1 : 1;

            context.TestStanfordBinets.Add(testStanfordBinet);
            await context.SaveChangesAsync();
        }



        /*
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
                    TheBase = testStudentVM.TheBase[i],
                    Additional = testStudentVM.Additional[i],
                    Mark = testStudentVM.Mark[i],
                });
            }


            context.StudentTest.AddRange(StudentTest);
            await context.SaveChangesAsync();
        }*/

        /*
         //todo Excel compare between TestResault
                public async Task<List<StudentTestReportVM>> GetTestStudentReport(int studentId)
                {
                    List<StudentTestReportVM> studentTestReports = [];

                    var student = await context.Students.FirstAsync(x => x.Id == studentId);

                    var studentTests = await context.StudentTest
                        .Where(x => x.StudentId == studentId)
                        .Include(x => x.Student)
                        .Include(x => x.TestSubject)
                        .Include(x => x.TestSubject.TestSubjectResults)
                        .Include(x => x.TestSubject.Test)
                        .Include(x => x.TestSubject.Test.TestResults)
                        .ToListAsync();

                    foreach (var studentTest in studentTests)
                    {

                        StudentTestReportVM studentTestReport = new();
                        studentTestReport.StudentName = student.FirstName + student.LastName;
                        studentTestReport.BirthDate = student.BirthDate.ToShortDateString();
                        //رقم التقييم
                        studentTestReport.SerialNumber = studentTest.SerialNumber;
                        //تاريخ التقييم
                        studentTestReport.TestDate = studentTest.TestDate.ToShortDateString();

                        Birthday birthday = new(student.BirthDate, studentTest.TestDate);

                        //الزمني بالأشهر
                        studentTestReport.AgeInMonths = birthday.TotalMonth;
                        //العمر الزمني
                        studentTestReport.ChronologicalAge = birthday.ChronologicalAge;
                        //المجالات
                        studentTestReport.Subject = studentTest.TestSubject.Title;
                        //القاعدي
                        studentTestReport.TheBase = studentTest.TheBase;
                        //الاضافي
                        studentTestReport.Additional = studentTest.Additional;

                        var subjectResult = studentTest.TestSubject.TestSubjectResults.FirstOrDefault(x => studentTest.Mark >= x.MinValue && studentTest.Mark <= x.MaxValue) ?? new();

                        // النمائي بالأشهر
                        studentTestReport.DevelopmentalAgeOfMounth = subjectResult.AgeOfMounth;
                        //العمر النمائي
                        studentTestReport.DevelopmentalAge = studentTestReport.DevelopmentalAgeOfMounth / 12;
                        //نسبة الاداء%
                        studentTestReport.PerformancePercentage = studentTest.Mark;
                        //نسبة الاداء كتابة
                        studentTestReport.PerformanceDegree = subjectResult.Degree;
                        //الفرق بالأشهر  بين ز - ن
                        studentTestReport.DifferenceInMonths = studentTestReport.AgeInMonths - studentTestReport.DevelopmentalAgeOfMounth;
                        //الفرق بالسنوات
                        studentTestReport.DifferenceInYear = Math.Round(studentTestReport.DifferenceInMonths / 12, 2);
                        //التحقق
                        studentTestReport.Verification = studentTestReport.DevelopmentalAge + studentTestReport.DifferenceInYear;

                        var subjectGroup = studentTests.Where(x => x.SerialNumber == studentTest.SerialNumber);

                        //المجموع
                        studentTestReport.TotalMarks = subjectGroup.Sum(x => x.Mark);
                        //التصنيف
                        studentTestReport.RatingPercentage = subjectGroup.Average(x => x.Mark);

                        var testResult = studentTest.TestSubject.Test.TestResults.FirstOrDefault(x => studentTestReport.TotalMarks >= x.MinValue && studentTestReport.TotalMarks <= x.MaxValue) ?? new();

                        //التصنيف درجة
                        studentTestReport.RatingDegree = testResult.Degree;

                        studentTestReport.CountOfRow = subjectGroup.Count();


                        studentTestReports.Add(studentTestReport);
                    }


                    return [.. studentTestReports.OrderBy(x => x.SerialNumber).ThenBy(x => x.Subject)];
                }
        */




    }
}
