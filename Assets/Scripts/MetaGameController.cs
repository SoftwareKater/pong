using UnityEngine;

/// <summary>
/// The MetaGameController is responsible for switching control between the high level
/// contexts of the application, eg the Main Menu and Gameplay systems.
/// </summary>
public class MetaGameController : MonoBehaviour
{
    /// <summary>
    /// The main UI object which used for the menu.
    /// </summary>
    public MenuController menuController;

    /// <summary>
    /// The game controller.
    /// </summary>
    public GameController gameController;

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

    void Update()
    {
        if (Input.GetKeyDown(menuKey))
        {
            ToggleMainMenu(show: !showMenuCanvas);
        }
    }

}
