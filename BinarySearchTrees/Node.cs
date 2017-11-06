using System;
using System.Text;

namespace ADCode.BinarySearchTrees
{
	public class Node<T> where T : IComparable
	{
		public T element;
		public Node<T> left;
		public Node<T> right;

		public Node(T x)
		{
			element = x;
			left = null;
			right = null;
		}

		public override string ToString()
		{
			return ToStringBuilder(new StringBuilder(), true, new StringBuilder()).ToString();
		}

		private StringBuilder ToStringBuilder(StringBuilder prefix, bool isTail, StringBuilder sb)
		{
			right?.ToStringBuilder(new StringBuilder().Append(prefix).Append(isTail ? "│   " : "    "), false, sb);
			sb.Append(prefix).Append(isTail ? "└── " : "┌── ").Append(element).Append("\n");
			left?.ToStringBuilder(new StringBuilder().Append(prefix).Append(isTail ? "    " : "│   "), true, sb);
			return sb;
		}
		
		/// <param name="t">The root to calucate from.</param>
		/// <returns>The size of the binary tree rooted at t.</returns>
		public static int Size(Node<T> t)
		{
			if (t == null)
			{
				return 0;
			}

			return 1 + Size(t.left) + Size(t.right);
		}
		
		/// <param name="t">The root to calucate from.</param>
		/// <returns>The height of the binary tree rooted at t.</returns>
		public static int Height(Node<T> t)
		{
			if (t == null)
			{
				return -1;
			}

			return 1 + Math.Max(Height(t.left), Height(t.right));
		}
	}
}