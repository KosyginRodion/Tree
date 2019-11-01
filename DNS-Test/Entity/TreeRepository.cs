using System;
using System.Collections.Generic;
using System.Linq;
using DNS_Test.Entity.Model;

namespace DNS_Test.Entity
{
	public class TreeRepository : ITreeRepository
	{
		private readonly TreeContext Context;

		public TreeRepository(TreeContext context)
		{
			this.Context = context;
		}

		public IEnumerable<Node> GetTree()
		{
			var tree = Context.Nodes.ToList();
			return tree;
		}

		public void Update(int id, int newParentId)
		{
			var node = Context.Nodes.Single(t => t.Id == id);
			var parentNode = Context.Nodes.SingleOrDefault(t => t.Id == newParentId);
			if (parentNode?.Type == "file")
			{
				throw new ApplicationException("Нельзя перемести элемент в файл");
			}

			node.ParentId = newParentId;

			Context.SaveChanges();
		}
	}
}
