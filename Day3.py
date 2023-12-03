from InputHelper import readInput

grid = []
readInput("Day3.txt", grid)
curr = ""
indexlist = []
checks = []
ok = False
p1total = 0
p2total = 0
stardict = {}

for y, nums in enumerate(grid):
    for x in range(len(nums)):
        if nums[x].isdecimal():
            curr += str(nums[x])
            indexlist.append(int(x))
        # If not decimal and there was a number before / If there is a number but the grid row is ending
        if ((not nums[x].isdecimal()) and (len(curr) != 0)) or ((len(curr) != 0) and (x == len(nums)-1)):
            # Check left element
            if 0 not in indexlist:
                checks.append(grid[y][indexlist[0] - 1])
                if grid[y][indexlist[0]-1] == "*":
                    if ((y, indexlist[0] - 1) in stardict): stardict[(y, indexlist[0] - 1)].append(curr)
                    else:
                        stardict[(y, indexlist[0]-1)] = []
                        stardict[(y, indexlist[0] - 1)].append(curr)

            # Check right element
            if (len(nums)-1) not in indexlist:
                checks.append(grid[y][indexlist[-1] + 1])
                if grid[y][indexlist[-1] + 1] == "*":
                    if ((y, indexlist[-1] + 1) in stardict):
                        stardict[(y, indexlist[-1] + 1)].append(curr)
                    else:
                        stardict[(y, indexlist[-1] + 1)] = []
                        stardict[(y, indexlist[-1] + 1)].append(curr)
            # Check top
            if y != 0:
                # Check top left diagonal
                if 0 not in indexlist:
                    checks.append(grid[y - 1][indexlist[0] - 1])
                    if grid[y-1][indexlist[0] - 1] == "*":
                        if ((y-1, indexlist[0] - 1) in stardict):
                            stardict[(y-1, indexlist[0] - 1)].append(curr)
                        else:
                            stardict[(y-1, indexlist[0] - 1)] = []
                            stardict[(y - 1, indexlist[0] - 1)].append(curr)
                # Check top right diagonal
                if (len(nums)-1) not in indexlist:
                    checks.append(grid[y - 1][indexlist[-1] + 1])
                    if grid[y - 1][indexlist[-1] + 1] == "*":
                        if ((y-1, indexlist[-1] + 1) in stardict):
                            stardict[(y-1, indexlist[-1] + 1)].append(curr)
                        else:
                            stardict[(y-1, indexlist[-1] + 1)] = []
                            stardict[(y - 1, indexlist[-1] + 1)].append(curr)
                # Check elements directly above
                for i in indexlist:
                    checks.append(grid[y - 1][i])
                    if grid[y - 1][i] == "*":
                        if ((y-1, i) in stardict):
                            stardict[(y-1, i)].append(curr)
                        else:
                            stardict[(y-1, i)] = []
                            stardict[(y - 1, i)].append(curr)
            # Check below
            if y != len(grid)-1:
                # Check bottom left diagonal
                if 0 not in indexlist:
                    checks.append(grid[y + 1][indexlist[0] - 1])
                    if grid[y + 1][indexlist[0] - 1] == "*":
                        if ((y+1, indexlist[0] - 1) in stardict):
                            stardict[(y+1, indexlist[0] - 1)].append(curr)
                        else:
                            stardict[(y+1, indexlist[0] - 1)] = []
                            stardict[(y + 1, indexlist[0] - 1)].append(curr)
                # Check bottom right diagonal
                if (len(nums)-1) not in indexlist:
                    checks.append(grid[y + 1][indexlist[-1] + 1])
                    if grid[y + 1][indexlist[-1] + 1] == "*":
                        if ((y+1, indexlist[-1] + 1) in stardict):
                            stardict[(y+1, indexlist[-1] + 1)].append(curr)
                        else:
                            stardict[(y+1, indexlist[-1] + 1)] = []
                            stardict[(y + 1, indexlist[-1] + 1)].append(curr)
                # Check elements directly below
                for i in indexlist:
                    checks.append(grid[y + 1][i])
                    if grid[y + 1][i] == "*":
                        stardict[(y + 1, i)] = []
                        if ((y+1, i) in stardict):
                            stardict[(y+1, i)].append(curr)
                        else:
                            stardict[(y+1, i)] = []
                            stardict[(y + 1, i)].append(curr)
            # Check if adjacent cells contain any symbols
            for i in checks:
                if (not i.isdecimal()) and (i != "."):
                    ok = True
            if ok:
                p1total += int(curr)

            curr = ""
            indexlist = []
            checks = []
            ok = False

print(stardict)
for key in stardict:
    if len(stardict[key]) == 2:
        p2total += int(stardict[key][0])*int(stardict[key][1])



print("Part 1: ", p1total)
print("Part 2: ", p2total)

