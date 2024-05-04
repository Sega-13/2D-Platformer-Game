using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    Vector2 point;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;

    }

    private void Update()
    {
        EnemyTraverse();
    }
    private void EnemyTraverse()
    {
        point = currentPoint.position - transform.position;


        if (currentPoint.position.Equals(pointB.transform.position))
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.transform.position) < 0.7f && currentPoint.position.Equals(pointB.transform.position))
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.7f && currentPoint.position.Equals(pointA.transform.position))
        {
            Flip();
            currentPoint = pointB.transform;
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            HealthManager.health--;
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.playerAnimator.SetBool("hurt", true);
            if (HealthManager.health <= 0)
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
                playerController.playerAnimator.SetTrigger("death");

            }
        }
    }



}
