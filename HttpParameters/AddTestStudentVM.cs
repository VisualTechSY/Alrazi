namespace Alrazi.HttpParameters
{
    public class AddTestStudentVM
    {
        public int StudentId { get; set; }
        public int SerialNumber { get; set; }
        public int[] TestSubjectId { get; set; }
        public int[] TheBase { get; set; }//القاعدي
        public int[] Additional { get; set; }//الاضافي
        public double[] Mark { get; set; }
    }
}
