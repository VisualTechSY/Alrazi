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

        public async Task<List<Diagnosis>> GetDiagnoses()
        {
            return await context.Diagnoses.ToListAsync();
        }

        public async Task<Tuple<bool, string>> AddDiagnosis(string name)
        {
            if (await context.Diagnoses.AnyAsync(x => x.Name == name))
                return Tuple.Create(false, "اسم التشخيص مكرر");
            await context.Diagnoses.AddAsync(new Diagnosis
            {
                IsActive = true,
                Name = name
            });
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت الإضافة بنجاح");
        }

        public async Task<Diagnosis> GetDiagnosisById(int id)
        {
            return await context.Diagnoses.FindAsync(id);
        }

        public async Task<Tuple<bool, string>> EditDiagnosis(int id, string name)
        {
            if (await context.Diagnoses.AnyAsync(x => x.Id != id && x.Name == name))
                return Tuple.Create(false, "الاسم موجود مسبقا");
            var diagnosis = await context.Diagnoses.FindAsync(id);
            diagnosis.Name = name;
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت العملية بنجاح");
        }

        public async Task ChangeDiagnosisState(int id)
        {
            var diagnosis = await context.Diagnoses.FindAsync(id);
            diagnosis.IsActive = !diagnosis.IsActive;
            await context.SaveChangesAsync();
        }

        public async Task<List<Nationality>> GetNationalities()
        {
            return await context.Nationalities.ToListAsync();
        }

        public async Task<Tuple<bool, string>> AddNationality(string name)
        {
            if (await context.Nationalities.AnyAsync(x => x.Name == name))
                return Tuple.Create(false, "اسم الجنسية مكرر");
            await context.Nationalities.AddAsync(new Nationality
            {
                IsActive = true,
                Name = name
            });
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت الإضافة بنجاح");
        }

        public async Task<Nationality> GetNationalityById(int id)
        {
            return await context.Nationalities.FindAsync(id);
        }

        public async Task<Tuple<bool, string>> EditNationality(int id, string name)
        {
            if (await context.Nationalities.AnyAsync(x => x.Id != id && x.Name == name))
                return Tuple.Create(false, "الاسم موجود مسبقا");
            var nationality = await context.Nationalities.FindAsync(id);
            nationality.Name = name;
            await context.SaveChangesAsync();
            return Tuple.Create(true, "تمت العملية بنجاح");
        }

        public async Task ChangeNationalityState(int id)
        {
            var nationality = await context.Nationalities.FindAsync(id);
            nationality.IsActive = !nationality.IsActive;
            await context.SaveChangesAsync();
        }

        public async Task<List<Config>> GetConfigs()
        {
            return await context.Configs.ToListAsync();
        }

        public async Task UpdateConfigs(Config[] configs)
        {
            var getAllConfigs = await context.Configs.ToListAsync();
            foreach (var item in configs)
                getAllConfigs.First(x => x.ConfigKey == item.ConfigKey).Value = item.Value;
            await context.SaveChangesAsync();
        }
    }
}
