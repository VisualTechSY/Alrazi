using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Account = CloudinaryDotNet.Account;

namespace Alrazi.Tools
{
    public class CloudinaryFileInfo
    {
        public required string PublicId { get; set; }
        public required string Uri { get; set; }
    }

    public class CloudinarryManager
    {
        public static Cloudinary Cloudinary;
        public const string CloudName = "dveqcjex2";
        public const string API_Key = "248225796359599";
        public const string API_Secret = "UZdbuvLBIXYe9oldr1a_zjfvz1Q";
        static CloudinarryManager()
        {
            Account account = new Account(CloudName, API_Key, API_Secret);
            Cloudinary = new Cloudinary(account);
        }

        
        public static CloudinaryFileInfo UploadImage(IFormFile file)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            };
            var result = Cloudinary.Upload(uploadParams);
            return new CloudinaryFileInfo
            {
                PublicId = result.PublicId,
                Uri = result.Uri.ToString()
            };
        }

       
        public static CloudinaryFileInfo UploadVideo(IFormFile file)
        {
            var uploadParams = new VideoUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
            };
            var result = Cloudinary.Upload(uploadParams);
            return new CloudinaryFileInfo
            {
                PublicId = result.PublicId,
                Uri = result.Uri.ToString()
            };
        }
    }
}
