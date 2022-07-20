import matplotlib.pyplot as plt
import pandas as pd
import numpy as np

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['PLAYERXPOSITION','PLAYERYPOSITION', 'SCENENAME'])
df['PLAYERXPOSITION'] = df['PLAYERXPOSITION'].fillna(0)
df['SCENENAME'] = df['SCENENAME'].fillna("NA")
df['PLAYERYPOSITION'] = df['PLAYERYPOSITION'].fillna(0)

result = {}
result["Level 6"] = {}
result["Level 6"]["PLAYERXPOSITION"] = []
result["Level 6"]["PLAYERYPOSITION"] = []
print(result)
for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['PLAYERXPOSITION'][ind] == 0 or df['PLAYERYPOSITION'][ind] == 0:
        continue
    lvl = ""
    if 'Level 1' in df['SCENENAME'][ind]:
        continue
    elif 'Level 2' in df['SCENENAME'][ind]:
        continue
    elif 'Level 3' in df['SCENENAME'][ind]:
        continue
    elif 'Level 4' in df['SCENENAME'][ind]:
        continue
    if 'Level 5' in df['SCENENAME'][ind]:
        continue
    elif 'Level 6' in df['SCENENAME'][ind]:
        lvl = "Level 6"
    elif 'Level 7' in df['SCENENAME'][ind]:
        continue
    print(lvl)

    x = df['PLAYERXPOSITION'][ind]
    y = df['PLAYERYPOSITION'][ind]
    # toolUsed = re.sub('[^a-zA-Z]+', '', crd)
    # trapId = str(int(df['TRAPID'][ind]))
    # if crd in result[lvl]:
    #     result[lvl][crd] +=1
    # else:
    #     result[lvl][crd] = 1
    result["Level 6"]["PLAYERXPOSITION"].append(x)
    result["Level 6"]["PLAYERYPOSITION"].append(y)
    # if toolUsed in result[lvl]:
    #     if trapId in result[lvl][toolUsed]:
    #         result[lvl][toolUsed][trapId] +=1
    #     else:
    #         result[lvl][toolUsed][trapId] = 1
    # else:
    #     result[lvl][toolUsed] ={}
    #     result[lvl][toolUsed][trapId] =1

xpoints = result["Level 6"]["PLAYERXPOSITION"]
ypoints = result["Level 6"]["PLAYERYPOSITION"]

plt.plot(xpoints, ypoints, 'o')
plt.axis('square')
plt.grid(True)
plt.title('Death Position at level 6', fontsize=14)
plt.show()