using System;

namespace ADCode.FirstChildNextSiblingTree
{
	public class FirstChildNextSiblingProgram
	{
		public FirstChildNextSiblingProgram()
		{
			var tree = new FCNSTree<char>('a');
				
			var lastAdded = tree
				.AddChild(new FCNSNode<char>('b'))
				.AddSibling(new FCNSNode<char>('c'))
				.AddSibling(new FCNSNode<char>('d'));
			lastAdded.AddChild(new FCNSNode<char>('h'));
			lastAdded.AddSibling(new FCNSNode<char>('e'));
			
			tree.PrintPreOrder();
			Console.WriteLine(tree.Size());
		}
	}
}