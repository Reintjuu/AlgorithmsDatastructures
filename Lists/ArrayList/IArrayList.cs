namespace ADCode.Lists.ArrayList
{
    interface IArrayList<T>
    {
        // Toevoegen aan het einde van de lijst, mits de lijst niet vol 
        void Add(T item); 

        // Haal de waarde op van een bepaalde 
        T Get(int index); 

        // Wijzig een item op een bepaalde index
        void Set(int index, T item); 

        // Print de inhoud van de list
        void Print(); 

        // Maak de list leeg
        void Clear(); 

        // Tel hoe vaak het gegeven item voorkomt
        int CountOccurences(T item);
    }
}
