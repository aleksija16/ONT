using Microsoft.EntityFrameworkCore;
using Projekat_1.Models;

namespace Projekat_1.Models
{
    public class OrganizacijaContext : DbContext
    {
        public OrganizacijaContext(DbContextOptions options) :base(options)
        {

        }

    }
}