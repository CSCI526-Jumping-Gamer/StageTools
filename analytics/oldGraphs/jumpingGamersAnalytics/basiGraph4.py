import matplotlib.pyplot as plt
import pandas as pd


df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['SCENENAME', 'TOTALTIME'])
df['SCENENAME'] = df['SCENENAME'].fillna("NA")
df['TOTALTIME'] = df['TOTALTIME'].fillna(0)

result = {}

for ind in df.index:
    lvl = ""
    if df['SCENENAME'][ind] == "NA" or df['TOTALTIME'][ind] == 0:
        continue
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

    if lvl in result:
        result[lvl].append(df['TOTALTIME'][ind])
    else:
        result[lvl]= [df['TOTALTIME'][ind]]

print(result)

level1 = 0
level2 = 0
level3 = 0
level4 = 0
level5 = 0
level6 = 0
level7 = 0

for key,val in result.items():
    if 'Level 1' in key:
        level1 = sum(val)/ len(val)
    elif 'Level 2' in key:
        level2 = sum(val)/ len(val)
    elif 'Level 3' in key:
        level3 = sum(val)/ len(val)
    elif 'Level 4' in key:
        level4 = sum(val)/ len(val)
    elif 'Level 5' in key:
        level5 = sum(val)/ len(val)
    elif 'Level 6' in key:
        level6 = sum(val)/ len(val)
    elif 'Level 7' in key:
        level7 = sum(val)/ len(val)

print(level7)


Data = {'Level': ['Level 1', 'Level 2', 'Level 3', 'Level 4', 'Level 5', 'Level 6', 'Level 7'],
        'AvgTime': [level1, level2, level3, level4, level5, level6, level7]
        }
df = pd.DataFrame(Data, columns=['Level', 'AvgTime'])

New_Colors = ['green', 'blue', 'purple', 'brown', 'teal', 'red','yellow']
plt.bar(df['Level'], df['AvgTime'], color=New_Colors)
plt.title('Level Vs AvgTime', fontsize=14)
plt.xlabel('Level', fontsize=14)
plt.ylabel('AvgTime', fontsize=14)
plt.show()


