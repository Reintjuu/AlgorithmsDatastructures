using System;

namespace ADCode.BinaryTrees
{
	public class BinaryTreesProgram
	{
		public BinaryTreesProgram()
		{
			BinaryNode<int> root =
				new BinaryNode<int>(4,
					new BinaryNode<int>(2,
						new BinaryNode<int>(1), new BinaryNode<int>(3)),
					new BinaryNode<int>(6, new BinaryNode<int>(3)));
			BinaryTree<int> tree = new BinaryTree<int>(root);
			
			BinaryNode<int> root2 =
				new BinaryNode<int>(4,
					new BinaryNode<int>(2,
						new BinaryNode<int>(1), new BinaryNode<int>(3)),
					new BinaryNode<int>(6, new BinaryNode<int>(3)));
			BinaryTree<int> tree2 = new BinaryTree<int>(root2);
			tree.Merge(5, tree, tree2);
			
			Console.WriteLine(tree.ToString());
			Console.WriteLine($"Leaves: {tree.Leaves()}");
			Console.WriteLine($"Nodes with one child: {tree.OneNull()}");
			Console.WriteLine($"Nodes with two children: {tree.NoneNull()}");
		}
	}
}