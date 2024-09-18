namespace Alrazi.Enums
{
    public enum StudentStatus
    {
        Early = 1,
        Early_Student,
        Early_StudentFamilyInfo,
        Early_StudentSibling,
        Early_StudentMotherMedical,
        Early_StudentMedical,
        Early_StudentMedicalTest,
        Early_SocialDevelopment,
        Early_StudentPsychologyDevelopment,
        Early_StudentSocialDevelopment,
        Early_StudentAutonomy,
        Early_StudentFamilyActivity,
        Early_StudentPotentialEnhancer,
        Early_StudentEducationalَualification,
        Early_StudentNote,

        LearningDifficulties = 100,
        LD_Student,
        LD_StudentFamilyInfo,
        LD_StudentSibling,
        LD_StudentMotherMedical,
        LD_StudentMedical,
        LD_StudentMedicalTest,
        LD_StudentPsychologyDevelopment,
        LD_StudentSocialDevelopment,
        LD_StudentFamilyActivity,
        LD_StudentInterests,
        LD_StudentAcademic,
        LD_StudentLevelInfo,
        LD_StudentAbility,
        LD_StudentVisitCenter,
        LD_StudentMistake,
        LD_StudentNote,

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
