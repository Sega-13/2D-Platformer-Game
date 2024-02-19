using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameOverController gameOverController;
    public ScoreController scoreController;
    //public EnemyController enemyController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private BoxCollider2D bx2d;
    private SpriteRenderer sr;
    public ParticalController particleController;
    [SerializeField] private LayerMask jumpableGround;
    private bool doubleJump;
    private float doubleJumpForce = 16f;
   // private bool isGrounded;
   
   
    


    //public GameOverController gameOverController;
    private void Awake(){
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        bx2d = gameObject.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    
    void Crouch(){
        if(Input.GetKeyDown(KeyCode.RightControl)){
            animator.SetBool("crouch",true);
        }else if(Input.GetKeyUp(KeyCode.RightControl)){
            animator.SetBool("crouch", false);
        }
    }
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("jump");
        MoveCharacter(horizontal,vertical);
        PlayMovementAnimation(horizontal,vertical);
        Crouch();
       
    }
    private void MoveCharacter(float horizontal,float vertical){
      //move character horizontally
      Vector3 position = transform.position;
      position.x = position.x + horizontal*speed*Time.deltaTime;
      transform.position = position;
        //move vertically
        /*if (vertical > 0)
        {
            rb2d.velocity = Vector2.up * jump;
           
        }*/

        if(IsGrounded() && !(Input.GetButtonDown("jump")))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("jump"))
        {
            if (IsGrounded() || doubleJump)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJump ? doubleJumpForce : jump);
                doubleJump = !doubleJump;
            }

        }

    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        
        Vector3 scale = transform.localScale;
        if(horizontal < 0){
            SoundManager.Instance.Play(Sounds.PlayerMove);
            animator.SetFloat("speed",Mathf.Abs(speed));
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontal > 0){
            SoundManager.Instance.Play(Sounds.PlayerMove);
            animator.SetFloat("speed",Mathf.Abs(speed));
            scale.x = Mathf.Abs(scale.x);
        }else{
            animator.SetFloat("speed", 0);
        }
        transform.localScale = scale;
        //jump
        if (vertical > 0)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }
    public void PlayerKill()
    {
       // gameOverController.PlayerDied();
        //this.enabled = false;
    }
    public void OnAnimationDone(String animationName)
    {
        animator.SetBool("hurt", false);
        sr.sprite.name = animationName;
        /*gameOverController.gameObject.SetActive(true);
        this.enabled = false;*/
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
        return Physics2D.BoxCast(bx2d.bounds.center, bx2d.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
