using Alrazi.ViewModel;

namespace Alrazi.Tools
{
    public class TestRavenManager
    {
        static List<ArrayResults> ArrayResults;

        public static int GetRavenCentenary(int mark, Birthday birthday)
        {
            int centenary = -1;
            var obj = ArrayResults.FirstOrDefault(x => x.MinMark <= mark && mark <= x.MaxMark && birthday.TotalMonth >= x.MinAgeMonth && birthday.TotalMonth <= x.MaxAgeMonth);
            if (obj is not null)
                centenary = obj.Centenary;
            return centenary;
        }

        static TestRavenManager()
        {
            ArrayResults =
                [
                //Age 5.5-6.4
                new(66, 77, 28, 36, 95),
                new(66, 77, 24, 27, 90),
                new(66, 77, 21, 23, 75),
                new(66, 77, 17, 20, 50),
                new(66, 77, 14, 16, 25),
                new(66, 77, 11, 13, 10),
                new(66, 77, 9 , 10, 5 ),
                new(66, 77, 0 , 8 , 0 ),
                //Age 6.5-7.4
                new(78, 89, 28, 36, 95),
                new(78, 89, 26, 27, 90),
                new(78, 89, 22, 25, 75),
                new(78, 89, 18, 21, 50),
                new(78, 89, 15, 17, 25),
                new(78, 89, 13, 14, 10),
                new(78, 89, 10, 12, 5 ),
                new(78, 89, 0 , 9 , 0 ),
                //Age 7.5-8.4
                new(90, 100, 30, 36, 95),
                new(90, 100, 28, 29, 90),
                new(90, 100, 25, 27, 75),
                new(90, 100, 21, 24, 50),
                new(90, 100, 17, 20, 25),
                new(90, 100, 15, 16, 10),
                new(90, 100, 12, 14, 5 ),
                new(90, 100, 0  ,11, 0 ),
                //Age 8.5-9.4
                new(102, 112, 31, 36, 95),
                new(102, 112, 29, 30, 90),
                new(102, 112, 26, 28, 75),
                new(102, 112, 22, 25, 50),
                new(102, 112, 18, 21, 25),
                new(102, 112, 16, 17, 10),
                new(102, 112, 14, 15, 5 ),
                new(102, 112, 0 , 13, 0 ),
                //Age 9.5-10.4
                new(114, 124, 32, 36, 95),
                new(114, 124, 31, 31, 90),
                new(114, 124, 29, 30, 75),
                new(114, 124, 25, 28, 50),
                new(114, 124, 21, 24, 25),
                new(114, 124, 18, 20, 10),
                new(114, 124, 16, 17, 5 ),
                new(114, 124, 0 , 15, 0 ),
                //Age 10.5-11.4
                new(126, 136, 32 ,36, 95),
                new(126, 136, 28 ,31, 90),
                new(126, 136, 24 ,27, 75),
                new(126, 136, 20 ,23, 50),
                new(126, 136, 16 ,19, 25),
                new(126, 136, 13 ,15, 10),
                new(126, 136, 8  ,12, 5 ),
                new(126, 136, 0  ,7 , 0 ),

                //Age 11.5-12.4
                new(138, 148, 32, 36, 95),
                new(138, 148, 29, 31, 90),
                new(138, 148, 27, 28, 75),
                new(138, 148, 22, 26, 50),
                new(138, 148, 17, 21, 25),
                new(138, 148, 13, 16, 10),
                new(138, 148, 8 , 12, 5),
                new(138, 148, 0 , 7 , 0),

                //Age 12.5-13.4
                new(150, 160, 33, 36, 95),
                new(150, 160, 31, 32, 90),
                new(150, 160, 27, 30, 75),
                new(150, 160, 22, 26, 50),
                new(150, 160, 18, 21, 25),
                new(150, 160, 14, 17, 10),
                new(150, 160, 9 , 13, 5),
                new(150, 160, 0 , 8 , 0),

                //Age 13.5-14.4
                new(162, 172, 33, 36, 95),
                new(162, 172, 31, 32, 90),
                new(162, 172, 28, 30, 75),
                new(162, 172, 24, 27, 50),
                new(162, 172, 19, 23, 25),
                new(162, 172, 15, 18, 10),
                new(162, 172, 9 , 14, 5),
                new(162, 172, 0 , 8 , 0),

                //Age 14.5-15.4
                new(174, 184, 34, 36, 95),
                new(174, 184, 32, 33, 90),
                new(174, 184, 29, 31, 75),
                new(174, 184, 24, 28, 50),
                new(174, 184, 19, 23, 25),
                new(174, 184, 15, 18, 10),
                new(174, 184, 10, 14, 5),
                new(174, 184, 0 , 9 , 0),

                //Age 15.5-16.4
                new(186, 196, 34, 36, 95),
                new(186, 196, 32, 33, 90),
                new(186, 196, 29, 31, 75),
                new(186, 196, 25, 28, 50),
                new(186, 196, 20, 24, 25),
                new(186, 196, 16, 19, 10),
                new(186, 196, 10, 15, 5),
                new(186, 196, 0 , 9 , 0),
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
        public ArrayResults(int MinAgeInMonth, int MaxAgeMonth, int MinMark, int MakMark, int Centenary)
        {
            this.MinAgeMonth = MinAgeMonth; this.MaxAgeMonth = MaxAgeMonth; this.MinMark = MinMark; this.MaxMark = MaxMark; this.Centenary = Centenary;
        }

        public double MinAgeMonth { get; set; }
        public double MaxAgeMonth { get; set; }
        public int MinMark { get; set; }
        public int MaxMark { get; set; }
        //الترتيب المئيني
        public int Centenary { get; set; }
    }

}