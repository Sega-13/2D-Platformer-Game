using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public EnemyController enemyController;
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    
    private void Awake(){
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
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
        //Jump();
        Crouch();  
    }
    private void MoveCharacter(float horizontal,float vertical){
      //move character horizontally
      Vector3 position = transform.position;
      position.x = position.x + horizontal*speed*Time.deltaTime;
      transform.position = position;   
      //move vertically
      if(vertical > 0){
          rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
      }
      
    }

    private void PlayMovementAnimation(float horizontal, float vertical){
        
        Vector3 scale = transform.localScale;
        if(horizontal < 0){
            animator.SetFloat("speed",Mathf.Abs(speed));
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontal > 0){
            animator.SetFloat("speed",Mathf.Abs(speed));
            scale.x = Mathf.Abs(scale.x);
        }else{
            animator.SetFloat("speed", 0);
        }
        transform.localScale = scale;
        //jump
        if(vertical>0){
            animator.SetBool("jump",true);
        }else{
            animator.SetBool("jump",false);
        }
    }

    public void PickUpKey()
    {
        scoreController.IncreaseScore(10);
    }

    public void OnAnimationDone(String animationName)
    {
        animator.SetBool("hurt", false);
        sr.sprite.name = animationName;
    }
    
}
