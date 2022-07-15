using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    [SerializeField] RectTransform button;
    void Start()
    {
        // button.GetComponent<Animator>().Play("Hover Off");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {  
        button.GetComponent<Animator>().Play("Hover On");
    }

    public void OnPointerExit(PointerEventData eventData)
    {  
        button.GetComponent<Animator>().Play("Hover Off");

    }
}
