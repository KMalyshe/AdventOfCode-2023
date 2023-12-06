from InputHelper import readInput

maps = []
readInput("Day5.txt", maps)
for index, line in enumerate(maps):
    if line == "":
        del maps[index]
seeds = maps[0].split(" ")[1:]
seedsoilmap, soilfertmap, fertwatermap, waterlightmap = [], [], [], []
# Could be declared in one line, splitting for appearance
lighttempmap, temphumidmap, humidlocationmap = [], [], []
pindex = 2
locations = []


def makemap(breaker, maplist, previndex) -> int:
    # Make a list of lines in each segment of the "pipeline" i.e. soil->fertilizer
    tmp = 0
    for index, line in enumerate(maps[previndex:]):
        if line == breaker:
            break
        maplist.append(line.split(" "))
        tmp = index
    return tmp + previndex + 2


def getresult(smap, prev) -> int:
    # Get the matching value by finding a matching line and calculating offset
    val = 0
    for i in smap:
        if int(i[1]) <= int(prev) <= (int(i[1]) + int(i[2]) - 1):
            val = int(i[0]) + (int(prev) - int(i[1]))
    if val == 0:
        val = int(prev)
    return val


pindex = makemap("soil-to-fertilizer map:", seedsoilmap, pindex)
pindex = makemap("fertilizer-to-water map:", soilfertmap, pindex)
pindex = makemap("water-to-light map:", fertwatermap, pindex)
pindex = makemap("light-to-temperature map:", waterlightmap, pindex)
pindex = makemap("temperature-to-humidity map:", lighttempmap, pindex)
pindex = makemap("humidity-to-location map:", temphumidmap, pindex)
pindex = makemap("thisisabreaker", humidlocationmap, pindex)

for seed in seeds:
    loc = getresult(humidlocationmap,
                    getresult(temphumidmap,
                              getresult(lighttempmap,
                                        getresult(waterlightmap,
                                                  getresult(fertwatermap,
                                                            getresult(soilfertmap,
                                                                      getresult(seedsoilmap, int(seed))))))))
    locations.append(loc)

tuples = []
skipone = False
for i, seed in enumerate(seeds):
    if skipone:
        skipone = False
        continue
    tuples.append([int(seeds[i]), int(seeds[i]) + int(seeds[i+1]) - 1])
    skipone = True





print(min(locations))

