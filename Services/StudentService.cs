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
            StudentNote studentNote, List<StudentVisitCenter> studentVisitCenters)
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
          

            student.StateNumber = 1;
            if (await context.Students.AnyAsync(x => x.StudyStateDate.Year == student.StudyStateDate.Year))
                student.StateNumber = await context.Students.Where(x => x.StudyStateDate.Year == student.StudyStateDate.Year)
                    .MaxAsync(x => x.StateNumber) + 1;

            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }
    }
}