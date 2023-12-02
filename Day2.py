from InputHelper import readInput

parsedInput = []
readInput("Day2.txt", parsedInput)
total = 0

for index, game in enumerate(parsedInput, 1):
    game = game.replace("Game " + str(index) + ": ", "")
    # PART ONE----------------------------------
    # conc = ""
    # valid = True
    # for element in range(len(game)):
    #    if game[element].isnumeric():
    #        conc += str(game[element])
    #        if (int(conc) > 12) and (game[element+2] == "r"):
    #            valid = False
    #        if (int(conc) > 13) and (game[element+2] == "g"):
    #            valid = False
    #        if (int(conc) > 14) and (game[element+2] == "b"):
    #            valid = False
    #    else:
    #        conc = ""
    # if valid:
    #    total += index
    # -------------------------------------------
    conc = ""
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


