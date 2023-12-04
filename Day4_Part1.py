from InputHelper import readInput

pinput = []
readInput("Day4.txt", pinput)
left = []
right = []
p1total = 0

for line in pinput:
    left.append((line.split(" |")[0]).split(": ")[1])
    right.append(line.split("| ")[1])

for i in range(len(left)):
    left[i] = left[i].split(" ")
    for index, number in enumerate(left[i]):
        if number == "":
            del left[i][index]

for i in range(len(right)):
    right[i] = right[i].split(" ")
    for index, number in enumerate(right[i]):
        if number == "":
            del right[i][index]

for i in range(len(right)):
    winnings = 0
    for number in right[i]:
        if number in left[i]:
            if winnings == 0:
                winnings = 1
            else:
                winnings *= 2
    p1total += winnings

print(p1total)
