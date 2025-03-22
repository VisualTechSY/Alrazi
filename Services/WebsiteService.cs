using Alrazi.Models;
using Alrazi.Models.Test;
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

        public async Task UpdateContact(int id)
        {
            var getContact = await context.ContactMessages.FindAsync(id);
            getContact.IsRead = true;
            await context.SaveChangesAsync();
        }

        public async Task<List<ContactMessage>> GetContacts(bool isRead)
        {
            return await context.ContactMessages.Where(x => x.IsRead == isRead).ToListAsync();
        }

    }
}
