using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveSceneManager : MonoBehaviour {

    public enum CaveSceneStates { Menu, Dialogue, Play}
    public CaveSceneStates caveSceneState = CaveSceneStates.Menu;
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
            case CaveSceneStates.Menu:
                //display start message
                startText.enabled = true;
                if(Input.GetButtonDown("Select"))
                {
                    caveSceneState = CaveSceneStates.Dialogue;
                    GetComponent<EnemySpawner>().SpawnEnemy(player.transform.position + firstShadowOffset);
                }

                break;
            case CaveSceneStates.Dialogue:
                startText.enabled = false;
                dialogueText.enabled = true;
                Dialogue();
                break;
            case CaveSceneStates.Play:
                if(!alreadyPlaying)
                {
                    GetComponent<EnemySpawner>().StartCoroutine("SpawnPeriodically");
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
    }

    IEnumerator MakeDialogueDisappear()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogueText.enabled = false;
    }
}
