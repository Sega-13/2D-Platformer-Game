using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
