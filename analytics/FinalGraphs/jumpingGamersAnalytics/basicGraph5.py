import matplotlib.pyplot as plt
import pandas as pd

# Passed Percentage level

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['SCENENAME', 'EVENTNAME'])
df['SCENENAME'] = df['SCENENAME'].fillna("NA")

result = {}

for ind in df.index:
    if df['EVENTNAME'][ind] == "playerDied":
        print(df['SCENENAME'][ind])
    lvl = ""
    if df['SCENENAME'][ind] == "NA" or df['EVENTNAME'][ind] not in ['playerDied', 'levelCompleted']:
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
        if df['EVENTNAME'][ind] == "levelCompleted":
            result[lvl][0] +=1
        elif df['EVENTNAME'][ind] == "playerDied":
            result[lvl][1] += 1
    else:
        result[lvl] = [0,0]
        if df['EVENTNAME'][ind] == "levelCompleted":
            result[lvl][0] +=1
        elif df['EVENTNAME'][ind] == "playerDied":
            result[lvl][1] += 1

print(result)

result = dict(sorted(result.items(), key=lambda x: x[0]))

print(result)


x = ['Level 1', 'Level 2', 'Level 3', 'Level 5', 'Level 6', 'Level 7']
y1 = []
y2 = []
for val in result.values():
    if val[1] != 0:
        y1.append(int(val[0]/(val[1]) * 100))
    # else:
    #     y1.append(0)

for val in result.values():
    y2.append(val[1])
print(y1)
# plot bars in stack manner
plt.bar(x, y1, color='g')
# plt.bar(x, y2, bottom=y1, color='r')

for i in range(len(x)):
        s = str(y1[i]) + "%"
        plt.text(i,y1[i],s, ha = 'center')

for index, value in enumerate(y1):
    plt.text(value, index,
             str(value))
plt.xlabel("Levels")
plt.ylabel("Passed Percentage")
# plt.legend(["Level Passed", "Player Died"])
plt.title("Success rate of each level")

plt.show()



