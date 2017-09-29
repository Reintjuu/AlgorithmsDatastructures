namespace ADCode.Lists.Queue
{
	public interface IQueue<T>
	{
		bool IsEmpty();
		void Enqueue(T item);
		T Dequeue();
		int Size();
	}
}