namespace Alrazi.HttpParameters
{
    public class AddTestStudentVM
    {
        public int StudentId { get; set; }
        public int SerialNumber { get; set; }
        public int[] TestSubjectId { get; set; }
        public int[] NumberCorrectAnswers { get; set; }
        public double[] Mark { get; set; }
    }
}
