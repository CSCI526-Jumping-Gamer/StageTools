import matplotlib.pyplot as plt
import pandas as pd
import re

# Card used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['TRAPNAME'])

nan_value = float("NaN")
df.replace("", nan_value, inplace=True)
df.dropna(subset = ["TRAPNAME"], inplace=True)

result = {}

for ind in df.index:
    crd = df['TRAPNAME'][ind]
    toolUsed = re.sub('[^a-zA-Z]+', '', crd)
    if toolUsed in result:
        result[toolUsed] +=1
    else:
        result[toolUsed] = 1

y = result.values()
mylabels = result.keys()
print(mylabels)
plt.pie(y, labels = mylabels)
plt.title('DeathTrap', fontsize=14)
plt.show()
