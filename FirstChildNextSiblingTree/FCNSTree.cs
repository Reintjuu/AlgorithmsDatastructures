using System;

namespace ADCode.FirstChildNextSiblingTree
{
	public class FCNSTree<T> : IFNCSTree<T>
	{
		public FCNSNode<T> RootNode;

		public FCNSTree(T data)
		{
			RootNode = new FCNSNode<T>(data);
		}

		public int Size()
		{
			return Size(RootNode);
		}

		public int Height()
		{
			return Height(RootNode);
		}

		public void PrintPreOrder()
		{
			Console.Write('[');
			PreOrderTraversal(RootNode);
			Console.Write("]\n");
		}
		
		private void PreOrderTraversal(FCNSNode<T> node)
		{
			if (node == null)
			{
				return;
			}

			Console.Write(node.Data);
			PreOrderTraversal(node.FirstChild);
			PreOrderTraversal(node.NextSibling);
		}

		public static int Height<T>(FCNSNode<T> node)
		{
			if (node == null)
			{
				return -1;
			}

			return Math.Max(1 + Height(node.FirstChild), Height(node.NextSibling));
		}

		public static int Size(FCNSNode<T> node)
		{
			if (node == null)
			{
				return 0;
			}

			return node.GetSize() + Size(node.FirstChild) + Size(node.NextSibling);
		}
		
		public FCNSNode<T> AddSibling(FCNSNode<T> node)
		{
			return RootNode.AddSibling(node);
		}

		public FCNSNode<T> AddChild(FCNSNode<T> node)
		{
			return RootNode.AddChild(node);
		}
		
		public FCNSNode<T> SetSibling(FCNSNode<T> node)
		{
			return RootNode.SetSibling(node);
		}

		public FCNSNode<T> SetChild(FCNSNode<T> node)
		{
			return RootNode.SetChild(node);
		}
	}
}