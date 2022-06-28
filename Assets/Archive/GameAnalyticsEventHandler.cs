using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameAnalyticsEventHandler : MonoBehaviour
{
    public static GameAnalyticsEventHandler instance;

    
    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one inventory;");
            return;
        }

        instance = this;
    }

    public void RecordPlayerDied(Vector3 position) {
        Debug.Log("record player died");
        string sceneName = SceneManager.GetActiveScene().name;
        Dictionary<string, object> parameters = new Dictionary<string, object>
        {
            
            { "sceneName", sceneName},
            { "playerXPosition", position.x},
            { "playerYPosition", position.y},
        };

        GameAnalytics.NewDesignEvent("playerDied", parameters);
    }
}
