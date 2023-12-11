// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Transactions;
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
var curr = "AAA";
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

