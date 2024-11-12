using Alrazi.Enums.Test;

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
        public static string GetTestPortageResault(int mark)
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
        public static string GetTestStanfordBinetResault(int mark)
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
