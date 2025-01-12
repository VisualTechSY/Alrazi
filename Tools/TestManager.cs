using Alrazi.Enums.Test;
using Alrazi.ViewModel;

namespace Alrazi.Tools
{
    public class TestManager
    {
        public static string GetTestTypeArabic(TestType testType)
        {
            return testType switch
            {
                TestType.Portage => "بورتج",
                TestType.StanfordBinet => "ستانفورد بينيه للذكاء",
                TestType.Raven => "رافن",
                _ => "",
            };
        }

        //Portage
        public static string GetTestPortageSubjectArabic(TestPortageSubject testPortageSubject)
        {
            return testPortageSubject switch
            {
                TestPortageSubject.Social => "الاجتماعي",
                TestPortageSubject.Knowledge => "المعرفي",
                TestPortageSubject.Communication => "الاتصالي",
                TestPortageSubject.Care => "العناية",
                TestPortageSubject.Movement => "الحركي",
                _ => "",
            };
        }

        public static string GetTestPortageSubjectArabic(TestPortage_Skill testPortage_Skill)
        {
            return testPortage_Skill switch
            {
                TestPortage_Skill.Social_InteractWithOthers => "التفاعل مع الآخرين",
                TestPortage_Skill.Social_Emotionalskills => "المهارات الإنفعالية",
                TestPortage_Skill.Social_InteractWithGames => "التفاعل مع الألعاب",
                TestPortage_Skill.Knowledge_SensorySkills => "المهارات الحسية",
                TestPortage_Skill.Knowledge_ExploreAndThink => "الاستكشاف والتفكير",
                TestPortage_Skill.Communication_CommunicationAndLanguage => "التواصل واللغة",
                TestPortage_Skill.Communication_EarlyReading => "القراءة المبكرة",
                TestPortage_Skill.Care_Nutrition => "التغذية",
                TestPortage_Skill.Care_Cleanliness => "النظافة",
                TestPortage_Skill.Care_GettingDressed => "ارتداء الملابس",
                TestPortage_Skill.Movement_MajourSkills => "المهارات الكبرى",
                TestPortage_Skill.Movement_MicroSkills => "المهارات الدقيقة",
                TestPortage_Skill.Movement_PreWriting => "ماقبل الكتابة",
                _ => "",
            };
        }


        public static string GetTestPortageResault(double mark)
        {
            if (mark <= 25) return "شديد جداً";
            else if (mark <= 39) return "شديد";
            else if (mark <= 54) return "متوسط";
            else if (mark <= 69) return "بسيط";
            else if (mark <= 84) return "بسيط جداً";
            else return "طبيعي";
        }

        //StanfordBinet
        public static string GetTestStanfordBinetSubjectArabic(TestStanfordBinetSubject testStanfordBinetSubject)
        {
            return testStanfordBinetSubject switch
            {
                TestStanfordBinetSubject.FullScaleIQ => "نسبة الذكاء الكلية",
                TestStanfordBinetSubject.NonverbalIQ => "نسبة الذكاء غير اللفظية",
                TestStanfordBinetSubject.VerbalIQ => "نسبة الذكاء اللفظية",
                TestStanfordBinetSubject.FluidReasoning => "مؤشر الاستدلال التحليلي",
                TestStanfordBinetSubject.Knowledge => "مؤشر المعرفة",
                TestStanfordBinetSubject.QuantitativeReasoning => "مؤشر الاستدلال الكمي",
                TestStanfordBinetSubject.VisualSpatialProcessing => "مؤشر المعالجة البصرية المكانية",
                TestStanfordBinetSubject.WorkingMemory => "مؤشر الذاكرة العاملة",
                _ => "",
            };
        }
        public static string GetTestStanfordBinetResault(double mark)
        {
            if (mark <= 39) return "تخلف شديد";
            else if (mark <= 54) return "تخلف متوسط";
            else if (mark <= 69) return "تخلف بسيط";
            else if (mark <= 79) return "على حدود التخلف";
            else if (mark <= 89) return "أدى من المتوسط ";
            else if (mark <= 109) return "متوسط";
            else if (mark <= 119) return "متوسط مرتفع";
            else return "متفوق";
        }

    }
}
