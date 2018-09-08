using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bin : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public bool redBin;
    public bool yellowBin;
    public bool greenBin;

    public void OnPointerEnter() {
        if (redBin) GameController.instance.onRedBin = true;
        if (yellowBin) GameController.instance.onYellowBin = true;
        if (greenBin) GameController.instance.onGreenBin = true;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        OnPointerEnter();
    }

    public void OnPointerExit() {
        if (redBin) GameController.instance.onRedBin = false;
        if (yellowBin) GameController.instance.onYellowBin = false;
        if (greenBin) GameController.instance.onGreenBin = false;
    }

    public void OnPointerExit(PointerEventData eventData) {
        OnPointerExit();
    }
}
