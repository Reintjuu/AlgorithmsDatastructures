﻿using System;

namespace ADCode.BinarySearchTrees
{
	public class BinarySearchTreesProgram
	{
		public BinarySearchTreesProgram()
		{
			BinarySearchTree tree = new BinarySearchTree();
			tree.Insert(6);
			tree.Insert(7);
			tree.Insert(4);
			tree.Insert(2);
			tree.Insert(5);
			Console.WriteLine(tree.InOrder());
		}
	}
}