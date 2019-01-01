using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : DeathAction {

    public override void Die()
    {
        GameObject.Destroy(GetComponentInParent<CharacterController2D>().gameObject);
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        ScoreBoard sb = FindObjectOfType<ScoreBoard>();

        GameObject.Find("ScoreBoardText").GetComponent<Text>().text = "Shadows Defeated: " + ++sb.bodyCount;
    }
}
