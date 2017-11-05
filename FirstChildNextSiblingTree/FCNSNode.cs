using System;

namespace ADCode.FirstChildNextSiblingTree
{
	public class FCNSNode<T>
	{
		public FCNSNode<T> FirstChild;
		public FCNSNode<T> NextSibling;

		public T Data;

		public FCNSNode(T data)
		{
			Data = data;
		}

		public FCNSNode()
		{
		}

		public int Height()
		{
			return Math.Max(1 + FirstChild.Height(), NextSibling.Height());
		}

		public FCNSNode<T> AddSibling(FCNSNode<T> node)
		{
			FCNSNode<T> c = this;
			while (c.NextSibling != null)
			{
				c = c.NextSibling;
			}

			c.NextSibling = node;

			return node;
		}

		public FCNSNode<T> AddChild(FCNSNode<T> node)
		{
			if (FirstChild == null)
			{
				FirstChild = node;
			}
			else
			{
				FirstChild.AddSibling(node);
			}

			return node;
		}

		public FCNSNode<T> SetSibling(FCNSNode<T> node)
		{
			NextSibling = node;
			return node;
		}

		public FCNSNode<T> SetChild(FCNSNode<T> node)
		{
			FirstChild = node;
			return node;
		}

		public int GetSize()
		{
			return 1;
		}
	}
}