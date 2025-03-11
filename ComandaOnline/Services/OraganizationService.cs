using Microsoft.EntityFrameworkCore;

namespace ComandaOnline.Services
{
    public class OrganizationService
    {
        private readonly AppDbContext _context;

        public OrganizationService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<string?> GenerateKey(int id)
        {
            var organization = await _context.Organization.FirstOrDefaultAsync(o => o.Id == id);
            if (organization is not null)
            {
                string key = organization.Id + organization.Name.Substring(4);
                return key;
            }
            else
            {
                return null;
            }


        }


    }
}
