using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] TMP_FontAsset HoverFont; 
    [SerializeField] TMP_FontAsset OriginalFont; 
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private GameObject pointer = null;
    void Start()
    {
        // textMeshProUGUI = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        if (gameObject.transform.Find("Pointer") != null) {
            pointer = gameObject.transform.Find("Pointer").gameObject;
        }

    }

    public void OnPointerEnter(PointerEventData eventData) {
        textMeshProUGUI.font =  HoverFont;
        // Debug.Log("Mouse is over GameObject.");

        if (pointer) pointer.SetActive(true);
        
    }

    public void OnPointerExit(PointerEventData eventData) {
        textMeshProUGUI.font =  OriginalFont;
        if (pointer) pointer.SetActive(false);
        // Debug.Log("Mouse is exit GameObject.");
    }

}
