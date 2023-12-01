from InputHelper import readInput

parsedInput = []
totalsum = 0
readInput("Day1.txt", parsedInput)

# PART ONE
#for i in parsedInput:
#    temp = []
#    for element in i:
#        if (element.isnumeric()):
#            temp.append(int(element))
#    totalsum +=  int(str(temp[0]) + str(temp[-1]))

print(totalsum)



