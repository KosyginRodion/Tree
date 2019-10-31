using DNS_Test.Entity.Model;
using System.Collections.Generic;

namespace DNS_Test.Entity
{
	public interface ITreeRepository
	{
		IEnumerable<Node> GetTree();

		void Update(int id, int newParentId);
	}
}
