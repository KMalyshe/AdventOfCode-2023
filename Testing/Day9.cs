using System.Xml.Schema;

class Day9 {

    public static void solve9()
    {
        var pinput = File.ReadAllLines(@"C:\AoCFiles\Day9.txt");
        var input = new List<String>(pinput);
        List<String[]> maps = new();
        for (int i = 0; i<input.Count; i++)  // Parsing each line into an array of numbers
        {
            maps.Add(input[i].Split(" "));
        }

        var total = 0; // The total that will be printed as a result
        List<List<String>> diffs = new(); // A list of string lists to represent the sequences of differences (CLUMSY SOLUTION; FIX TO INTEGER LIST LATER)

        for (int i = 0; i<maps.Count; i++) // For each element in maps, i.e. for each line of the input
        {
            diffs.Add(maps[i].ToList()); // Add the original line first for the calculation in the nested loop
            diffs.Add(getdifferences(maps[i]));
            while (!diffs.Last().All(x => Int32.Parse(x) == 0)) // While the last difference sequence does not contain all zeros
            {
                diffs.Add(getdifferences(diffs.Last().ToArray())); // Do another iteration of differences and add to list
            }
            var tmp = 0;
            for (int j = diffs.Count-1; j > 0; j--) // For each difference sequence, work backwards excluding final element
            {  
                /*  Part One:
                tmp += Int32.Parse(diffs[j-1].Last());
                */
                tmp = Int32.Parse(diffs[j-1].First()) - tmp;
            }
            diffs.Clear();
            total += tmp;
        }

        Console.WriteLine(total);
    }

    static List<String> getdifferences(string[] arr) // Return a list of the differences of numbers in the array
    {
        List<String> tempdiffs = new();
        for (int j = 1; j<arr.Length; j++) // For each number in the line, starting at the 2nd due to subtraction of the former element
            {
                tempdiffs.Add((Int32.Parse(arr[j]) - Int32.Parse(arr[j-1])).ToString());
                // Add each individual difference to tempdiffs

            }
        return tempdiffs;
    }
}