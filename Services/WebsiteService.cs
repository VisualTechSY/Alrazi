using Alrazi.Models;
using Alrazi.Models.Test;
using Alrazi.Tools;
using Alrazi.ViewModel;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class WebsiteService(Context context)
    {
        public async Task<Blog> GetBlog(int id)
        {
            return await context.Blogs.Include(x => x.BlogFiles).FirstAsync(x => x.Id == id);
        }

        public async Task<List<Blog>> GetLastBlog(int count)
        {
            return await context.Blogs
                .Include(x => x.BlogFiles)
                .Where(x=> x.IsPin)
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Blog>> GetBlogs()
        {
            return await context.Blogs
                .Include(x => x.BlogFiles)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task AddMessage(ContactMessage contactMessage)
        {
            await context.ContactMessages.AddAsync(contactMessage);
            await context.SaveChangesAsync();
        }

        public async Task RemoveBlog(int id)
        {
            var getBlog = await GetBlog(id);
            context.BlogFiles.RemoveRange(getBlog.BlogFiles);
            context.Blogs.Remove(getBlog);
            await context.SaveChangesAsync();
        }

        public async Task ChangePin(int id)
        {
            var getBlog = await GetBlog(id);
            getBlog.IsPin = !getBlog.IsPin;
            await context.SaveChangesAsync();
        }

        public async Task UpdateContact(int id)
        {
            var getContact = await context.ContactMessages.FindAsync(id);
            getContact.IsRead = true;
            await context.SaveChangesAsync();
        }

        public async Task<ContactMessage> GetContact(int id)
        {
            return await context.ContactMessages.FindAsync(id);
        }

        public async Task<List<ContactMessage>> GetContacts(bool isRead)
        {
            return await context.ContactMessages.Where(x => x.IsRead == isRead).ToListAsync();
        }

        public async Task AddBlog(string title , string details , List<IFormFile> files , List<string> videos)
        {

            string plainTextDetails = ConvertHtmlToPlainText(details);
            string[] words = plainTextDetails.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string shortDetails = string.Join(" ", words.Take(15));

            var blog = new Blog
            {
                PostDate = DateTime.Now,
                Details = details,
                Title = title,
                IsPin = false,
                ShortDetails = shortDetails,
                BlogFiles = new List<BlogFile>()
            };
            foreach (var item in files)
            {
                blog.BlogFiles.Add(new BlogFile
                {
                    Url = CloudinarryManager.UploadImage(item).Uri,
                    IsIamge = true
                });
            }
            foreach (var item in videos)
            {
                blog.BlogFiles.Add(new BlogFile
                {
                    Url = item,
                    IsIamge = false
                });
            }
            await context.Blogs.AddAsync(blog);
            await context.SaveChangesAsync();
        }

        string ConvertHtmlToPlainText(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc.DocumentNode.InnerText;
        }

    }
}
