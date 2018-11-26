using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : DeathAction {

    public override void Die()
    {
        GameObject.Destroy(GetComponentInParent<CharacterController2D>().gameObject);
    }
}
