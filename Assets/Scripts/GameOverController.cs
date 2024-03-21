using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
   
    private void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.LevelStart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
}
