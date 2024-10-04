namespace Alrazi.Enums
{
    public enum StudentStatus
    {
        Main = -100,
        Student,
        StudentFamilyInfo,
        StudentMedical,
        StudentMedicalTest,
        StudentMotherMedical,
        StudentPsychologyDevelopment,
        StudentSibling,
        StudentSocialDevelopment,
        StudentFamilyActivity,
        StudentNote,

        Early = 1,
        Early_StudentDevelopment,
        Early_StudentAutonomy,
        Early_StudentPotentialEnhancer,
        Early_StudentEducationalualification,

        LearningDifficulties = 100,
        LD_StudentInterests,
        LD_StudentAcademic,
        LD_StudentLevelInfo,
        LD_StudentAbility,
        LD_StudentVisitCenter,
        LD_StudentMistake,

    }

    public class StudentStatusManager
    {
        public static string GetArabic(ConfigKey configKey)
        {
            switch (configKey)
            {
                case ConfigKey.MinStudyDate:
                    return "العمر الأدنى لدخول صعوبات التعلم";
                default:
                    return "";
            }
        }
    }
}
