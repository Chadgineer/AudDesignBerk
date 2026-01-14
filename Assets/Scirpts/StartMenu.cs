using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject normalCanvas;
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    public void StartGame()
    {
        normalCanvas.SetActive(true);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
