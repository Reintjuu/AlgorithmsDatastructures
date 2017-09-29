namespace ADCode.Lists.LinkedList
{
    interface ILinkedList<T> 
    {
        // Voeg een item toe aan het begin van de lijst
        void AddFirst(T data); 

        void Clear();
        
        void Print(); 
 
        // Voeg een item in op een bepaalde index (niet overschrijven!)    
        void Insert(int index, T data); 
 
        // verwijder het eerste item    
        void RemoveFirst(); 
 
        // geeft het eerste item terug
        T GetFirst();
    } 
}