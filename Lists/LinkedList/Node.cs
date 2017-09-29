namespace ADCode.Lists.LinkedList
{
    public class Node<T>
    {
        public T Data;
        public Node<T> next;
        
        public Node(T data)
        {
            Data = data;
        }

        public Node() { }
    }
}