using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteController : MonoBehaviour
{

    [SerializeField] private GameExitController exitController;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            SoundManager.Instance.Play(Sounds.LevelFinish);
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        LevelManager.Instance.MarkCurrentLevelComplete();
        exitController.gameObject.SetActive(true);

    }
}
