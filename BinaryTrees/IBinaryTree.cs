namespace ADCode.BinaryTrees
{
	public interface IBinaryTree<T>
	{
		BinaryNode<T> GetRoot();
		int Size();
		int Height();

		void PrintPreOrder();
		void PrintInOrder();
		void PrintPostOrder();

		void MakeEmpty();
		bool IsEmpty();
		void Merge(T rootItem, BinaryTree<T> first, BinaryTree<T> second);
	}
}