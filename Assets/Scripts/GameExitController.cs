using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameExitController : MonoBehaviour
{
    [SerializeField] private Button buttonExit;

    private void Awake()
    {
        buttonExit.onClick.AddListener(ExitGame);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
        Application.Quit();
        Debug.Log("Game Exited");

    }
}
