using Alrazi.Enums;
using Alrazi.HttpParameters;
using Alrazi.Models;
using Alrazi.Tools;
using Microsoft.EntityFrameworkCore;

namespace Alrazi.Services
{
    public class ConfigService(Context context)
    {

        public async Task<List<AccessChannel>> GetAccessChannels()
        {
            return await context.AccessChannels.ToListAsync();
        }

        public async Task<Tuple<bool, string>> AddAccessChannel(string name)
        {
            if (await context.AccessChannels.AnyAsync(x => x.Name == name))
                return Tuple.Create(false , "اسم الجهة مكرر");
            await context.AccessChannels.AddAsync(new AccessChannel
            {
                IsActive = true,
                Name = name
            });
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت الإضافة بنجاح");
        }

        public async Task<AccessChannel> GetAccessChannelById(int id)
        {
            return await context.AccessChannels.FindAsync(id);
        }

        public async Task<Tuple<bool, string>> EditAccessChannel(int id, string name)
        {
            if (await context.AccessChannels.AnyAsync(x => x.Id != id && x.Name == name))
                return Tuple.Create(false , "الاسم موجود مسبقا");
            var accessChannel = await context.AccessChannels.FindAsync(id);
            accessChannel.Name = name;
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت العملية بنجاح");
        }

        public async Task ChangeAccessChannelState(int id)
        {
            var accessChannel = await context.AccessChannels.FindAsync(id);
            accessChannel.IsActive = !accessChannel.IsActive;
            await context.SaveChangesAsync();
        }
    }
}
