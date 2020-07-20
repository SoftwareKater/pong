using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static string Tag = "Ball";
    public int InitialSpeed = 5;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Serve", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Serve()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            var directionVector = new Vector2(4, -3);
            directionVector.Scale(new Vector2(InitialSpeed, InitialSpeed));
            rb2d.AddForce(directionVector);
        }
        else 
        {
            var directionVector = new Vector2(4, -3);
            directionVector.Scale(new Vector2(InitialSpeed, InitialSpeed));
            rb2d.AddForce(directionVector);
        }
    }

    void Reset()
    {
        // Add parameter side "l" , "r" 
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void ResetAndServe()
    {
        Invoke("Reset", 0.1f);
        Invoke("Serve", 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 velocityAfterCollision;
            velocityAfterCollision.x = rb2d.velocity.x;
            velocityAfterCollision.y = (rb2d.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = velocityAfterCollision;
        }
    }
}
