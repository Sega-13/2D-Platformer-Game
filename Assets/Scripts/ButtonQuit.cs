using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
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
