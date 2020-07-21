using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameController gameController;
    public static string Tag = "Ball";
    public float InitialSpeed = 10;
    private float speed;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        speed = gameController.BallSpeedMutator * InitialSpeed;
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("Serve", 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.rotation += 0.1f;
    }

    void Serve()
    {
        var dirX = GameController.LastSideToScore == GameController.Side.Left ? 1 : -1;
        var dirY = Random.Range(0, 2) < 1 ? 1 : -1;
        var directionVector = new Vector2(dirX * 4, dirY * 3);
        directionVector.Scale(new Vector2(speed, speed));
        rb2d.AddForce(directionVector);
    }

    void Reset()
    {
        speed = gameController.BallSpeedMutator * InitialSpeed;
        // Add parameter side "l" , "r" 
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void ResetAndServe()
    {
        Invoke("Reset", 0.01f);
        Invoke("Serve", 1.5f);
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
