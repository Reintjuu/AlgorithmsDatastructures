using System;

namespace ADCode.BinaryTrees
{
	public class BinaryTree<T> : IBinaryTree<T>
	{
		public BinaryNode<T> Root { get; private set; }

		public BinaryTree()
		{
			Root = null;
		}

		public BinaryTree(T rootItem)
		{
			Root = new BinaryNode<T>(rootItem);
		}

		public BinaryTree(BinaryNode<T> node)
		{
			Root = node;
		}

		public BinaryNode<T> GetRoot()
		{
			return Root;
		}

		public int Size()
		{
			return BinaryNode<T>.Size(Root);
		}

		public int Height()
		{
			return BinaryNode<T>.Height(Root);
		}

		public int Leaves()
		{
			return BinaryNode<T>.Leaves(Root);
		}

		public int OneNull()
		{
			return BinaryNode<T>.OneNull(Root);
		}

		public int NoneNull()
		{
			return BinaryNode<T>.NoneNull(Root);
		}

		public void PrintPreOrder()
		{
			Root?.PrintPreOrder();
		}

		public void PrintInOrder()
		{
			Root?.PrintInOrder();
		}

		public void PrintPostOrder()
		{
			Root?.PrintPostOrder();
		}

		public void MakeEmpty()
		{
			Root = null;
		}

		public bool IsEmpty()
		{
			return Root == null;
		}

		public void Merge(T rootItem, BinaryTree<T> first, BinaryTree<T> second)
		{
			if (first.Root == second.Root && first.Root != null)
			{
				throw new ArgumentException("Argument is not valid.");
			}

			// Allocate new node
			Root = new BinaryNode<T>(rootItem, first.Root, second.Root);

			// Ensure that every node is in one tree.
			if (first != this)
			{
				first.Root = null;
			}

			if (second != this)
			{
				second.Root = null;
			}
		}

		public override string ToString()
		{
			return Root?.ToString() ?? string.Empty;
		}
	}
}