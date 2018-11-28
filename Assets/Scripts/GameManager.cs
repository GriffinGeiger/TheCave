using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Animator fadeAnim;
    public Image black;
    public enum GameStates { Menu, Dialogue, Play }
    public GameStates gameState;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        gameState = GameStates.Menu;
    }

    void Update()
    {
        switch (gameState)
        {
            case GameStates.Menu:
                break;
            case GameStates.Dialogue:
                break;
            case GameStates.Play:
                break;
            default:
                break;
        }

    }

    public void PlayerIsDead()
    {
        StartCoroutine(Fading());

    }

    IEnumerator Fading()
    {
        fadeAnim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        Debug.Log("Loading New Scene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

