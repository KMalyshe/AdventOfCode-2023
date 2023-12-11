// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Transactions;
using System.Xml.Schema;
var pinput = File.ReadAllLines(@"C:\AoCFiles\Day8.txt");
var maps = new List<string>(pinput);
List<string> left = new List<string>();
List<string> right = new List<string>();

var seq = maps[0];
// Removing the sequence and the empty line for cleaner parsing
maps.RemoveAt(0);
maps.RemoveAt(0);
// Creating a left and right side list to turn into a dictionary
foreach (string line in maps) {
    left.Add(line.Split(" = ")[0]);
    try {
        right.Add(line.Split(" = ")[1]);
    }
    catch { continue; }
}
// Creating the dictionary
Dictionary<string, string> map = new Dictionary<string, string>();
var counter = 0;
foreach (var source in left) {
    map.Add(source, right[counter]);
    counter++;
}   
/* var curr = "AAA";
counter = 0;
while (curr != "ZZZ") {
    foreach (char c in seq) {
        if (c == 'L') {
            curr = map[curr].Split(", ")[0].Substring(1);
            counter++;
        }
        else if (c == 'R') {
            curr = map[curr].Split(", ")[1].Substring(0, 3);
            counter++;
        }
        if (curr == "ZZZ") {
            Console.WriteLine(counter);
            break;
        }
    }
}
*/
// Part 1 concludes here, Part 2 begins
List<string> curr = new List<string>();
foreach (var key in map.Keys) {
    if (key.Substring(2, 1) == "A") {
        curr.Add(key);
    }
}
long[] firstocc = new long[curr.Count];
counter = 0;
bool guard = true;
while(guard) {
    foreach (char c in seq) {
        guard = false;
        counter++;
        for (int i = 0; i<curr.Count; i++) {
            if (c == 'L') {
            curr[i] = map[curr[i]].Split(", ")[0].Substring(1);
            }
            else if (c == 'R') {
            curr[i] = map[curr[i]].Split(", ")[1].Substring(0, 3);
            }
        if ((curr[i][2] == 'Z') && (firstocc[i] == 0)) {
            firstocc[i] = counter;
        }
        }
        for (int i = 0; i<firstocc.Length; i++) {
            if (firstocc[i] == 0) guard = true;
        }
        if (!guard) break;
    }
}
foreach (var item in firstocc) {
    Console.WriteLine(item);
}
var biglcm = lcm(firstocc[0], firstocc[1]);
for (int i = 2; i<firstocc.Length; i++) {
    biglcm = lcm(firstocc[i], biglcm);
}
Console.WriteLine(biglcm);
static long lcm(long x, long y) {
    return x * y / gcd(x, y);
}
static long gcd(long x, long y) {
    while (true) {
        if (x == y) return x;
        if (x > y) x = x-y;
        else if (y > x) y = y-x;
    }
}
