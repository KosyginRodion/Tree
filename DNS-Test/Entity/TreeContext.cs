using DNS_Test.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace DNS_Test.Entity
{
	public class TreeContext : DbContext
	{
		public DbSet<Node> Nodes { get; set; }

		public TreeContext(DbContextOptions<TreeContext> options)
		: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Node>().HasData(
				new Node[]
				{
					new Node
					{
						Id = 1,
						ParentId = 0,
						Name = "Документы",
						Type = "folder"
					},
					new Node
					{
						Id = 2,
						ParentId = 0,
						Name = "Учеба",
						Type = "folder"
					},
					new Node
					{
						Id = 3,
						ParentId = 1,
						Name = "Паспортные данные",
						Type = "folder"
					},
					new Node
					{
						Id = 4,
						ParentId = 1,
						Name = "ИНН",
						Type = "folder"
					},
					new Node
					{
						Id = 5,
						ParentId = 3,
						Name = "Первая страница (копия)",
						Type = "file"
					},
					new Node
					{
						Id = 6,
						ParentId = 3,
						Name = "Прописка (копия)",
						Type = "file"
					},
					new Node
					{
						Id = 7,
						ParentId = 2,
						Name = "Курсовые",
						Type = "folder"
					},
					new Node
					{
						Id = 8,
						ParentId = 2,
						Name ="Диплом",
						Type = "folder"
					},
					new Node
					{
						Id = 9,
						ParentId = 7,
						Name ="1 семестр",
						Type = "file"
					},
					new Node
					{
						Id = 10,
						ParentId = 7,
						Name ="2 семестр",
						Type = "file"
					},
					new Node
					{
						Id = 11,
						ParentId = 8,
						Name ="ВКР",
						Type = "file"
					}
				});
		}
	}
}
