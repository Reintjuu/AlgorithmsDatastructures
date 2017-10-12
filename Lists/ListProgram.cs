using System;
using ADCode.Lists.ArrayList;
using ADCode.Lists.LinkedList;
using ADCode.Lists.Queue;
using ADCode.Lists.Stack;

namespace ADCode.Lists
{
    internal class ListProgram
    {
        public ListProgram()
        {            
//            MyArrayList<int> arrayList = new MyArrayList<int>(4);
//            arrayList.Add(1);
//            arrayList.Add(2);
//            arrayList.Add(3);
//            arrayList.Add(4);
//            arrayList.Print();
//            arrayList.CountOccurences(5);
//            arrayList.Set(2, 5);
//            arrayList.Print();
//            arrayList.Clear();
//            arrayList.Add(5);
//            arrayList.Print();
//            
//            MyLinkedList<int> linkedList = new MyLinkedList<int>();
//            linkedList.AddFirst(1);
//            linkedList.AddFirst(2);
//            linkedList.AddFirst(3);
//            linkedList.Print();
//            linkedList.Insert(3, 5);
//            linkedList.Print();
//            
//            linkedList.RemoveFirst();
//            linkedList.Print();
//            linkedList.RemoveFirst();
//            linkedList.Print();
//            linkedList.RemoveFirst();
//            linkedList.Print();
//            linkedList.RemoveFirst();
//            linkedList.Print();
//
//            Console.WriteLine(CheckBrackets("((()))"));
//            Console.WriteLine(CheckBrackets("(()"));
//            Console.WriteLine(CheckBrackets2("([][])()"));
//            Console.WriteLine(CheckBrackets2("[()"));
            
            MyQueue<int> myQueue = new MyQueue<int>();
            myQueue.Enqueue(4);
            myQueue.Enqueue(3);
            myQueue.Enqueue(2);
            myQueue.Enqueue(1);
            Console.WriteLine(myQueue);
            myQueue.Dequeue();
            Console.WriteLine(myQueue);
            myQueue.Enqueue(6);
            Console.WriteLine(myQueue);
            Console.WriteLine(myQueue.Size());
            myQueue.Enqueue(7);
            myQueue.Enqueue(8);
            myQueue.Enqueue(8);
            myQueue.Enqueue(8);
            Console.WriteLine(myQueue);
            Console.WriteLine(myQueue.Size());
        }
        
        private static bool CheckBrackets(string s)
        {
			MyStack<char> stack = new MyStack<char>();
            bool balanced = true;

            for (int i = 0; i < s.Length && balanced; i++)
            {
                char c = s[i];

                if (c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (NullReferenceException)
                    {
                        balanced = false;
                    }
                }
            }

            try
            {
                stack.Top();
            }
            catch (NullReferenceException)
            {
                return balanced;
            }
            
            return false;
        }

        private static bool CheckBrackets2(string s)
        {
            MyStack<char> stack = new MyStack<char>();
            bool balanced = true;

            for (int i = 0; i < s.Length && balanced; i++)
            {
                char c = s[i];

                if ("[(".IndexOf(c) != -1)
                {
                    stack.Push(c);
                }
                else
                {
                    try
                    {
                        var top = stack.Pop();
                        balanced = SameBracket(top, c);
                    }
                    catch (NullReferenceException)
                    {
                        balanced = false;
                    }
                }
            }

            try
            {
                stack.Top();
            }
            catch (NullReferenceException)
            {
                return balanced;
            }
            
            return false;
        }
        
        private static bool SameBracket(char first, char end)
        {
            const string firsts = "[(";
            const string ends = "])";

            return firsts.IndexOf(first) == ends.IndexOf(end);
        }
    }
}