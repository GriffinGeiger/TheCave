using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public GameObject character;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = .1f;
    public float yOffset = 1f;

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, character.transform.position.x, 
            ref velocity.x, smoothTime);
        float posY = Mathf.SmoothDamp(transform.position.y, character.transform.position.y + yOffset,
           ref velocity.y, smoothTime);
        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
