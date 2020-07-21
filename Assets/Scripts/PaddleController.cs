using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public GameController gameController;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 5.4f;

    public float height;
    private Rigidbody2D rb2d;
    // private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.5f, gameController.PaddleSizeMutator, 0);
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp)) {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown)) {
            vel.y = -speed;
        }
        else {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY) {
            pos.y = boundY;
        }
        else if (pos.y < -boundY) {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
