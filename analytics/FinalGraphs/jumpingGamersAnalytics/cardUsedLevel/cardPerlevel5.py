import matplotlib.pyplot as plt
import pandas as pd

# Card used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['CARDNAME','SCENENAME'])
df['CARDNAME'] = df['CARDNAME'].fillna("NA")
df['SCENENAME'] = df['SCENENAME'].fillna("NA")

result = {}
total_attempts = 0
for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['CARDNAME'][ind] == "NA" :
        continue
    if 'Level 5' in df['SCENENAME'][ind]:
        total_attempts +=1
    else:
        continue
print(total_attempts)


for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['CARDNAME'][ind] == "NA" :
        continue
    lvl = ""
    if 'Level 5' in df['SCENENAME'][ind]:
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

mylabels = result.keys()
print(mylabels)
plt.pie(y, labels = mylabels)
plt.title('Card Used at level 5', fontsize=14)
plt.show()
