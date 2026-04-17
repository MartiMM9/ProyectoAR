using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager_ImageTracking : MonoBehaviour
{
    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
