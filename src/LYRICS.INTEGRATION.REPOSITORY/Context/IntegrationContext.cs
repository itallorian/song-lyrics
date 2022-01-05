using LYRICS.INTEGRATION.REPOSITORY.Models.Integration.Tables;
using Microsoft.EntityFrameworkCore;

namespace LYRICS.INTEGRATION.REPOSITORY.Context
{
    public partial class IntegrationContext : DbContext
    {
        public IntegrationContext() { }

        public IntegrationContext(DbContextOptions<IntegrationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=INTEGRATION;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TB_LYRICS_SEARCH>(entity =>
            {
                entity.HasKey(e => e.LYRIC_SEARCH).HasName("PK__TB_LYRIC__526C96A555544259");

                entity.Property(e => e.LYRIC_SEARCH).HasColumnType("numeric(15, 0)").ValueGeneratedOnAdd();
                entity.Property(e => e.AUTHOR).IsUnicode(false);
                entity.Property(e => e.TITLE).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        #region [ TABLES ]

        public virtual DbSet<TB_LYRICS_SEARCH> TB_LYRICS_SEARCH { get; set; } = null!;

        #endregion [ TABLES ]
    }
}
