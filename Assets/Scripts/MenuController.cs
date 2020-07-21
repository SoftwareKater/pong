using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] panels;
    GameObject ball;

    public void SetActivePanel(int index)
    {
        for (var i = 0; i < panels.Length; i++)
        {
            var active = i == index;
            var g = panels[i];
            if (g.activeSelf != active) g.SetActive(active);
        }
    }

    void OnEnable()
    {
        SetActivePanel(0);
    }
    
    public void OnRestartButton()
    {
        GameController.PlayerLeftScore = 0;
        GameController.PlayerRightScore = 0;
        ball.SendMessage("ResetAndServe", 0.5f, SendMessageOptions.RequireReceiver);
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag(BallController.Tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
