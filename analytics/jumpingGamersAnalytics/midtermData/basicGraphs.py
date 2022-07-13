import matplotlib.pyplot as plt
import pandas as pd

# Level user Graph

# creating dataFrame for user per level
df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['SCENENAME'])

level1 = 0
level2 = 0
level3 = 0
level4 = 0
level5 = 0
level6 = 0
level7 = 0


data = []


nan_value = float("NaN")
df.replace("", nan_value, inplace=True)
df.dropna(subset = ["SCENENAME"], inplace=True)


for ind in df.index:
        print(df['SCENENAME'][ind])
        if 'Level 1' in df['SCENENAME'][ind]:
                level1 +=1
        elif 'Level 2' in df['SCENENAME'][ind]:
                level2 +=1
        elif 'Level 3' in df['SCENENAME'][ind]:
                level3 +=1
        elif 'Level 4' in df['SCENENAME'][ind]:
                level4 +=1
        elif 'Level 5' in df['SCENENAME'][ind]:
                level5 +=1
        elif 'Level 6' in df['SCENENAME'][ind]:
                level6 +=1
        elif 'Level 7' in df['SCENENAME'][ind]:
                level7 +=1


Data = {'Level': ['Level 1', 'Level 2', 'Level 3', 'Level 4', 'Level 5', 'Level 6', 'Level 7'],
        'User': [level1, level2, level3, level4, level5, level6, level7]
        }
df = pd.DataFrame(Data, columns=['Level', 'User'])

New_Colors = ['green', 'blue', 'purple', 'brown', 'teal', 'red','yellow']
plt.bar(df['Level'], df['User'], color=New_Colors)
plt.title('Level Vs Attempt', fontsize=14)
plt.xlabel('Level', fontsize=14)
plt.ylabel('User', fontsize=14)
plt.show()



# with open("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", 'r') as f:
#         for line in f:
#                 data.append(line)
#
# for ck in data:
#         print(ck)
#         ck_data = json.loads(ck)
#         if ck_data['SCENENAME'] == "Level 1":
#                 level1+=1
#
# print(level1)