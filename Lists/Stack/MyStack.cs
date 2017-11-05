using ADCode.Lists.LinkedList;

namespace ADCode.Lists.Stack
{
	// Week 2 - Opdracht 3
	public class MyStack<T> : IStack<T>
	{
		private readonly MyLinkedList<T> linkedList; 
		
		public MyStack()
		{
			linkedList = new MyLinkedList<T>();
		}

		public void Push(T data)
		{
			linkedList.AddFirst(data);
		}

		public T Pop()
		{
			var first = linkedList.GetFirst();
			linkedList.RemoveFirst();
			return first;
		}

		public T Top()
		{
			return linkedList.GetFirst();
		}
	}
}