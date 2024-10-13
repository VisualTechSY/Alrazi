using Alrazi.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMistake
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("عادية مقارنته بزملائه")]
        public string CompareColleagues { get; set; }
        [DisplayName("كثيرة مقارنة بزملائه وتستدعي تشخيص أعمق وأدق")]
        public string AlotCompareColleagues { get; set; }
        [DisplayName("غيــر عادية مقارنة بزملائه وتستدعي تشخيص متمعن")]
        public string AFewCompareColleagues { get; set; }
        [DisplayName("وصف سلوكي لنتائج دراسة أعمال الطالب يشتمل على نوع الأخطاء التي يقع فيها")]
        public string BehavioralDescription { get; set; }
        [DisplayName("كيفية تعامل المدرسة مع سلوكيات الطالب غير المرغوب فيه")]
        public string SchoolDealing { get; set; }
        [DisplayName("هل متفهم بحسن التصرف ؟ أم مشاكس يصعب ضبط سلوكه")]
        public string UnderstandingWellBehaved { get; set; }
        [DisplayName("هل يعتــــــدي على الآخرين ؟ أم يخاف أن يعتدي عليه الآخرين")]
        public string AssaultsOthers { get; set; }
        [DisplayName("هل يعتمد على نفسه في معظم الأمور ؟ أم يعتمد غالبا على الآخرين")]
        public string SelfReliant { get; set; }
        [DisplayName("يعبـــــــر عن نفسه بكلام واضح ؟ أم مرتبك في التعبير عما يريد")]
        public string ClearExpression { get; set; }
    }
}
