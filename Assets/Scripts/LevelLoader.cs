using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float timeToWait = 4f;

    private int currentSceneIndex;

    private IEnumerator Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            yield return new WaitForSeconds(timeToWait);
            LoadNextScene();
        }
    }

    public void LoadNextScene() => SceneManager.LoadScene(currentSceneIndex + 1);

    public void LoadYouLose() => SceneManager.LoadScene("Lose Screen");

    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start Screen");
        Time.timeScale = 1f;
    }

    public void QuitGame() => Application.Quit();
}
