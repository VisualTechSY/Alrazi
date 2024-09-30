using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alrazi.Models
{
    public class StudentAutonomy
    {
        [ForeignKey("Student")]
        public int Id { get; set; }
        public Student Student { get; set; }
        [DisplayName("تناوله الطعام")]
        public string Food { get; set; }
        [DisplayName("الشراب")]
        public string Drink { get; set; }
        [DisplayName("الاعتناء بالنظافة")]
        public string Cleanliness { get; set; }
        [DisplayName("ارتداء الملابس")]
        public string Clothes { get; set; }
    }
}
