using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitToDesktopEventTrigger : EventTrigger, IPointerUpHandler {


    public new void OnPointerUp(PointerEventData data)
    {
        Debug.Log("Quit to desktop");
        Application.Quit();
    }
}

