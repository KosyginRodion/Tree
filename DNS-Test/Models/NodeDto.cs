using DNS_Test.Entity.Model;
using System;

namespace DNS_Test.Models
{
	[Serializable]
	public class NodeDto
	{
		public int Id { get; set; }

		public string Parent { get; set; }

		public string Text { get; set; }

		public string Type { get; set; }

		public NodeDto() { }

		public NodeDto(Node tree)
		{
			Id = tree.Id;
			Text = tree.Name;
			Type = tree.Type;

			// Родительский элемент со значением "#" соотвествует корню дерева
			if (tree.ParentId == 0)
			{
				Parent = "#";
			}
			else
			{
				Parent = tree.ParentId.ToString();
			}
		}
	}
}
