using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReturnToMain : EventTrigger, IPointerUpHandler
{

    public new void OnPointerUp(PointerEventData data)
    {
        SceneManager.LoadScene(0);
    }
}

