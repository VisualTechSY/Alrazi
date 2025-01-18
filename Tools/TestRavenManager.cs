using Alrazi.ViewModel;

namespace Alrazi.Tools
{
    public class TestRavenManager
    {
        static List<ArrayResults> ArrayResults;

        public static int GetRavenCentenary(int mark, Birthday birthday)
        {
            int centenary = -1;
            var obj = ArrayResults.FirstOrDefault(x => x.Mark == mark && birthday.TotalMonth >= x.MinAgeMonth && birthday.TotalMonth <= x.MaxAgeMonth);
            if (obj is not null)
                centenary = obj.Centenary;
            return centenary;
        }

        static TestRavenManager()
        {
            ArrayResults =
                [
                //Age 5.5-6.4
                new(66, 77, 28, 95),
                new(66, 77, 24, 90),
                new(66, 77, 21, 75),
                new(66, 77, 17, 50),
                new(66, 77, 14, 25),
                new(66, 77, 11, 10),
                new(66, 77, 9, 5),
                //Age 6.5-7.4
                new(78, 89, 28, 95),
                new(78, 89, 27, 90),
                new(78, 89, 23, 75),
                new(78, 89, 19, 50),
                new(78, 89, 15, 25),
                new(78, 89, 13, 10),
                new(78, 89, 11, 5),
                //Age 7.5-8.4
                new(90, 100, 30, 95),
                new(90, 100, 29, 90),
                new(90, 100, 26, 75),
                new(90, 100, 21, 50),
                new(90, 100, 17, 25),
                new(90, 100, 15, 10),
                new(90, 100, 13, 5),
                //Age 8.5-9.4
                new(102, 112, 31, 95),
                new(102, 112, 30, 90),
                new(102, 112, 27, 75),
                new(102, 112, 23, 50),
                new(102, 112, 18, 25),
                new(102, 112, 17, 10),
                new(102, 112, 15, 5),
                //Age 9.5-10.4
                new(114, 124, 32, 95),
                new(114, 124, 31, 90),
                new(114, 124, 30, 75),
                new(114, 124, 26, 50),
                new(114, 124, 21, 25),
                new(114, 124, 18, 10),
                new(114, 124, 17, 5),
                //Age 10.5-11.4
                new(126, 136, 33, 95),
                new(126, 136, 29, 90),
                new(126, 136, 25, 75),
                new(126, 136, 21, 50),
                new(126, 136, 16, 25),
                new(126, 136, 15, 10),
                new(126, 136, 8, 5),

                //Age 11.5-12.4
                new(138, 148, 33, 95),
                new(138, 148, 29, 90),
                new(138, 148, 28, 75),
                new(138, 148, 23, 50),
                new(138, 148, 17, 25),
                new(138, 148, 16, 10),
                new(138, 148, 8, 5),

                //Age 12.5-13.4
                new(150, 160, 34, 95),
                new(150, 160, 32, 90),
                new(150, 160, 28, 75),
                new(150, 160, 23, 50),
                new(150, 160, 18, 25),
                new(150, 160, 16, 10),
                new(150, 160, 9, 5),

                //Age 13.5-14.4
                new(162, 172, 34, 95),
                new(162, 172, 31, 90),
                new(162, 172, 29, 75),
                new(162, 172, 25, 50),
                new(162, 172, 19, 25),
                new(162, 172, 17, 10),
                new(162, 172, 9, 5),

                //Age 14.5-15.4
                new(174, 184, 35, 95),
                new(174, 184, 32, 90),
                new(174, 184, 30, 75),
                new(174, 184, 26, 50),
                new(174, 184, 20, 25),
                new(174, 184, 17, 10),
                new(174, 184, 10, 5),

                //Age 15.5-16.4
                new(186, 196, 35, 95),
                new(186, 196, 33, 90),
                new(186, 196, 30, 75),
                new(186, 196, 27, 50),
                new(186, 196, 21, 25),
                new(186, 196, 18, 10),
                new(186, 196, 10, 5),
                ];
        }


        public static string GetTestRavenResaultIQ(int Centenary)
        {
            if (Centenary <= -1) return "العلامة خارج النطاق المعرف";
            else if (Centenary <= 4) return "40-54";
            else if (Centenary <= 9) return "55-69";
            else if (Centenary <= 24) return "70-79";
            else if (Centenary <= 49) return "80-89";
            else if (Centenary <= 74) return "90-109";
            else if (Centenary <= 89) return "110-119";
            else if (Centenary <= 94) return "120-129";
            else return "130-144";
        }

        public static string GetTestRavenResaultRank(int Centenary)
        {
            if (Centenary <= -1) return "العلامة خارج النطاق المعرف";
            else if (Centenary <= 4) return "تخلف شديد";
            else if (Centenary <= 9) return "تخلف بسيط";
            else if (Centenary <= 24) return "على حدود التخلف";
            else if (Centenary <= 49) return "أقل من المتوسط";
            else if (Centenary <= 74) return "متوسط";
            else if (Centenary <= 89) return "متوسط مرتفع";
            else if (Centenary <= 94) return "متفوق";
            else return "موهوب";
        }
    }

    //المعايير المئينية
    class ArrayResults
    {
        public ArrayResults(int MinAgeInMonth, int MaxAgeMonth, int Mark, int Centenary)
        {
            this.MinAgeMonth = MinAgeMonth; this.MaxAgeMonth = MaxAgeMonth; this.Mark = Mark; this.Centenary = Centenary;
        }

        public double MinAgeMonth { get; set; }
        public double MaxAgeMonth { get; set; }
        public int Mark { get; set; }
        //الترتيب المئيني
        public int Centenary { get; set; }
    }

}