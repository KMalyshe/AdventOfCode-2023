from InputHelper import readInput

parsedInput = []
totalsum = 0
numbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"]
readInput("Day1.txt", parsedInput)

for i in parsedInput:
    temp = []
    #    PART ONE -----------------------
    #    for element in i:
    #        if (element.isnumeric()):
    #            temp.append(int(element))
    #    totalsum +=  int(str(temp[0]) + str(temp[-1]))
    #    PART ONE ------------------------

    for index, number in enumerate(numbers):
        i = i.replace(number, number[0] + str(index + 1) + number[-1])

    for element in i:
        if (element.isnumeric()):
            temp.append(int(element))
    totalsum += int(str(temp[0]) + str(temp[-1]))
    print(i)

print(totalsum)
