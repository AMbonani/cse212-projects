private static int[] ListSelector(int[] list1, int[] list2, int[] select)
{
    int[] result = new int[select.Length];
    int i1 = 0; 
    int i2 = 0; 

    for (int i = 0; i < select.Length; i++)
    {
        if (select[i] == 1)
        {
            result[i] = list1[i1];
            i1++;
        }
        else if (select[i] == 2)
        {
            result[i] = list2[i2];
            i2++;
        }
        else
        {
            
            throw new ArgumentException("Selector array must contain only 1 or 2.");
        }
    }

    return result;
}
