using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D ball;
    public float velocity = 15f;
    //random direction
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
            ball.AddForce(new Vector2(20, velocity));
        else
            ball.AddForce(new Vector2(-20, velocity));
    }
    //reset ball position
    void ResetBall()
    {
        ball.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 v;
            v.x = ball.velocity.x;
            v.y = (ball.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            ball.velocity = v;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
