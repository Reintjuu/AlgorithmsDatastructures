namespace ADCode.BinarySearchTrees
{
	public class BinarySearchTree : IBinarySearchTree
	{
		private Node root;

		public void Insert(int x)
		{
			Node newNode = new Node(x);

			if (root == null)
			{
				root = newNode;
			}
			else
			{
				Node current = root;

				while (true)
				{
					Node tempParent = current;

					if (newNode.element < current.element)
					{
						current = current.left;

						if (current == null)
						{
							tempParent.left = newNode;
							return;
						}
					}

					else
					{
						current = current.right;
						if (current == null)
						{
							tempParent.right = newNode;
							return;
						}
					}
				}
			}
		}

		public string InOrder()
		{
			return Traverse(root);
		}

		private string Traverse(Node node)
		{
			if (node == null)
			{
				return string.Empty;
			}

			return Traverse(node.left) + " " + node.element + " " + Traverse(node.right);
		}
		
		public void Remove(int x)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveMin()
		{
			throw new System.NotImplementedException();
		}

		public int FindMin()
		{
			throw new System.NotImplementedException();
		}
	}
}