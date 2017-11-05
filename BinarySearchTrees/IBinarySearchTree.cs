using System;

namespace ADCode.BinarySearchTrees
{
	public interface IBinarySearchTree<T> where T : IComparable
	{
		void Insert(T value);
		void Remove(T value);
		void RemoveMin();
		T Find(T value);
		T FindMin();
		T FindMax();
		bool IsEmpty();
		void MakeEmpty();
		string InOrder();
		string ToString();
	}
}