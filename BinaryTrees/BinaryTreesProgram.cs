using System;

namespace ADCode.BinaryTrees
{
	public class BinaryTreesProgram
	{
		public BinaryTreesProgram()
		{
			var tree = new FCNSTree<char>('a');
				
			var lastAdded = tree
				.AddChild(new FCNSNode<char>('b'))
				.AddSibling(new FCNSNode<char>('c'))
				.AddSibling(new FCNSNode<char>('d'));
			lastAdded.AddChild(new FCNSNode<char>('h'));
			lastAdded.AddSibling(new FCNSNode<char>('e'));
			
			tree.PrintPreOrder();
			Console.WriteLine(FCNSTree<char>.SizeHelper(tree.RootNode));
		}
	}
}