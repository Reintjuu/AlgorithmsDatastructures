namespace ADCode.BinarySearchTrees
{
	public interface IBinarySearchTree
	{
		void Insert(int x);
		void Remove(int x);
		void RemoveMin();
		int FindMin();
		string InOrder();
		string ToString();
	}
}