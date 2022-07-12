import matplotlib.pyplot as plt
import pandas as pd
import re

# tool used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['TOOLKEY', 'SCENENAME'])
df['SCENENAME'] = df['SCENENAME'].fillna("NA")
df['TOOLKEY'] = df['TOOLKEY'].fillna("NA")

result = {}

toolSort = ['Accelerator', 'Magnet', 'Slingshot', 'Railgun', 'Rope', 'RopewithMagnet']
toolSort.sort()


result["Level 1"] = {}
result["Level 2"] = {}
result["Level 3"] = {}
result["Level 4"] = {}
result["Level 5"] = {}
result["Level 6"] = {}
result["Level 7"] = {}

for key, val in result.items():
    for v in toolSort:
        result[key][v] = 0

print (result)


for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['TOOLKEY'][ind] == "NA":
        continue
    lvl = ""
    if 'Level 1' in df['SCENENAME'][ind]:
        lvl = "Level 1"
    elif 'Level 2' in df['SCENENAME'][ind]:
        lvl = "Level 2"
    elif 'Level 3' in df['SCENENAME'][ind]:
        lvl = "Level 3"
    elif 'Level 4' in df['SCENENAME'][ind]:
        lvl = "Level 4"
    elif 'Level 5' in df['SCENENAME'][ind]:
        lvl = "Level 5"
    elif 'Level 6' in df['SCENENAME'][ind]:
        lvl = "Level 6"
    elif 'Level 7' in df['SCENENAME'][ind]:
        lvl = "Level 7"

    tool = df['TOOLKEY'][ind]
    toolUsed = re.sub('[^a-zA-Z]+', '', tool)
    if toolUsed in result[lvl]:
        result[lvl][toolUsed] +=1
    else:
        result[lvl][toolUsed] = 1

print (result)

New_Colors = ['green', 'blue', 'purple', 'brown', 'teal', 'red','yellow']

y = result['Level 1'].values()
mylabels = result['Level 1'].keys()
plt.subplot(2, 4, 1)
plt.title('Level 1', fontsize=10)
plt.pie(y, colors=New_Colors)


y = result['Level 2'].values()
mylabels = result['Level 2'].keys()
plt.subplot(2, 4, 2)
plt.title('Level 2', fontsize=10)
plt.pie(y, colors=New_Colors)


y = result['Level 3'].values()
mylabels = result['Level 3'].keys()
plt.subplot(2, 4, 3)
plt.title('Level 3', fontsize=10)
plt.pie(y, colors=New_Colors)



y = result['Level 4'].values()
mylabels = result['Level 4'].keys()
plt.subplot(2, 4, 4)
plt.title('Level 4', fontsize=10)
plt.pie(y, colors=New_Colors)


y = result['Level 5'].values()
mylabels = result['Level 5'].keys()
plt.subplot(2, 4, 5)
plt.title('Level 5', fontsize=10)
plt.pie(y, colors=New_Colors)


y = result['Level 6'].values()
mylabels = result['Level 6'].keys()
plt.subplot(2, 4, 6)
plt.title('Level 6', fontsize=10)
plt.pie(y, colors=New_Colors)


y = result['Level 7'].values()
mylabels = result['Level 7'].keys()
plt.subplot(2, 4, 7)
plt.title('Level 7', fontsize=10)
plt.pie(y, colors=New_Colors)
plt.legend(labels=toolSort, loc='upper center',
           bbox_to_anchor=(0.5, -0.04), ncol=2)

plt.suptitle("Tools used at each level", fontsize=14)
plt.show()


