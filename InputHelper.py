def readInput(inputName, inputList):
    with open(inputName) as f:
        for line in f:
            inputList.append(line.strip())
