using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameOverController gameOverController;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private ParticalController particleController;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private HealthManager healthManager;
    private bool doubleJump;
    private float doubleJumpForce = 12f;

    private const string JUMP = "jump";
    private const String SPEED = "speed";
    private Image[] heart;
    int heartVal = -1;
    private void Start()
    {
        heartVal = -1;
        heart =  healthManager.GetImages();
        for (int i = 0; i < HealthManager.health; i++)
        {
            heart[i].sprite = healthManager.GetFullHeart();
            heartVal++;
        }
    }
    public Animator GetPlayerAnimator() 
    { 
        return playerAnimator;
    }  
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            playerAnimator.SetBool("crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightControl))
        {
            playerAnimator.SetBool("crouch", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyController>() != null)
        {
            if(heartVal >= 0)
            {
                heart[heartVal].sprite = healthManager.GetEmptyHeart();
                heartVal--;
            }
                
        }
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw(JUMP);
        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);
        Crouch();

    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
        //move vertically

        if (IsGrounded() && !(Input.GetButtonDown(JUMP)))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown(JUMP))
        {
            if (IsGrounded() || doubleJump)
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, doubleJump ? doubleJumpForce : jump);
                doubleJump = !doubleJump;
            }

        }

    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {

        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            playerAnimator.SetFloat(SPEED, Mathf.Abs(speed));
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            playerAnimator.SetFloat(SPEED, Mathf.Abs(speed));
            scale.x = Mathf.Abs(scale.x);
        }
        else
        {
            playerAnimator.SetFloat(SPEED, 0);
        }
        transform.localScale = scale;
        //jump
        if (vertical > 0)
        {
            playerAnimator.SetBool(JUMP, true);
        }
        else
        {
            playerAnimator.SetBool(JUMP, false);
        }
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void OnAnimationDone(String animationName)
    {
        playerAnimator.SetBool("hurt", false);
        playerSpriteRenderer.sprite.name = animationName;
    }
    public void GameOverScreen()
    {
        SoundManager.Instance.Play(Sounds.LevelOver);
        particleController.PlayParticleEffect();
        gameOverController.gameObject.SetActive(true);
        this.enabled = false;
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}