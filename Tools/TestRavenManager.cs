using Alrazi.ViewModel;

namespace Alrazi.Tools
{
    public class TestRavenManager
    {
        static List<ArraySoring> ArraySoring;

        public static void GetRavenResault(int mark, Birthday birthday)
        {
            int centenary = 0;
            var obj = ArraySoring.FirstOrDefault(x => x.Mark == mark && birthday.CalcAge >= x.MinAge && birthday.CalcAge <= x.MaxAge);
            if (obj is not null)
                centenary = obj.Centenary;


            string IQRange = GetTestRavenResaultIQ(centenary);
            string ResaultTitle = GetTestRavenResaultTitle(centenary);
        }



        static TestRavenManager()
        {
            ArraySoring =
                [
                new(5.5, 6.4, 28, 95),
                new(5.5, 6.4, 24, 90),
                new(5.5, 6.4, 21, 75),
                new(5.5, 6.4, 17, 50),
                new(5.5, 6.4, 14, 25),
                new(5.5, 6.4, 11, 10),
                new(5.5, 6.4, 3, 5),

                new(6.5, 7.4, 28, 95),
                new(6.5, 7.4, 27, 90),
                new(6.5, 7.4, 23, 75),
                new(6.5, 7.4, 19, 50),
                new(6.5, 7.4, 15, 25),
                new(6.5, 7.4, 13, 10),
                new(6.5, 7.4, 11, 5),


                ];
        }


        public static string GetTestRavenResaultIQ(int Centenary)
        {
            if (Centenary <= 4) return "40-54";
            else if (Centenary <= 9) return "55-69";
            else if (Centenary <= 24) return "70-79";
            else if (Centenary <= 49) return "80-89";
            else if (Centenary <= 74) return "90-109";
            else if (Centenary <= 89) return "110-119";
            else if (Centenary <= 94) return "120-129";
            else return "130-144";
        }

        public static string GetTestRavenResaultTitle(int Centenary)
        {
            if (Centenary <= 4) return "تخلف شديد";
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
    class ArraySoring
    {
        public ArraySoring(double MinAge, double MaxAge, int Mark, int Centenary)
        {
            this.MinAge = MinAge; this.MaxAge = MaxAge; this.Mark = Mark; this.Centenary = Centenary;
        }

        public double MinAge { get; set; }
        public double MaxAge { get; set; }
        public int Mark { get; set; }
        //الترتيب المئيني
        public int Centenary { get; set; }
    }

}