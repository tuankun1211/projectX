using CQRS.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS.Contexts
{
    public interface ICQRSContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}