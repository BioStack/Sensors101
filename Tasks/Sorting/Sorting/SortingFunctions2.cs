using System;

public class SortingFunctions2
{

    public static void Main(string[] args)
    {
        int[] myData = { 4, 33, 29, 44, 2, 1, -2 };

        BubbleSort(myData);

        for (int counter3 = 0; counter3 < myData.Length; counter3++)
        {
            Console.WriteLine(myData[counter3]);
        }
        Console.ReadKey();

    }

    public static void BubbleSort(int[] array)
    {
        for (int counter1 = 0; counter1 < array.Length; counter1++)
        {
            for (int counter2 = counter1; counter2 < array.Length; counter2++)
            {
                if (array[counter1] > array[counter2])
                {
                    Swap(array, counter1, counter2);
                }
            }
        }
    }

    public static void Swap(int[] yourData, int counter1, int counter2)
    {
        int temp = yourData[counter2];
        yourData[counter1] = yourData[counter2];
        yourData[counter1] = temp;
    }



}
