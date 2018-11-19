using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : DeathAction {

    public override void Die()
    {
        Debug.Log("You Died");
    }
}
