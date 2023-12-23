using System.Security.Cryptography.X509Certificates;

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
            Console.WriteLine("Currently at: " + curr[1] + ", " + curr[0]);
            curr = getNext(curr, matrix);
        }
        Console.WriteLine(stepcounter);
        // Only checking three directions as one of them must necessarily match
        // curr[2]: 1=coming from below, 2=coming from top, 3=coming from right, 4=coming from left


        static int[] getNext(int[] curr, List<List<char>> matrix) // Disgusting method but I can't return an array directly in C# 11 :) (allegedly)
        {
            int[] tmp = new int[3];
            switch(matrix[curr[0]][curr[1]])
            {
                case '|':
                    if (curr[2] == 1) {
                        tmp[0] = curr[0]-1; tmp[1] = curr[1]; tmp[2] = 1;
                        return tmp;
                    }
                    tmp[0] = curr[0]+1; tmp[1] = curr[1]; tmp[2] = 2;
                    return tmp;
                case '-':
                    if (curr[2] == 3) {
                        tmp[0] = curr[0]; tmp[1] = curr[1]-1; tmp[2] = 3;
                        return tmp;
                    }
                    tmp[0] = curr[0]; tmp[1] = curr[1]+1; tmp[2] = 4;
                    return tmp;
                case 'L':
                    if (curr[2] == 2) {
                        tmp[0] = curr[0]; tmp[1] = curr[1]+1; tmp[2] = 4;
                        return tmp;
                    }
                    tmp[0] = curr[0]-1; tmp[1] = curr[1]; tmp[2] = 1;
                    return tmp;
                case 'J':
                    if (curr[2] == 2) {
                        tmp[0] = curr[0]; tmp[1] = curr[1]-1; tmp[2] = 3;
                        return tmp;
                    }
                    tmp[0] = curr[0]-1; tmp[1] = curr[1]; tmp[2] = 1;
                    return tmp;
                case '7':
                    if (curr[2] == 1) {
                        tmp[0] = curr[0]; tmp[1] = curr[1]-1; tmp[2] = 3;
                        return tmp;
                    }
                    tmp[0] = curr[0]+1; tmp[1] = curr[1]; tmp[2] = 2;
                    return tmp;
                case 'F':
                    if (curr[2] == 1) {
                        tmp[0] = curr[0]; tmp[1] = curr[1]+1; tmp[2] = 4;
                        return tmp;
                    }
                    tmp[0] = curr[0]+1; tmp[1] = curr[1]; tmp[2] = 2;
                    return tmp;
            }
            return tmp;
        }
        
    }
}