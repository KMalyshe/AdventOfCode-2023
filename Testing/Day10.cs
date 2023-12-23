using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

class Day10 {
    public static void solve10() {
        var pinput = File.ReadAllLines(@"C:\AoCFiles\Day10.txt");
        var input = new List<String>(pinput);
        List<List<char>> matrix = new List<List<char>>();
        int Sx = 0, Sy = 0;

        for (int i = 0; i<input.Count; i++) // Turn input into matrix cells (matrix[Y-coord][X-Coord]) and save S position
        {
            matrix.Add(new List<char>());
            for (int j = 0; j<input[i].Length; j++) 
            {
                matrix.Last().Add(input[i][j]);
                if (input[i][j] == 'S') 
                {
                    Sy = i;
                    Sx = j;
                }
            }
        }
        int[] curr = new int[3];
        // Cursed solution, please help; Check where to start
        if ((matrix[Sy-1][Sx] == '|') || (matrix[Sy-1][Sx] == '7') || (matrix[Sy-1][Sx] == 'F')) // Check top
        {
            curr[0] = Sy-1;
            curr[1] = Sx;
            curr[2] = 1;
        }
        else if ((matrix[Sy+1][Sx] == '|') || (matrix[Sy+1][Sx] == 'L') || (matrix[Sy+1][Sx] == 'J')) // Check below
        {
            curr[0] = Sy+1;
            curr[1] = Sx;
            curr[2] = 2;
        }
        else if ((matrix[Sy][Sx-1] == '-') || (matrix[Sy][Sx-1] == 'L') || (matrix[Sy][Sx-1] == 'F')) // Check left
        {
            curr[0] = Sy;
            curr[1] = Sx-1;
            curr[2] = 3;
        }
        var stepcounter = 1;
        while (matrix[curr[0]][curr[1]] != 'S')
        {
            stepcounter++;
            var mod1 = curr[0]+getNext(curr,matrix).Item1; var mod2 = curr[1]+getNext(curr,matrix).Item2; var mod3 = getNext(curr,matrix).Item3;
            curr.SetValue(mod1, 0); curr.SetValue(mod2, 1); curr.SetValue(mod3, 2);
        }
        Console.WriteLine(stepcounter / 2);


        static Tuple<int, int, int> getNext(int[] curr, List<List<char>> matrix)
        {
            int[] tmp = new int[3];
            var x = matrix[curr[0]][curr[1]];
            if (((x == '|') && (curr[2] == 1)) || ((x == 'L') && (curr[2] != 2)) || ((x == 'J') && (curr[2] != 2))) 
            {
                return (-1, 0, 1).ToTuple();
            }
            else if (((x == '|') && (curr[2] != 1)) || ((x == '7') && (curr[2] != 1)) || ((x == 'F') && (curr[2] != 1)))
            {
                return (1, 0, 2).ToTuple();
            }
            else if (((x == '-') && (curr[2] == 3)) || ((x == 'J') && (curr[2] == 2)) || ((x == '7') && (curr[2] == 1)))
            {
                return (0, -1, 3).ToTuple();
            }
            return (0, 1, 4).ToTuple();
        }
        
    }
}