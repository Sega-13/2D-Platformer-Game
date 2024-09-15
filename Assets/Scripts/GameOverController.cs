using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Button buttonRestart;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(ReloadLevel);
    }
   
    private void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.LevelStart);
        HealthManager.health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  
}
