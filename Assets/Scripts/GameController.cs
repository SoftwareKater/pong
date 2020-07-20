using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int PlayerLeftScore = 0;
    public static int PlayerRightScore = 0;

    public static int WinningScore = 3;
    public GUISkin layout;

    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag(BallController.Tag);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + PlayerLeftScore);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + PlayerRightScore);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53), "RESTART"))
        {
            PlayerLeftScore = 0;
            PlayerRightScore = 0;
            ball.SendMessage("ResetAndServe", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (PlayerLeftScore == WinningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "LEFT PLAYER WINS");
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver);
        } 
        else if (PlayerRightScore == WinningScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "RIGHT PLAYER WINS");
            ball.SendMessage("Reset", null, SendMessageOptions.RequireReceiver);
        }
}   


    public static void Score(Side side)
    {
        if (side == Side.Left)
        {
            PlayerRightScore += 1;
        }
        else
        {
            PlayerLeftScore += 1;
        }
    }

    public enum Side
    {
        Left,
        Right
    }
}
