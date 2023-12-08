from InputHelper import readInput

pinput = []
readInput("Day7.txt", pinput)
hands = []
for i in pinput:
    hands.append(i.split(" "))
oak5, oak4, fhouse, oak3, p2, p1, hc = [], [], [], [], [], [], []


def gettype(hand):
    # Part 1: solved similarly, minus everything relating to excluding J
    cardlist = [hand[0][0], hand[0][1], hand[0][2], hand[0][3], hand[0][4]]
    jcounter = 0
    while "J" in cardlist:
        jcounter += 1
        cardlist.remove("J")
    cardset = set(cardlist)
    checkdict = {}

    if len(cardset) == 0: return 6
    if len(cardset) == 1:
        return 6  # Five of a kind
    if len(cardset) == 2:
        for card in hand[0]:
            if card == "J": continue
            if card in checkdict:
                checkdict[card] += 1
            else:
                checkdict[card] = 1
        if (max(checkdict.values())) + jcounter == 4:
            return 5 # Four of a kind
        return 4 # Full House
        # Part 1:
        # if 3 in checkdict.values():
        #     return 4  # Full House
        # return 5  # Four of a kind
    if len(cardset) == 3:
        for card in hand[0]:
            if card == "J": continue
            if card in checkdict:
                checkdict[card] += 1
            else:
                checkdict[card] = 1

        if (max(checkdict.values())) + jcounter == 3:
            return 3  # Three of a kind
        return 2  # Two Pair
    if len(cardset) == 4:
        return 1  # One Pair
    return 0  # Nothing


for i in hands:
    tmp = gettype(i)
    if tmp == 0: hc.append(i)
    if tmp == 1: p1.append(i)
    if tmp == 2: p2.append(i)
    if tmp == 3: oak3.append(i)
    if tmp == 4: fhouse.append(i)
    if tmp == 5: oak4.append(i)
    if tmp == 6: oak5.append(i)

lists = [hc, p1, p2, oak3, fhouse, oak4, oak5]


def sorthelper(hand):
    handlist = []
    for i in hand[0]:
        if i.isnumeric():
            handlist.append(int(i))
        else:
            if i == "T": handlist.append(10)
            if i == "J": handlist.append(1) # Part 1: 11
            if i == "Q": handlist.append(12)
            if i == "K": handlist.append(13)
            if i == "A": handlist.append(14)
    return handlist[0], handlist[1], handlist[2], handlist[3], handlist[4]


for handtype in lists:
    handtype.sort(key=sorthelper)

winnings = []

for i in lists:
    for j in i:
        winnings.append(int(j[1]))
total = 0

for i, bet in enumerate(winnings, 1):
    total += bet*i

print(total)

