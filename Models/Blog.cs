using System.Text.RegularExpressions;

namespace Alrazi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string ShortDetails { get; set; }
        public bool IsPin { get; set; }
        public DateTime PostDate { get; set; }
        public string DateToView => PostDate.ToShortDateString();
        public List<BlogFile> BlogFiles { get; set; }
        public string GetShortDetails()
        {  // إزالة جميع الـ HTML tags
            var plainText = Regex.Replace(Details, "<.*?>", String.Empty);

            // تحويل الرموز المشفرة (مثل &nbsp;) إلى نص عادي
            var decodedText = System.Web.HttpUtility.HtmlDecode(plainText);

            // أخذ أول 7 كلمات من النص
            var firstSevenWords = string.Join(" ", decodedText.Split(' ').Take(15));
            return firstSevenWords;
        }
    }
}
