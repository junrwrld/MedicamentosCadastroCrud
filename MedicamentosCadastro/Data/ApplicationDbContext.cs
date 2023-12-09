using MedicamentosCadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicamentosCadastro.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<MedicamentosModel> Medicamentos { get; set; }

    }
}
