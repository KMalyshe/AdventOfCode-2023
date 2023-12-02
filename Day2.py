from InputHelper import readInput

parsedInput = []
readInput("Day2.txt", parsedInput)
total = 0

for index, game in enumerate(parsedInput, 1):
    game = game.replace("Game " + str(index) + ": ", "")
    conc = ""
    #valid = True
    #d = {"r": 12, "g": 13, "b": 14}
    #for element in range(len(game)):
    #    if game[element].isnumeric():
    #        conc += str(game[element])
    #        if (int(conc) > 9) and (int(conc) > d.get(game[element+2])): valid = False
    #    else:
    #        conc = ""
    #if valid:
    #    total += index

    d = {"red": 0, "green": 0, "blue": 0}

    for element in range(len(game)):
        if game[element].isnumeric():
            conc += str(game[element])
            color = game[element+2]
            if (color == "r") and (int(conc) > d["red"]): d["red"] = int(conc)
            if (color == "g") and (int(conc) > d["green"]): d["green"] = int(conc)
            if (color == "b") and (int(conc) > d["blue"]): d["blue"] = int(conc)
        else:
            conc = ""

    total += d["red"]*d["blue"]*d["green"]


print(total)


