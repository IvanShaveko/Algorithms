using System;

namespace HashTable
{
    public static class Printer
    {
        public static void Print(this HashTable hashTable)
        {
            if (hashTable == null)
            {
                throw new ArgumentNullException(nameof(hashTable));
            }

            foreach (var item in hashTable.Table)
            {
                Console.WriteLine(item.Key);
                
                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
        }
    }
}