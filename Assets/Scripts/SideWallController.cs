using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == BallController.Tag)
        {
            string wallName = transform.name;
            if (wallName == "WallLeft")
            {
                GameController.Score(GameController.Side.Left);
            }
            else if (wallName == "WallRight")
            {
                GameController.Score(GameController.Side.Right);
            }

            hit.gameObject.SendMessage("ResetAndServe", 1.0f, SendMessageOptions.RequireReceiver);
        }
    }
}
