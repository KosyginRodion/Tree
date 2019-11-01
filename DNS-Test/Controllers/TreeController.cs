using System.Collections.Generic;
using System.Linq;
using DNS_Test.Entity;
using DNS_Test.Entity.Model;
using DNS_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNS_Test.Controllers
{
	[Produces("application/json")]
	[Route("api/Tree")]
	public class TreeController : Controller
	{
		private readonly ITreeRepository Repository;

		public TreeController(ITreeRepository repository)
		{
			this.Repository = repository;
		}

		[HttpGet]
		public List<NodeDto> GetTree()
		{
			// Преобразуем дерево в тип объекта, с которым будет работать плагин jsTree
			var tree = Repository.GetTree().Select(t => new NodeDto(t)).ToList();

			return tree;
		}

		[HttpPost]
		public bool UpdateNode(string id, string parentId)
		{
			try
			{
				var nodeId = int.Parse(id);
				var parentNodeId = 0;

				// Родительский элемент со значением "#" соотвествует корню дерева
				if (parentId != "#")
				{
					parentNodeId = int.Parse(parentId);
				}
				Repository.Update(nodeId, parentNodeId);

				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}