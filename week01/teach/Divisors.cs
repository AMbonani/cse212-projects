private static List<int> FindDivisors(int number) {
    List<int> results = new();
    
    for (int i = 1; i < number; i++) {
        if (number % i == 0) {
            results.Add(i);
        }
    }

    return results;
}
