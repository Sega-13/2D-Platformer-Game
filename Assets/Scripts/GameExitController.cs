using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameExitController : MonoBehaviour
{
    GameOverController gameOverController;
    [SerializeField] private Button buttonExit;

    private void Awake()
    {
        gameOverController = gameObject.GetComponent<GameOverController>();
        buttonExit.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        gameOverController.gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(0);
        Application.Quit();
        //  SceneManager.UnloadSceneAsync(1);
        Debug.Log("Game Exited");

    }
}
