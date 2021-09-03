using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    public float speed = 10.0f;
    public float boundY = 2.25f;

    public Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var v = player.velocity;

        if (Input.GetKey(moveUp))
        {
            v.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            v.y = -speed;
        }
        else
            v.y = 0;

        player.velocity = v;

        var pos = transform.position;
        if (pos.y > boundY)
            pos.y = boundY;
        else if (pos.y < -boundY)
            pos.y = -boundY;
        transform.position = pos;
    }
}
