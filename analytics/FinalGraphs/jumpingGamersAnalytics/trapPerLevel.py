import matplotlib.pyplot as plt
import pandas as pd
import re

# Trap per level
df = pd.read_csv("/Users/utkarshbhardwaj/Documents/Lectures/mobileDevices/analytics/new.csv", usecols = ['SCENENAME','TRAPNAME', 'TRAPID'])

df['SCENENAME'] = df['SCENENAME'].fillna("NA")
df['TRAPNAME'] = df['TRAPNAME'].fillna("NA")
df['TRAPID'] = df['TRAPID'].fillna("NA")

result = {}
trap = ['DeathDetector', 'CircleSaw', 'LaserGun']
trap.sort()


result["Level 5"] = {}
result["Level 7"] = {}



print(result)

for ind in df.index:
    if df['SCENENAME'][ind] == "NA" or df['TRAPNAME'][ind] == "NA" or df['TRAPID'][ind] == "NA":
        continue
    lvl = ""
    if 'Level 1' in df['SCENENAME'][ind]:
        continue
    elif 'Level 2' in df['SCENENAME'][ind]:
        continue
    elif 'Level 3' in df['SCENENAME'][ind]:
        continue
    elif 'Level 4' in df['SCENENAME'][ind]:
        continue
    if 'Level 5' in df['SCENENAME'][ind]:
        lvl = "Level 5"
    elif 'Level 6' in df['SCENENAME'][ind]:
        continue
    elif 'Level 7' in df['SCENENAME'][ind]:
        lvl = "Level 7"
    print(lvl)
    crd = df['TRAPNAME'][ind]
    toolUsed = re.sub('[^a-zA-Z]+', '', crd)
    trapId = str(int(df['TRAPID'][ind]))
    # if crd in result[lvl]:
    #     result[lvl][crd] +=1
    # else:
    #     result[lvl][crd] = 1

    if toolUsed in result[lvl]:
        if trapId in result[lvl][toolUsed]:
            result[lvl][toolUsed][trapId] +=1
        else:
            result[lvl][toolUsed][trapId] = 1
    else:
        result[lvl][toolUsed] ={}
        result[lvl][toolUsed][trapId] =1

print(result)
# print(len(result['Level 5']['CircleSaw']))
# result['Level 4']['DeathDetector'] = 1
# New_Colors = ['green', 'blue', 'red']
#
# # y = result['Level 1'].values()
# # mylabels = result['Level 1'].keys()
# # plt.subplot(2, 4, 1)
# # plt.title('Level 1', fontsize=10)
# # plt.pie(y, colors=New_Colors)
# #
# #
# # y = result['Level 2'].values()
# # mylabels = result['Level 2'].keys()
# # plt.subplot(2, 4, 2)
# # plt.title('Level 2', fontsize=10)
# # plt.pie(y, colors=New_Colors)
#
#
# # y = result['Level 3'].values()
# # mylabels = result['Level 3'].keys()
# # plt.subplot(2, 4, 3)
# # plt.title('Level 3', fontsize=10)
# # plt.pie(y, colors=New_Colors)
#
#
#
# # y = result['Level 4'].values()
# # mylabels = result['Level 4'].keys()
# # plt.subplot(2, 4, 4)
# # plt.title('Level 4', fontsize=10)
# # plt.pie(y, colors=New_Colors)
#
#
# y = result['Level 5'].values()
# mylabels = result['Level 5'].keys()
# plt.subplot(2, 4, 5)
# plt.title('Level 5', fontsize=10)
# plt.pie(y)
#
#
# # y = result['Level 6'].values()
# # mylabels = result['Level 6'].keys()
# # plt.subplot(2, 4, 6)
# # plt.title('Level 6', fontsize=10)
# # plt.pie(y, colors=New_Colors)
#
#
# y = result['Level 7'].values()
# mylabels = result['Level 7'].keys()
# plt.subplot(2, 4, 7)
# plt.title('Level 7', fontsize=10)
# plt.pie(y)
# # plt.legend(labels=trap, loc='upper center',
# #            bbox_to_anchor=(0.5, -0.04), ncol=2)
#
# plt.suptitle("Traps at each level", fontsize=14)
# plt.show()
#


# result = {}
#
# for ind in df.index:
#     crd = df['TRAPNAME'][ind]
#     toolUsed = re.sub('[^a-zA-Z]+', '', crd)
#     if toolUsed in result:
#         result[toolUsed] +=1
#     else:
#         result[toolUsed] = 1
#
# y = result.values()
# mylabels = result.keys()
# print(mylabels)
# plt.pie(y, labels = mylabels)
# plt.title('DeathTrap', fontsize=14)
# plt.show()
