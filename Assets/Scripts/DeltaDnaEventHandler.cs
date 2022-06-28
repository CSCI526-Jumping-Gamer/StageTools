using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeltaDNA;
using UnityEngine.SceneManagement;

public class DeltaDnaEventHandler : MonoBehaviour
{
    // Start is called before the first frame update

    void Start () {
        // Configure the SDK
        DDNA.Instance.SetLoggingLevel(DeltaDNA.Logger.Level.DEBUG);

        DDNA.Instance.Settings.DefaultImageMessageHandler =
            new ImageMessageHandler(DDNA.Instance, imageMessage =>{
                // the image message is already prepared so it will show instantly
                imageMessage.Show();
            });
        DDNA.Instance.Settings.DefaultGameParameterHandler = new GameParametersHandler(gameParameters =>{
            // do something with the game parameters
            Debug.Log("Received game parameters from event trigger: " + gameParameters);
        });
        
        DDNA.Instance.IsPiplConsentRequired(delegate(bool isRequired)
        {
            if (isRequired)
            {
                // Get user consent and update the booleans below to match
                DDNA.Instance.SetPiplConsent(true, true);
            }
            // To use your own configuration, fill in the DDNA config UI in the Unity editor 
            // and use DDNA.Instance.StartSDK() below.
            // DDNA.Instance.StartSDK(new Configuration()
            // {
            //     environmentKeyDev = "48380028118965502444250662515743",
            //     environmentKey = 0,
            //     collectUrl = "https://collect16056nwdmf.deltadna.net/collect/api",
            //     engageUrl = "https://engage16056nwdmf.deltadna.net",
            //     useApplicationVersion = true
            // });
            DDNA.Instance.StartSDK();
        });
        
        // Debug.LogWarning("DeltaDNA has started with a default configuration. To use your own config, edit the BasicExample script.");
    }

    public void RecordPlayerDied(Vector3 position) {
        Debug.Log("player died");
        string sceneName = SceneManager.GetActiveScene().name;
        GameEvent gameEvent = new GameEvent("playerDied")
            .AddParam("sceneName", sceneName)
            .AddParam("playerXPosition", position.x)
            .AddParam("playerYPosition", position.y);

        DDNA.Instance.RecordEvent(gameEvent);
        DDNA.Instance.Upload();
    }

    public void RecordCardChose(Card card) {
        Debug.Log("player chose card");

        GameEvent gameEvent = new GameEvent("cardChose")
            .AddParam("cardName", card.cardName);


        DDNA.Instance.RecordEvent(gameEvent);
        DDNA.Instance.Upload();
    }
}
