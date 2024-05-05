using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    
    [SerializeField]private GameObject pointA;
    [SerializeField]private GameObject pointB;
    [SerializeField]private Rigidbody2D enemyRigidBody;
    [SerializeField]private float speed;
    private Transform currentPoint;
    private float currentPos,posA,posB;
    
   
    Vector2 point;
    private void Start()
    {
        currentPoint = pointB.transform;

    }

    private void Update()
    {
        EnemyTraverse();
    }
    private void EnemyTraverse()
    {

        currentPos = currentPoint.position.x;
        posA = pointA.transform.position.x;
        posB = pointB.transform.position.x;
        if (currentPos.Equals(posB))
        {
            enemyRigidBody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.transform.position) < 0.7f && currentPos.Equals(posB))
        {
            Flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.7f && currentPos.Equals(posA))
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
            playerController.GetPlayerAnimator().SetBool("hurt", true);
            if (HealthManager.health <= 0)
            {
                SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
                playerController.GetPlayerAnimator().SetTrigger("death");

            }
        }
    }



}
