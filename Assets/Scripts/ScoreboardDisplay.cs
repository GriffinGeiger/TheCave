using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreboardDisplay : MonoBehaviour
{
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
            GameObject.Find("ScoreBoardText").GetComponent<Text>().text = "Shadows Defeated: " + FindObjectOfType<ScoreBoard>().bodyCount;
        else
            GameObject.Find("ScoreBoardText").GetComponent<Text>().text = "Helpful people pummeled: " + FindObjectOfType<ScoreBoard>().bodyCount;
    }
}
