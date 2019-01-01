using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {

    public int bodyCount = 0;

	void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
