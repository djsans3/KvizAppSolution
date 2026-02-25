using Microsoft.EntityFrameworkCore;

namespace Kviz.Core
{
	public class KvizDbContext : DbContext
	{
		public DbSet<Korisnik> Korisnici { get; set; }
		public DbSet<Profesor> Profesori { get; set; }
		public DbSet<Student> Studenti { get; set; }
		public DbSet<Ispit> Ispiti { get; set; }
		public DbSet<Pitanje> Pitanja { get; set; }
		public DbSet<SingleChoicePitanje> SingleChoicePitanja { get; set; }
		public DbSet<InputPitanje> InputPitanja { get; set; }
		public DbSet<Rezultat> Rezultati { get; set; }

		public KvizDbContext() { }

		public KvizDbContext(DbContextOptions<KvizDbContext> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var folder = AppDomain.CurrentDomain.BaseDirectory;
				var dbPath = System.IO.Path.Combine(folder, "kviz.db");
				optionsBuilder
					.UseSqlite($"Data Source={dbPath}");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// TPH (Table Per Hierarchy) za Korisnik hijerarhiju
			modelBuilder.Entity<Korisnik>()
				.HasDiscriminator<string>("TipKorisnika")
				.HasValue<Profesor>("Profesor")
				.HasValue<Student>("Student");

			modelBuilder.Entity<Korisnik>()
				.HasKey(k => k.Username);

			// TPH za Pitanje hijerarhiju
			modelBuilder.Entity<Pitanje>()
				.HasDiscriminator<string>("TipPitanja")
				.HasValue<SingleChoicePitanje>("SingleChoice")
				.HasValue<InputPitanje>("Input");

			// Ispit -> Profesor veza
			modelBuilder.Entity<Ispit>()
				.HasOne(i => i.Profesor)
				.WithMany(p => p.Ispiti)
				.HasForeignKey(i => i.ProfesorUsername);

			// Ispit -> Pitanja veza (kompozicija)
			modelBuilder.Entity<Pitanje>()
				.HasOne(p => p.Ispit)
				.WithMany(i => i.SkupPitanja)
				.HasForeignKey(p => p.IspitId);

			// Rezultat -> Ispit veza
			modelBuilder.Entity<Rezultat>()
				.HasOne(r => r.Ispit)
				.WithMany()
				.HasForeignKey(r => r.IspitId);

			// Rezultat -> Student veza
			modelBuilder.Entity<Rezultat>()
				.HasOne(r => r.Student)
				.WithMany(s => s.Rezultati)
				.HasForeignKey(r => r.StudentUsername);

			// Seed podataka - hardkodirani korisnici
			modelBuilder.Entity<Profesor>().HasData(
				new Profesor { Username = "profesor", Password = "87654321" }
			);

			modelBuilder.Entity<Student>().HasData(
				new Student { Username = "student", Password = "12345678" }
			);
		}
	}
}
