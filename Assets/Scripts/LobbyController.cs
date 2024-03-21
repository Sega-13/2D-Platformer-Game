using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField]private Button buttonPlay;
    [SerializeField]private GameObject LevelSelection;
    private void Awake()
    {
        buttonPlay.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelection.SetActive(true);
    }
   
}

