using Microsoft.EntityFrameworkCore;
using CheckList.Api.Models;

namespace CheckList.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ItemChecklist> ItemChecklists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais, como relacionamentos
            modelBuilder.Entity<ItemChecklist>()
                .HasOne<Checklist>() // Define a entidade relacionada como Checklist
                .WithMany(c => c.Itens)    // Checklist tem muitos ItemChecklists
                .HasForeignKey(i => i.ChecklistId); // Chave estrangeira em ItemChecklist
            
            modelBuilder.Entity<Checklist>()
                .Property(c => c.DataCriacao)
                .HasColumnType("datetime2"); // Ajustar para datetime2 se o banco de dados usar datetime2

        }
    }
}