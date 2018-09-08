using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Rubbish : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Camera camera;

    private bool isDragged = false;
    private bool isDragging = false;
    private Vector3 originalPosition;
    private float releasedTime;

    public AnimationCurve xCurve;
    public AnimationCurve yCurve;
    public float duration = 5;

    public RectTransform rectTransform;

    public bool redBin;
    public bool greenBin;
    public bool yellowBin;

    void Start() {
        camera = Camera.main;
        originalPosition = transform.position;
        rectTransform = GetComponent<RectTransform>();
    }
    
    void Update() {
        if (isDragged && !isDragging) {
            float currentTime = Time.time;
            float time = currentTime - releasedTime;
            if (duration < time) {
                isDragged = false;
                return;
            }
            transform.position = new Vector3(xCurve.Evaluate(time), yCurve.Evaluate(time), 0f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        isDragged = true;
        isDragging = false;

        if (rectTransform.anchoredPosition.y <= 130f) {
            if (greenBin && rectTransform.anchoredPosition.x <= -130f) { GameController.instance.Destroy(this); return; }
            if (redBin && rectTransform.anchoredPosition.x > -130f && rectTransform.anchoredPosition.x < 130f) { GameController.instance.Destroy(this); return; }
            if (yellowBin && rectTransform.anchoredPosition.x >= 130f) { GameController.instance.Destroy(this); return; }
        }

        releasedTime = Time.time;
        xCurve = new AnimationCurve(new Keyframe[2] { new Keyframe(0, transform.position.x), new Keyframe(duration, originalPosition.x) });
        yCurve = new AnimationCurve(new Keyframe[2] { new Keyframe(0, transform.position.y), new Keyframe(duration, originalPosition.y) });
    }
}
