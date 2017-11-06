using System;
using System.Text;

namespace ADCode.BinaryTrees
{
	public class BinaryNode<T>
	{
		public T Element { get; set; }
		public BinaryNode<T> Left { get; set; }
		public BinaryNode<T> Right { get; set; }

		public BinaryNode() : this(default(T))
		{
		}

		public BinaryNode(T element, BinaryNode<T> left = null, BinaryNode<T> right = null)
		{
			Element = element;
			Left = left;
			Right = right;
		}

		/// <param name="t">The root to calucate from.</param>
		/// <returns>The size of the binary tree rooted at t.</returns>
		public static int Size(BinaryNode<T> t)
		{
			if (t == null)
			{
				return 0;
			}

			return 1 + Size(t.Left) + Size(t.Right);
		}

		/// <param name="t">The root to calucate from.</param>
		/// <returns>The height of the binary tree rooted at t.</returns>
		public static int Height(BinaryNode<T> t)
		{
			if (t == null)
			{
				return -1;
			}

			return 1 + Math.Max(Height(t.Left), Height(t.Right));
		}

		/// <returns>A reference to a node that is the root of a duplicate of the binary tree rooted at the current node.</returns>
		public BinaryNode<T> Duplicate()
		{
			BinaryNode<T> root = new BinaryNode<T>(Element);

			// If there's a left subtree...
			if (Left != null)
			{
				// ... Duplicate; attach.
				root.Left = Left.Duplicate();
			}

			// If there's a right subtree...
			if (Right != null)
			{
				// ... Duplicate; attach.
				root.Right = Right.Duplicate();
			}

			// Return resulting tree.
			return root;
		}

		public override string ToString()
		{
			return ToStringBuilder(new StringBuilder(), true, new StringBuilder()).ToString();
		}

		private StringBuilder ToStringBuilder(StringBuilder prefix, bool isTail, StringBuilder sb)
		{
			Right?.ToStringBuilder(new StringBuilder().Append(prefix).Append(isTail ? "│   " : "    "), false, sb);
			sb.Append(prefix).Append(isTail ? "└── " : "┌── ").Append(Element).Append("\n");
			Left?.ToStringBuilder(new StringBuilder().Append(prefix).Append(isTail ? "    " : "│   "), true, sb);
			return sb;
		}

		public static int Leaves(BinaryNode<T> node)
		{
			if (node == null)
			{
				return 0;
			}
			
			if (node.Left == null || node.Right == null)
			{
				return 1;
			}

			return Leaves(node.Left) + Leaves(node.Right);
		}

		public static int OneNull(BinaryNode<T> node)
		{
			if (node == null)
			{
				return 0;
			}
			
			if (node.Left != null && node.Right == null || node.Left == null && node.Right != null)
			{
				return 1;
			}

			return OneNull(node.Left) + OneNull(node.Right);
		}

		public static int NoneNull(BinaryNode<T> node)
		{
			if (node == null)
			{
				return 0;
			}
			
			if (node.Left != null && node.Right != null)
			{
				return 1;
			}

			return NoneNull(node.Left) + NoneNull(node.Right);
		}

		public void PrintPreOrder()
		{
			Console.WriteLine(PreOrder(this));
		}

		private string PreOrder(BinaryNode<T> node)
		{
			if (node == null)
			{
				return string.Empty;
			}

			return node.Element + PreOrder(node.Left) + " " + PreOrder(node.Right);
		}

		public void PrintPostOrder()
		{
			Console.WriteLine(PostOrder(this));
		}

		private string PostOrder(BinaryNode<T> node)
		{
			if (node == null)
			{
				return string.Empty;
			}

			return PostOrder(node.Left) + " " + PostOrder(node.Right) + " " + node.Element;
		}

		public void PrintInOrder()
		{
			Console.WriteLine(InOrder(this));
		}

		private string InOrder(BinaryNode<T> node)
		{
			if (node == null)
			{
				return string.Empty;
			}

			return InOrder(node.Left) + " " + node.Element + " " + InOrder(node.Right);
		}
	}
}