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
	}
}