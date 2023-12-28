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
        if (((matrix[Sy-1][Sx] == '|') || (matrix[Sy-1][Sx] == '7') || (matrix[Sy-1][Sx] == 'F')) && (Sy != 0)) // Check top
        {
            curr[0] = Sy-1;
            curr[1] = Sx;
            curr[2] = 1;
        }
        else if (((matrix[Sy+1][Sx] == '|') || (matrix[Sy+1][Sx] == 'L') || (matrix[Sy+1][Sx] == 'J')) && (Sy != matrix.Count-1)) // Check below
        {
            curr[0] = Sy+1;
            curr[1] = Sx;
            curr[2] = 2;
        }
        else if (((matrix[Sy][Sx-1] == '-') || (matrix[Sy][Sx-1] == 'L') || (matrix[Sy][Sx-1] == 'F')) && (Sx != 0)) // Check left
        {
            curr[0] = Sy;
            curr[1] = Sx-1;
            curr[2] = 3;
        }
        else if (((matrix[Sy][Sx+1] == '-') || (matrix[Sy][Sx+1] == 'L') || (matrix[Sy][Sx+1] == 'F')) && (Sx != matrix[Sy].Count-1)) // Check right
        {
            curr[0] = Sy;
            curr[1] = Sx+1;
            curr[2] = 3;
        }
        var stepcounter = 1;
        List<Tuple<int, int>> vertices = new List<Tuple<int, int>>();
        vertices.Add((Sy, Sx).ToTuple());
        while (matrix[curr[0]][curr[1]] != 'S')
        {
            stepcounter++;
            vertices.Add((curr[0], curr[1]).ToTuple());
            var mod1 = curr[0]+getNext(curr,matrix).Item1; var mod2 = curr[1]+getNext(curr,matrix).Item2; var mod3 = getNext(curr,matrix).Item3;
            // Cannot combine into one line, need to assign mod variables otherwise curr gets updated as you go and becomes incorrect.
            curr.SetValue(mod1, 0); curr.SetValue(mod2, 1); curr.SetValue(mod3, 2);
        }
        Console.WriteLine(stepcounter / 2);
        int area = polygonarea(vertices);
        Console.WriteLine(area - (vertices.Count / 2) + 1);
        // Polygon area attempt
        static int polygonarea(List<Tuple<int, int>> vertices) 
        {
            var num = vertices.Count;
            int sum1 = 0;
            int sum2 = 0;

            for (int i = 0; i<num-1; i++)
            {
                sum1 += vertices[i].Item1*vertices[i+1].Item2;
                sum2 += vertices[i].Item2*vertices[i+1].Item1;
            }

            sum1 += vertices[num-1].Item1*vertices[0].Item2;
            sum2 += vertices[0].Item1*vertices[num-1].Item2;

            int area = Math.Abs(sum1-sum2) / 2;
            return area;
        }


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
            else return (0, 1, 4).ToTuple();
        }
        
    }
}