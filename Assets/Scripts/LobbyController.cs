using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]private Button buttonPlay;
    public GameObject LevelSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    private void PlayGame()
    {
        LevelSelection.SetActive(true);
        //SceneManager.LoadScene(1);

    }
   
}

