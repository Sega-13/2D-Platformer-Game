using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameExitController : MonoBehaviour
{
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonReload;
    [SerializeField] private Button buttonNext;

    private void Awake()
    {
        buttonExit.onClick.AddListener(ExitGame);
        buttonReload.onClick.AddListener(ReloadLevel);
        buttonNext.onClick.AddListener(NextLevel);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Application.Quit();
        Debug.Log("Game Exited");

    }
    public void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.LevelStart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        SoundManager.Instance.Play(Sounds.LevelStart);
        HealthManager.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
