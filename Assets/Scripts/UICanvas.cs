using UnityEngine;
using UnityEngine.SceneManagement;

public class UICanvas : MonoBehaviour
{
    // Onclick event for Quit Button
    public void QuitButton()
    {
        Application.Quit();
    }
    // Onclick event for Restart Button
    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
