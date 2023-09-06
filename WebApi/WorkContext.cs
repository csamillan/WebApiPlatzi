using Microsoft.EntityFrameworkCore;
using PlatziEntityFramework.Model;

namespace PlatziEntityFramework
{
    public class WorkContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Work> Works { get; set; }

        public WorkContext(DbContextOptions<WorkContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categoriesInit = new List<Category>();
            categoriesInit.Add(new Category() { CategoryID = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06b0"), Name = "Actividades Pendientes", Weigth = 20 });
            categoriesInit.Add(new Category() { CategoryID = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06b1"), Name = "Actividades Personales", Weigth = 50 });

            modelBuilder.Entity<Category>(Category =>
            {
                Category.ToTable("Category");
                Category.HasKey(p => p.CategoryID);

                Category.Property(p => p.Name).IsRequired().HasMaxLength(150);
                Category.Property(p => p.Description).IsRequired(false);
                Category.Property(p => p.Weigth);

                Category.HasData(categoriesInit);
            });

            List<Work> worksInit = new List<Work>();
            worksInit.Add(new Work() { WorkId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06C0"), CategoryId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06b0"), Priority =  Priority.Medium, Title = "Pago de Servicios Publicos", DateCreate = DateTime.Now });
            worksInit.Add(new Work() { WorkId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06C1"), CategoryId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06b1"), Priority = Priority.Low, Title = "terminar de ver pelicula en netflix", DateCreate = DateTime.Now });
            worksInit.Add(new Work() { WorkId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06C2"), CategoryId = Guid.Parse("32a46c4e-e2f2-4b0c-9fc1-cf0f4cbe06b1"), Priority = Priority.High, Title = "Dar examenes de devsu antes del domingo", DateCreate = DateTime.Now });
            modelBuilder.Entity<Work>(Work =>
            {
                Work.ToTable("Work");
                Work.HasKey(p => p.WorkId);

                Work.HasOne(p => p.Category).WithMany(p => p.Works).HasForeignKey(p => p.CategoryId); //HasOne y withMany hace referencia a la coleccion creada en categoria y relacionarla con tarea para asi crear una clave foranea

                Work.Property(p => p.Title).IsRequired().HasMaxLength(200);
                Work.Property(p => p.Description).HasMaxLength(200).IsRequired(false);
                Work.Property(p => p.Priority);
                Work.Property(p => p.DateCreate);
                Work.Property(p => p.comentary).HasMaxLength(150).IsRequired(false);

                Work.Ignore(p => p.Summary); //Se utiliza cuando no qieres que un campo no lo mapee

                Work.HasData(worksInit);
            });
        }
    }
}
