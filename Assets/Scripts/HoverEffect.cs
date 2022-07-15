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
    void Start()
    {
        // textMeshProUGUI = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        textMeshProUGUI.font =  HoverFont;
        // Debug.Log("Mouse is over GameObject.");
    }

    public void OnPointerExit(PointerEventData eventData) {
        textMeshProUGUI.font =  OriginalFont;
        // Debug.Log("Mouse is exit GameObject.");
    }

}
