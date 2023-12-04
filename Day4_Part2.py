from InputHelper import readInput

pinput = []
readInput("Day4.txt", pinput)
left = []
right = []
p1total = 0
p2total = 0
cardsamount = {}
amountwins = 0
for i in range(len(pinput)):
    cardsamount[i] = 1

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

# INPUT PARSING ENDS HERE; CALCULATIONS START

for i in range(len(right)):
    winnings = 0
    tmp = cardsamount[i]
    while tmp >= 1:
        for number in right[i]:
            if number in left[i]:
                amountwins += 1
        for j in range(amountwins):
            if (i+1+j) < len(right):
                cardsamount[i+1+j] += 1
        amountwins = 0
        tmp -= 1


for i in cardsamount:
    p2total += cardsamount[i]


print(p2total)