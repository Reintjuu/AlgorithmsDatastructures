using System;
using ADCode.BinarySearchTrees;

namespace ADCode.Toets
{
	public class Opgave2
	{
		public Opgave2()
		{
			BinarySearchTree<int> bst = new BinarySearchTree<int>();
			bst.Insert(6);
			bst.Insert(2);
			bst.Insert(8);
			// bst.Insert(1);
			bst.Insert(4);
			bst.Insert(3);
			bst.Print();

			Console.WriteLine(bst.FindSecondMin());
		}
	}
}