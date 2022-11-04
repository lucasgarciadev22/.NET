using System;

namespace CollectionsLINQ
{
    class ArrayOperations
    {
        public void PrintArray(int[] array)
        {

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]+",");

            }
            Console.WriteLine();
        }

        public void BubbleSort(ref int[] array) //passing as ref : array dont create another instance
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++) //compares to the right element 
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1]; //temporary assumes the value of the right element
                        array[j + 1] = array[j]; //exchanges next array to current array position
                        array[j] = temp;//current array assumes the temporary value, updating it's position
                    }
                }
            }

        }

        public void GenericSort(ref int[] array)
        {
            Array.Sort(array);
      
        }

        public int GetValue(int[] array, int value)
        {
            return Array.Find(array, element => element == value);
        }

        public string[] ConvertArrayToString(int[] array)
        {
            return Array.ConvertAll(array, element => element.ToString());
        }
  
    }
}
