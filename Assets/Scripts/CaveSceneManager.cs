using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CaveSceneManager : MonoBehaviour {

    public enum CaveSceneStates {Dialogue, Play}
    public CaveSceneStates caveSceneState = CaveSceneStates.Dialogue;
    public Text dialogueText;
    public Text startText;
    public string[] dialogue;
    private int dialogueIndex = 0;
    private bool alreadyPlaying = false;
    public float dialogueTime = 2f;
    private GameObject player;
    public Vector3 firstShadowOffset;
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement2D>().gameObject;
    }
	void Update()
    {
        switch (caveSceneState)
        {
            case CaveSceneStates.Dialogue:
                startText.enabled = false;
                dialogueText.enabled = true;
                Dialogue();
                break;
            case CaveSceneStates.Play:
                if(!alreadyPlaying)
                {
                    try
                    {
                        GetComponent<EnemySpawner>().StartCoroutine("SpawnPeriodically");
                    }
                    catch (Exception)
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                    alreadyPlaying = true;
                }
                break;
            default:
                break;
        }
    }

    void Dialogue()
    {
        if(Input.GetButtonDown("Select"))
        {
            dialogueIndex++;
        }

        if (dialogueIndex >= dialogue.Length)
        {
            dialogueIndex = 0;
            StartCoroutine("MakeDialogueDisappear");
            caveSceneState = CaveSceneStates.Play;
        }
        else
            dialogueText.text = dialogue[dialogueIndex];
        Text crazyTalk= null;
        Text runAway = null;
        try
        {
            crazyTalk = GameObject.Find("This guy's crazy!").GetComponent<Text>();
            runAway = GameObject.Find("Run away!").GetComponent<Text>();
        } catch (Exception) { }
        if (crazyTalk != null)
        {
            if(dialogueIndex == 1)
            {
                crazyTalk.enabled = true;
            }
            else
            {
                crazyTalk.enabled = false;
            }
        }
        if(runAway != null)
        {
            if (dialogueIndex == 2)
            {
                runAway.enabled = true;
            }
            else
                runAway.enabled = false;
        }
    }

    IEnumerator MakeDialogueDisappear()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogueText.enabled = false;
    }
}
