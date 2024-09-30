using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentMedical
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("تعرض الطفل إلى إصابة في الرأس")]
        public bool HeadInjury { get; set; }
        [DisplayName("تعرض الطفل إلى التهبات شديدة")]
        public bool SevereInfections { get; set; }
        [DisplayName("يعاني من مشاكل مرتبطة باللقاح")]
        public bool VaccineRelatedProblems { get; set; }
        [DisplayName("الفحوصات التي أجريت للطفل")]
        public string Tests { get; set; }
    }
}
