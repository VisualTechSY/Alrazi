using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAcademic
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("يحب المدرسة أو يكرهها")]
        public bool LoveSchool { get; set; }
        [DisplayName("أعلى صف دراسي وصل إليه")]
        public string TopStudyLevel { get; set; }
        [DisplayName("سبب الفشل في المدرسة")]
        public string ReasonFailure { get; set; }
        [DisplayName("عدد مرات الإعادة وبأي صف")]
        public string ReplayInformation { get; set; }
        [DisplayName("الانتقال من مدرسة إلى مدرسة")]
        public string MovingSchoolInformation { get; set; }
    }
}
