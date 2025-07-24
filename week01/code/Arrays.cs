using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// Part 1: Implement the MultiplesOf function.
    /// This function takes a starting number and the number of multiples to generate.
    /// For example, MultiplesOf(3, 5) returns: {3, 6, 9, 12, 15}
    /// </summary>
    public static double[] MultiplesOf(double start, int count)
    {
        // Step 1: Create a new array of size 'count'
        // Step 2: Use a loop from 0 to count - 1
        // Step 3: On each iteration, multiply (index + 1) * start and store in array
        // Step 4: Return the filled array

        double[] result = new double[count]; // Step 1

        for (int i = 0; i < count; i++) // Step 2
        {
            result[i] = start * (i + 1); // Step 3
        }

        return result; // Step 4
    }

    /// <summary>
    /// Part 2: Rotate the 'data' list to the right by the 'amount'.
    /// For example, rotating {1,2,3,4,5,6,7,8,9} by 3 gives {7,8,9,1,2,3,4,5,6}.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Calculate the index where the rotation will start
        int startIndex = data.Count - amount;

        // Step 2: Split the list into two slices
        // - endSlice: from startIndex to end
        // - startSlice: from 0 to startIndex (exclusive)
        List<int> endSlice = data.GetRange(startIndex, amount);
        List<int> startSlice = data.GetRange(0, startIndex);

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the slices back in the correct rotated order
        data.AddRange(endSlice);
        data.AddRange(startSlice);
    }
}


