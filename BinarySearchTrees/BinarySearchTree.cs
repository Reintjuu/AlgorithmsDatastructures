using System;

namespace ADCode.BinarySearchTrees
{
	public class BinarySearchTree<T> : IBinarySearchTree<T> where T : IComparable
	{
		private Node<T> root;

		public BinarySearchTree()
		{
			root = null;
		}

		public void Insert(T value)
		{
			root = Insert(value, root);
		}

		public string InOrder()
		{
			return Traverse(root);
		}

		private string Traverse(Node<T> node)
		{
			if (node == null)
			{
				return string.Empty;
			}

			return Traverse(node.left) + " " + node.element + " " + Traverse(node.right);
		}

		public static int Height(Node<T> node)
		{
			if (node == null)
			{
				return -1;
			}

			return Math.Max(1 + Height(node.left), 1 + Height(node.right));
		}

		public override string ToString()
		{
			return root.ToString();
		}

		/// <summary>
		/// Even more beautiful than the ToString method but writes directly to the console.
		/// </summary>
		public void Print()
		{
			root.Print();
		}

		public void Remove(T value)
		{
			root = Remove(value, root);
		}

		public void RemoveMin()
		{
			root = RemoveMin(root);
		}

		public T Find(T value)
		{
			return ElementAt(Find(value, root));
		}

		public T FindMin()
		{
			return ElementAt(FindMin(root));
		}

		public T FindMax()
		{
			return ElementAt(FindMax(root));
		}

		public void MakeEmpty()
		{
			root = null;
		}

		public bool IsEmpty()
		{
			return root == null;
		}

		/// <summary>
		/// Gets element field.
		/// </summary>
		/// <param name="node">The node</param>
		/// <returns>The element field</returns>
		/// <exception cref="NullReferenceException">If the given node is null.</exception>
		private T ElementAt(Node<T> node)
		{
			if (node == null)
			{
				throw new NullReferenceException("Node is null");
			}
			
			return node.element;
		}

		/// <summary>
		/// Find an item in a subtree.
		/// </summary>
		/// <param name="value">The value to find.</param>
		/// <param name="node">The node that roots the tree.</param>
		/// <returns>Node containing the matched item.</returns>
		private Node<T> Find(T value, Node<T> node)
		{
			while (node != null)
			{
				if (value.CompareTo(node.element) < 0)
				{
					// Go to left node if smaller.
					node = node.left;
				}
				else if (value.CompareTo(node.element) > 0)
				{
					// Go to right node if bigger.
					node = node.right;
				}
				else
				{
					// Match.
					return node;
				}
			}

			// Not found.
			return null;
		}

		/// <summary>
		/// Find smallest item in a subtree.
		/// </summary>
		/// <param name="node">The node that roots the tree.</param>
		/// <returns>Node containing the smallest item.</returns>
		private Node<T> FindMin(Node<T> node)
		{
			if (node != null)
			{
				while (node.left != null)
				{
					node = node.left;
				}
			}

			return node;
		}
		
		/// <summary>
		/// Find biggest item in a subtree.
		/// </summary>
		/// <param name="node">The node that roots the tree.</param>
		/// <returns>Node containing the biggest item.</returns>
		private Node<T> FindMax(Node<T> node)
		{
			if (node != null)
			{
				while (node.right != null)
				{
					node = node.right;
				}
			}

			return node;
		}

		/// <summary>
		/// Inserts into a subtree.
		/// </summary>
		/// <param name="value">The item to insert.</param>
		/// <param name="insertIn">The node that roots the tree.</param>
		/// <returns>The new root.</returns>
		/// <exception cref="ArgumentException">If value is already present.</exception>
		private Node<T> Insert(T value, Node<T> insertIn)
		{
			if (insertIn == null)
			{
				insertIn = new Node<T>(value);
			}
			else if (value.CompareTo(insertIn.element) < 0)
			{
				insertIn.left = Insert(value, insertIn.left);
			}
			else if (value.CompareTo(insertIn.element) > 0)
			{
				insertIn.right = Insert(value, insertIn.right);
			}
			else
			{
				throw new ArgumentException($"{value} is already present in the current subtree.");
			}

			return insertIn;
		}

		/// <summary>
		/// Remove minimum item from a subtree.
		/// </summary>
		/// <param name="node">The node that roots the tree.</param>
		/// <returns>The new root.</returns>
		/// <exception cref="NullReferenceException">If the node is empty.</exception>
		private Node<T> RemoveMin(Node<T> node)
		{
			if (node == null)
			{
				throw new NullReferenceException("Node is null.");
			}
			
			if (node.left != null)
			{
				node.left = RemoveMin(node.left);
				return node;
			}
			
			return node.right;
		}

		private Node<T> Remove(T value, Node<T> node)
		{
			if (node == null)
			{
				throw new NullReferenceException($"{value} could not be found.");
			}

			if (value.CompareTo(node.element) < 0)
			{
				node.left = Remove(value, node.left);
			}
			else if (value.CompareTo(node.element) > 0)
			{
				node.right = Remove(value, node);
			}
			// Two children.
			else if (node.left != null && node.right != null)
			{
				node.element = FindMin(node.right).element;
				node.right = RemoveMin(node.right);
			}
			else
			{
				node = node.left ?? node.right;
			}

			return node;
		}
	}
}