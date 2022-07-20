import matplotlib.pyplot as plt
import pandas as pd

# Card used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['CARDNAME'])

nan_value = float("NaN")
df.replace("", nan_value, inplace=True)
df.dropna(subset = ["CARDNAME"], inplace=True)

result = {}

for ind in df.index:
    crd = df['CARDNAME'][ind]
    if crd in result:
        result[crd] +=1
    else:
        result[crd] = 1

y = result.values()
mylabels = result.keys()
print(mylabels)
plt.pie(y, labels = mylabels)
plt.title('Card Used', fontsize=14)
plt.show()
