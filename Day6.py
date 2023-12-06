from InputHelper import readInput

pinput = []
readInput("Day6.txt", pinput)

time, distance = [], []
time = pinput[0].split(" ")[1:]
distance = pinput[1].split(" ")[1:]
while "" in time: time.remove("")
while "" in distance: distance.remove("")
racelist = []
total = 1
# Formula: Distance travelled = (Time Limit - Time Charging)*(Time Charging)
# Part 1 and Part 2 use the same code, a little bit of bruteforcing :)
# i just concatenated the input

for race, time in enumerate(time):
    valid = []
    for i in range(int(time)):
        if (int(time) - i)*i > int(distance[race]):
            valid.append(i)
    racelist.append(valid)

for i in racelist:
    total *= len(i)

print(total)