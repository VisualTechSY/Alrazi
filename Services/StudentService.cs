using Alrazi.DTO;
using Alrazi.Enums;
using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.Tools;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class StudentService(Context context)
    {
        public async Task AddEarlyStudent(Student student, StudentFamilyInfo studentFamilyInfo, List<StudentSibling> studentSiblings,
            StudentMotherMedical studentMotherMedical, StudentMedical studentMedical, StudentMedicalTest studentMedicalTest, 
            StudentDevelopment studentDevelopment, StudentPsychologyDevelopment studentPsychologyDevelopment,
            StudentSocialDevelopment studentSocialDevelopment, StudentAutonomy studentAutonomy, 
            StudentFamilyActivity studentFamilyActivity, StudentPotentialEnhancer studentPotentialEnhancer, 
            List<StudentEducationalualification> studentEducationalualifications, StudentNote studentNote)
        {
            student.StudentFamilyInfo = studentFamilyInfo;
            student.StudentSiblings = studentSiblings;
            student.StudentMotherMedical = studentMotherMedical;
            student.StudentMedical = studentMedical;
            student.StudentMedicalTest = studentMedicalTest;
            student.StudentDevelopment = studentDevelopment;
            student.StudentPsychologyDevelopment = studentPsychologyDevelopment;
            student.StudentSocialDevelopment = studentSocialDevelopment;
            student.StudentAutonomy = studentAutonomy;
            student.StudentFamilyActivity = studentFamilyActivity;
            student.StudentPotentialEnhancer = studentPotentialEnhancer;
            student.StudentEducationalualifications = studentEducationalualifications;
            student.StudentNote = studentNote;

            student.StateNumber = 1;
            if (await context.Students.AnyAsync(x=> x.StudyStateDate.Year == student.StudyStateDate.Year))
                student.StateNumber = await context.Students.Where(x => x.StudyStateDate.Year == student.StudyStateDate.Year)
                    .MaxAsync(x => x.StateNumber) + 1;

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        internal async Task AddLDStudent(Student student, StudentFamilyInfo studentFamilyInfo, List<StudentSibling> studentSiblings,
            StudentMotherMedical studentMotherMedical, StudentMedical studentMedical, StudentMedicalTest studentMedicalTest,
            List<StudentInterests> studentInterests, StudentPsychologyDevelopment studentPsychologyDevelopment, 
            StudentSocialDevelopment studentSocialDevelopment, List<StudentLevelInfo> studentLevelInfos,
            StudentFamilyActivity studentFamilyActivity, StudentAcademic studentAcademic, StudentAbility studentAbility,
            StudentNote studentNote, List<StudentVisitCenter> studentVisitCenters , StudentMistake studentMistake)
        {
            student.StudentFamilyInfo = studentFamilyInfo;
            student.StudentSiblings = studentSiblings;
            student.StudentMotherMedical = studentMotherMedical;
            student.StudentMedical = studentMedical;
            student.StudentMedicalTest = studentMedicalTest;
            student.StudentPsychologyDevelopment = studentPsychologyDevelopment;
            student.StudentSocialDevelopment = studentSocialDevelopment;
            student.StudentFamilyActivity = studentFamilyActivity;
            student.StudentNote = studentNote;
            student.StudentInterests = studentInterests;
            student.StudentAcademic = studentAcademic;
            student.StudentLevelInfos = studentLevelInfos;
            student.StudentAbility = studentAbility;
            student.StudentVisitCenters = studentVisitCenters;
            student.StudentMistake = studentMistake;

            student.StateNumber = 1;
            if (await context.Students.AnyAsync(x => x.StudyStateDate.Year == student.StudyStateDate.Year))
                student.StateNumber = await context.Students.Where(x => x.StudyStateDate.Year == student.StudyStateDate.Year)
                    .MaxAsync(x => x.StateNumber) + 1;

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task<List<StudentInfo>> GetStudentsInfo(int year, StudentStatus studentStatus)
        {
            return await context.Students.Where(x => x.AccessDate.Date.Year == year
            && x.StudentStatus == studentStatus)
                .Include(x=> x.StudentFamilyInfo)
                .Select(x=> new StudentInfo
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    MotherName = string.IsNullOrWhiteSpace(x.StudentFamilyInfo.MotherName)
                    ? "" : x.StudentFamilyInfo.MotherName,
                    PhoneNumber = x.PhoneNumber,
                    StudentStatus = x.StudentStatus
                })
            .ToListAsync();
        }

		public async Task<Student> EditEarlyStudent(int id)
		{
            return await context.Students
                .Include(x=> x.StudentFamilyInfo)
                .Include(x=> x.StudentSiblings)
                .Include(x=> x.StudentMotherMedical)
                .Include(x=> x.StudentMedical)
                .Include(x=> x.StudentMedicalTest)
                .Include(x=> x.StudentDevelopment)
                .Include(x=> x.StudentSocialDevelopment)
                .Include(x=> x.StudentAutonomy)
                .Include(x=> x.StudentFamilyActivity)
                .Include(x=> x.StudentPotentialEnhancer)
                .Include(x=> x.StudentEducationalualifications)
                .Include(x=> x.StudentNote)
                .Include(x => x.StudentPsychologyDevelopment)
                .Include(x => x.StudentPsychologyDevelopment.StudentPsychologyDevelopmentBehavioralProblems)
                .FirstAsync(x => x.Id == id);
		}

        public async Task<Student> EditLDStudent(int id)
        {
            return await context.Students
                .Include(x=> x.StudentFamilyInfo)
                .Include(x=> x.StudentSiblings)
                .Include(x=> x.StudentMotherMedical)
                .Include(x=> x.StudentMedical)
                .Include(x=> x.StudentMedicalTest)
                .Include(x=> x.StudentPsychologyDevelopment)
                .Include(x=> x.StudentSocialDevelopment)
                .Include(x=> x.StudentFamilyActivity)
                .Include(x=> x.StudentInterests)
                .Include(x=> x.StudentAcademic)
                .Include(x=> x.StudentLevelInfos)
                .Include(x=> x.StudentAbility)
                .Include(x=> x.StudentVisitCenters)
                .Include(x=> x.StudentMistake)
                .Include(x=> x.StudentNote)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<int> GetStartYear()
        {
            if (await context.Students.AnyAsync())
                return await context.Students.MinAsync(x => x.AccessDate.Date.Year);
            return 0;
        }

        public async Task EditStudent(Student student)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentFamilyInfo(StudentFamilyInfo studentFamilyInfo)
        {
            context.StudentFamilyInfos.Update(studentFamilyInfo);
            await context.SaveChangesAsync();
        }

        public async Task AddNewStudentSibling(StudentSibling studentSibling)
        {
            await context.StudentSiblings.AddAsync(studentSibling);
            await context.SaveChangesAsync();
        }

        public async Task<int> RemoveStudentSibling(int id)
        {
            var getData = await context.StudentSiblings.FindAsync(id);
            context.StudentSiblings.Remove(getData);
            await context.SaveChangesAsync();
            return getData.StudentId;
        }

        public async Task EditStudentMotherMedical(StudentMotherMedical studentMotherMedical)
        {
            context.StudentMotherMedicals.Update(studentMotherMedical);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentMedical(StudentMedical studentMedical)
        {
            context.StudentMedicals.Update(studentMedical);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentMedicalTest(StudentMedicalTest studentMedicalTest)
        {
            context.StudentMedicalTests.Update(studentMedicalTest);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentDevelopment(StudentDevelopment studentDevelopment)
        {
            context.StudentDevelopments.Update(studentDevelopment);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentPsychologyDevelopment(StudentPsychologyDevelopment studentPsychologyDevelopment)
        {
            context.StudentPsychologyDevelopments.Update(studentPsychologyDevelopment);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentSocialDevelopment(StudentSocialDevelopment studentSocialDevelopment)
        {
            context.StudentSocialDevelopments.Update(studentSocialDevelopment);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentAutonomy(StudentAutonomy studentAutonomy)
        {
            context.StudentAutonomies.Update(studentAutonomy);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentFamilyActivity(StudentFamilyActivity studentFamilyActivity)
        {
            context.StudentFamilyActivities.Update(studentFamilyActivity);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentPotentialEnhancer(StudentPotentialEnhancer studentPotentialEnhancer)
        {
            context.StudentPotentialEnhancers.Update(studentPotentialEnhancer);
            await context.SaveChangesAsync();
        }

        public async Task EditStudentNote(StudentNote studentNote)
        {
            context.StudentNotes.Update(studentNote);
            await context.SaveChangesAsync();
        }

        public async Task AddNewStudentEducationalualification(StudentEducationalualification studentEducationalualification)
        {
            await context.StudentEducationals.AddAsync(studentEducationalualification);
            await context.SaveChangesAsync();
        }

        public async Task<int> RemoveStudentEducationalualification(int id)
        {
            var getData = await context.StudentEducationals.FindAsync(id);
            context.StudentEducationals.Remove(getData);
            await context.SaveChangesAsync();
            return getData.StudentId;
        }
    }
}