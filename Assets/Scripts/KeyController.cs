using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField]private ParticalController particalController;
    private void Awake()
    {
        particalController.PlayParticleEffect();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.PickUpKey();
            Destroy(gameObject);
        }
    }
}
