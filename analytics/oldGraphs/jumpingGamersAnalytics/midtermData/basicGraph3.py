import matplotlib.pyplot as plt
import pandas as pd
import re

# tool used graph

df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/data.csv", usecols = ['TOOLKEY'])

nan_value = float("NaN")
df.replace("", nan_value, inplace=True)
df.dropna(subset = ["TOOLKEY"], inplace=True)

result = {}

for ind in df.index:
    tool = df['TOOLKEY'][ind]
    toolUsed = re.sub('[^a-zA-Z]+', '', tool)
    # for val in tool:
    #     if val.isalpha or val == " ":
    #         toolUsed += val
    #     else:
    #         break
    if toolUsed in result:
        result[toolUsed] +=1
    else:
        result[toolUsed] = 1

print(result)

y = result.values()
mylabels = result.keys()
plt.title('Tools Used', fontsize=14)
plt.pie(y, labels = mylabels)
plt.show()