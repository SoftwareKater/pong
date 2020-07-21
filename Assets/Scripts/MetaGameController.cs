using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
/// <summary>
/// The MetaGameController is responsible for switching control between the high level
/// contexts of the application, eg the Main Menu and Gameplay systems.
/// </summary>
public class MetaGameController : MonoBehaviour
{
    public MenuController menuController;
    public GameController gameController;

    public GameObject PaddleLeft;
    public GameObject PaddleRight;
    public KeyCode menuKey = KeyCode.Escape;

    bool showMenuCanvas = false;

    void OnEnable()
    {
        _ToggleMainMenu(showMenuCanvas);
    }

    /// <summary>
    /// Turn the main menu on or off.
    /// </summary>
    /// <param name="show"></param>
    public void ToggleMainMenu(bool show)
    {
        if (this.showMenuCanvas != show)
        {
            _ToggleMainMenu(show);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(menuKey))
        {
            ToggleMainMenu(show: !showMenuCanvas);
        }
    }

    public void UpdateBallSpeedMutator(Slider slider)
    {
        gameController.BallSpeedMutator = slider.value;
    }

    public void UpdatePaddleSizeMutator(Slider slider)
    {
        gameController.PaddleSizeMutator = slider.value;
    }

    public void UpdateLeftPlayerPaddleColor(string colorString)
    {
        var rgba = colorString.Split(';').Select(c => float.Parse(c)).ToList();
        var  color = new Color(rgba[0], rgba[1], rgba[2], rgba[3]);
        var spriteRenderer = PaddleLeft.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
    
    public void UpdateRightPlayerPaddleColor(Color color)
    {
        var spriteRenderer = PaddleRight.GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }
    
    private void _ToggleMainMenu(bool show)
    {
        if (show)
        {
            Time.timeScale = 0;
            menuController.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menuController.gameObject.SetActive(false);
        }
        this.showMenuCanvas = show;
    }
}
