using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField]private Animator playerAnimator;
    [SerializeField]private Rigidbody2D playerRigidBody;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>()!= null)
        {
            Die();
        }
    }
    public void Die()
    {
        playerRigidBody.bodyType = RigidbodyType2D.Static;
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        playerAnimator.SetTrigger("death");
    }
}
