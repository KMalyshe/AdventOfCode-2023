from InputHelper import readInput

parsedInput = []
totalsum = 0
readInput("Day1.txt", parsedInput)


for i in parsedInput:
    #    PART ONE -----------------------
    #    temp = []
    #    for element in i:
    #        if (element.isnumeric()):
    #            temp.append(int(element))
    #    totalsum +=  int(str(temp[0]) + str(temp[-1]))
    #    PART ONE ------------------------

    temp = []
    counter = 0
    while counter < len(i):
        element = i[counter]
        if element.isnumeric():
            temp.append(int(element))
            counter += 1
            continue
        match element:
            case "o":
                if i[counter:counter+3] == "one":
                    temp.append(1)
            case "t":
                if i[counter:counter+3] == "two":
                    temp.append(2)
                elif i[counter:counter+5] == "three":
                    temp.append(3)
            case "f":
                if i[counter:counter+4] == "four":
                    temp.append(4)
                elif i[counter:counter+4] == "five":
                    temp.append(5)
            case "s":
                if i[counter:counter+3] == "six":
                    temp.append(6)
                elif i[counter:counter+5] == "seven":
                    temp.append(7)
            case "e":
                if i[counter:counter+5] == "eight":
                    temp.append(8)
            case "n":
                if i[counter:counter+4] == "nine":
                    temp.append(9)
            case _:
                counter += 1
                continue
        counter += 1
        continue
    totalsum += int(str(temp[0]) + str(temp[-1]))








print(totalsum)



