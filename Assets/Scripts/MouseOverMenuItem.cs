using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOverMenuItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField]
    Color DefaultColor;
    [SerializeField]
    Color MouseOverColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
            GetComponentInChildren<Text>().color = MouseOverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (GetComponent<Button>().interactable)
            GetComponentInChildren<Text>().color = DefaultColor;
    }
}
