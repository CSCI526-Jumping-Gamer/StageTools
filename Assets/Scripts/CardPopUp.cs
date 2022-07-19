using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardPopUp : MonoBehaviour
{
    [SerializeField] GameObject goldPrefab;
    [SerializeField] GameObject silverPrefab;
    [SerializeField] GameObject bronzePrefab;
    [SerializeField] GameObject wrapper;
    [SerializeField] Toggle AllowCardPopUp;
    [SerializeField] public int IntCardPopUp = 1;
    void Start() {
        IntCardPopUp = PlayerPrefs.GetInt("AllowCardPopUp");
        if (IntCardPopUp == 0) {
            AllowCardPopUp.isOn = false;
        } else {
            AllowCardPopUp.isOn = true;
        }
    }
    public void switchPopUp(bool i) {
        if (!AllowCardPopUp.isOn) {
            IntCardPopUp = 0;
        } else {
            IntCardPopUp = 1;
        }
        PlayerPrefs.SetInt("AllowCardPopUp", IntCardPopUp);
        PlayerPrefs.Save();
    }

    public void CloseWrapper() {
        if (AllowCardPopUp.isOn) {
            wrapper.SetActive(false);
            PlayerController.instance.EnablePlayerInput();
            transform.GetChild(0).GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(3).GetChild(0).GetChild(1).gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void CreateCardPopUp(Card card, int i)
    {
        if (AllowCardPopUp.isOn) {
            wrapper.SetActive(true);
            PlayerController.instance.DisablePlayerInput();
            Transform parentTransform = transform.GetChild(0).GetChild(0);
            Debug.Log(parentTransform);
            transform.GetChild(0).GetChild(3).GetChild(0).GetChild(i).gameObject.SetActive(true);
            GameObject cardObject = null;
            if (card.rank == 3) {
                cardObject = Instantiate(goldPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
            } else if (card.rank == 2) {
                cardObject = Instantiate(silverPrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
            } else if (card.rank == 1) {
                cardObject = Instantiate(bronzePrefab, new Vector3(0, 0, 0), Quaternion.identity, parentTransform);
            } 
            // cardObject.name = "Card " + index;
            // Component[] textMeshProUGUI;
            // textMeshProUGUI = cardObject.transform.GetChild(0).GetComponents(typeof(TextMeshProUGUI));
            TextMeshProUGUI timeMeshProUGUI = cardObject.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            // Debug.Log(cardObject);
            TextMeshProUGUI nameMeshProUGUI = cardObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI detailMeshProUGUI = cardObject.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
            nameMeshProUGUI.text = card.cardName;
            timeMeshProUGUI.text = card.time + "s";
            detailMeshProUGUI.text = card.cardDetail;
            string iconImageRoute = card.name;
            Sprite cardImage = Resources.Load<Sprite>(iconImageRoute);
            cardObject.transform.GetChild(0).GetComponent<Image>().sprite = cardImage;
            string signImageRoute = card.cardType;
            Sprite cardSign = Resources.Load<Sprite>("CardType/" + signImageRoute);
            cardObject.transform.GetChild(4).GetChild(1).GetComponent<Image>().sprite = cardSign;
            Time.timeScale = 0f;
        }
    }
}
