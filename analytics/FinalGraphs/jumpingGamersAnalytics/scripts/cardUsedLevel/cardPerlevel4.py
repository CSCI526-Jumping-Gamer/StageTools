import matplotlib.pyplot as plt
import pandas as pd

# Card used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['CARDNAME','SCENENAME','EVENTNAME'])
df['CARDNAME'] = df['CARDNAME'].fillna("NA")
df['SCENENAME'] = df['SCENENAME'].fillna("NA")

result = {}
total_attempts = 0
for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['EVENTNAME'][ind] not in ['playerDied', 'levelCompleted'] :
        continue
    if 'Level 4' in df['SCENENAME'][ind] and df['EVENTNAME'][ind] in ['playerDied', 'levelCompleted']:
        total_attempts +=1
    else:
        continue
print(total_attempts)


for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['CARDNAME'][ind] == "NA" :
        continue
    lvl = ""
    if 'Level 4' in df['SCENENAME'][ind]:
        crd = df['CARDNAME'][ind]
        if crd in result:
            result[crd] +=1
        else:
            result[crd] = 1
    else:
        continue

print(result)
# for ind in df.index:
#     crd = df['CARDNAME'][ind]
#     if crd in result:
#         result[crd] +=1
#     else:
#         result[crd] = 1
#

y = list(result.values())
print(y)
total = sum(y)
def absolute_value(val):
    a  = (val/total_attempts) *100
    return a
mylabels = result.keys()
print(mylabels)
plt.pie(y, labels = mylabels, autopct=lambda p: '{:.0f}'.format(p * total / 100),startangle=90)
s = 'Card Used at level 4(total_Attempts = ' + str(total_attempts) + ')'
plt.title(s, fontsize=14)
plt.show()