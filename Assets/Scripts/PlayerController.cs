using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;
    private void Awake(){
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Jump(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
        animator.SetBool("jump",true);
        }else if(Input.GetKeyUp(KeyCode.UpArrow)){
        animator.SetBool("jump",false);
        }
    }
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
        animator.SetFloat("speed",Mathf.Abs(speed));
        Vector3 scale = transform.localScale;
        if(horizontal < 0){
            scale.x = -1f * Mathf.Abs(scale.x);
        }else if(horizontal > 0){
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
        //jump
        if(vertical>0){
            animator.SetBool("jump",true);
        }else{
            animator.SetBool("jump",false);
        }
    }
}
