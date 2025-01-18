using Alrazi.Models;
using Alrazi.Models.Test;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class TestService(Context context)
    {
        public async Task<TestPortage> GetTestPortageById(int testId)
        {
            return await context.TestPortages
                                        .Include(x => x.TestPortageDetails)
                                        .Include(x => x.Student)
                                        .FirstAsync(x => x.Id == testId);
        }
        public async Task<TestPortage> UpdateSummaryTestPortage(TestPortage testPortage)
        {
            TestPortage getTestPortage = await context.TestPortages.FindAsync(testPortage.Id);

            getTestPortage.Recommendations = testPortage.Recommendations;
            getTestPortage.Summary = testPortage.Summary;
            await context.SaveChangesAsync();
            return await GetTestPortageById(getTestPortage.Id);
        }
        public async Task<List<TestPortageDetails>> GetStudentTestPortage(int studentId)
        {
            var getTest = await context.TestPortageDetails
                                                    .Where(x => x.TestPortage.StudentId == studentId)
                                                    .Include(x => x.TestPortage)
                                                    .ThenInclude(x => x.Student)
                                                    .OrderBy(x => x.TestPortage.SerialNumber)
                                                    .ToListAsync();
            return getTest;
        }
        public async Task<List<TestPortage>> GetStudentTestPortageSkill(int studentId)
        {
            var getTest = await context.TestPortages
                                                    .Where(x => x.StudentId == studentId && x.LastTestDateSkill != default)
                                                    .Include(x => x.Student)
                                                    .Include(x => x.TestPortageSkills)
                                                    .ThenInclude(x => x.TestPortageSkillDetalis)
                                                    .OrderBy(x => x.SerialNumber)
                                                    .ToListAsync();
            return getTest;
        }
        public async Task<Student> GetLastTestPortage(int studentId)
        {
            int maxSerial = context.TestPortages.Where(x => x.StudentId == studentId).Any() ?
                context.TestPortages.Where(x => x.StudentId == studentId).Max(x => x.SerialNumber) : 0;

            return await context.Students
                .Include(x => x.TestPortages.Where(c => c.SerialNumber == maxSerial))
                .FirstAsync(x => x.Id == studentId);
        }

        //صورة جانبية
        public async Task<int> AddTestPortage(TestPortage testPortage)
        {
            var stdTest = context.TestPortages.Where(x => x.StudentId == testPortage.StudentId);
            testPortage.SerialNumber = stdTest.Any() ? stdTest.Max(x => x.SerialNumber) + 1 : 1;

            context.TestPortages.Add(testPortage);
            await context.SaveChangesAsync();
            return testPortage.Id;
        }
        //قائمة شطب
        public async Task<int> AddTestPortageSkill(TestPortage testPortage)
        {
            var getTestPortageSkill = await context.TestPortages.Include(x => x.TestPortageSkills).FirstAsync(x => x.Id == testPortage.Id);
            getTestPortageSkill.LastTestDateSkill = testPortage.TestPortageSkills[0].TestDateSkill;

            int maxSerial = getTestPortageSkill.TestPortageSkills.Any() ? getTestPortageSkill.TestPortageSkills.Max(x => x.SerialNumber) + 1 : 1;
            testPortage.TestPortageSkills[0].SerialNumber = maxSerial;
            testPortage.TestPortageSkills[0].TestPortageId = testPortage.Id;

            await context.TestPortageSkills.AddRangeAsync(testPortage.TestPortageSkills);
            await context.SaveChangesAsync();
            return getTestPortageSkill.StudentId;
        }




        public async Task<TestStanfordBinet> GetTestStanfordBinetById(int testId)
        {
            return await context.TestStanfordBinets
                                        .Include(x => x.TestStanfordBinetDetails)
                                        .Include(x => x.Student)
                                        .FirstAsync(x => x.Id == testId);
        }
        public async Task<List<TestStanfordBinetDetails>> GetStudentTestStanfordBinet(int studentId)
        {
            var getTest = await context.TestStanfordBinetDetails
                                                    .Where(x => x.TestStanfordBinet.StudentId == studentId)
                                                    .Include(x => x.TestStanfordBinet)
                                                    .ThenInclude(x => x.Student)
                                                    .OrderBy(x => x.TestStanfordBinet.SerialNumber)
                                                    .ToListAsync();
            return getTest;
        }
        public async Task<int> AddTestStanfordBinet(TestStanfordBinet testStanfordBinet)
        {
            var stdTest = context.TestStanfordBinets.Where(x => x.StudentId == testStanfordBinet.StudentId);
            testStanfordBinet.SerialNumber = stdTest.Any() ? stdTest.Max(x => x.SerialNumber) + 1 : 1;

            context.TestStanfordBinets.Add(testStanfordBinet);
            await context.SaveChangesAsync();
            return testStanfordBinet.Id;
        }



        public async Task<TestRaven> GetTestRavenById(int testId)
        {
            TestRaven getTest= await context.TestRavens
                                        .Include(x => x.Student)
                                        .FirstAsync(x => x.Id == testId);
            getTest.CalcResault();
            return getTest;
        }
        public async Task<List<TestRaven>> GetStudentTestRaven(int studentId)
        {
            List<TestRaven> getTest = await context.TestRavens
                                                    .Where(x => x.StudentId == studentId)
                                                    .Include(x=>x.Student)
                                                    .OrderByDescending(x => x.SerialNumber)
                                                    .ToListAsync();
            foreach (var item in getTest)
                item.CalcResault();
            return getTest;
        }
        public async Task<int> AddTestRaven(TestRaven testRaven)
        {
            var stdTest = context.TestRavens.Where(x => x.StudentId == testRaven.StudentId);
            testRaven.SerialNumber = stdTest.Any() ? stdTest.Max(x => x.SerialNumber) + 1 : 1;

            context.TestRavens.Add(testRaven);
            await context.SaveChangesAsync();
            return testRaven.Id;
        }



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
