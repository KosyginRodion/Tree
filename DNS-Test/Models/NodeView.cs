using DNS_Test.Entity.Model;
using System;

namespace DNS_Test.Models
{
	[Serializable]
	public class NodeView
	{
		public int Id { get; set; }

		public string Parent { get; set; }

		public string Text { get; set; }

		public string Type { get; set; }

		public NodeView() { }

		public NodeView(Node tree)
		{
			Id = tree.Id;
			Text = tree.Name;
			Type = tree.Type;

			if(tree.ParentId == 0)
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
