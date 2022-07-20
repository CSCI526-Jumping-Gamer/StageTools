import matplotlib.pyplot as plt
import pandas as pd
import re

# tool used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['CARDNAME', 'SCENENAME'])
df['SCENENAME'] = df['SCENENAME'].fillna("NA")
df['CARDNAME'] = df['CARDNAME'].fillna("NA")

card = ['Zero Gravity', 'Slingshot Helper', 'LunarGravity (Gravity -50%)', 'Running Speed + 40%', 'Three-Times Shield', 'Double Jump', 'Triple Jump', 'Jumping Height + 40%', 'RopeClimber (Climbing Speed + 100%)', 'Invincible', 'Single Use Shield', 'LightWeight (Gravity -25%)', 'Flash (Running Speed + 100%)']
card.sort()

result = {}

result["Level 1"] = {}
result["Level 2"] = {}
result["Level 3"] = {}
result["Level 4"] = {}
result["Level 5"] = {}
result["Level 6"] = {}
result["Level 7"] = {}

for key, val in result.items():
    for v in card:
        result[key][v] = 0

print(result)


for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['CARDNAME'][ind] == "NA":
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

    crd = df['CARDNAME'][ind]
    if crd not in card:
        print(crd)
    result[lvl][crd] += 1

print (result)

New_Colors = ['green', 'blue', 'purple', 'brown', 'teal', 'red','yellow', 'black', 'pink', 'brown', 'orange', 'gray', 'aqua']

y = result['Level 1'].values()
mylabels = result['Level 1']
print(mylabels)
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
plt.legend(labels=card, loc='upper center',
           bbox_to_anchor=(0.5, -0.04), ncol=2)

plt.suptitle("Card used at each level", fontsize=14)
plt.show()