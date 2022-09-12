using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstronotController : MonoBehaviour
{   

    private float movementInputDirection;
    public float movementSpeed = 10f;
    public float variableJumpHeightMultiplier = 0.95f;

    public float jumpForce = 16f;
    private int amountOfJumpsLeft;
    private int amountOfJumps = 2;

    public float groundCheckRadius = 0.5f;
    private Rigidbody2D rigidBody2D;
    private Animator animator;
    private bool isWalking;
    private bool isGrounded;
    private bool isAttacking;


    private bool canJump;
    private bool isFacingRight = true;
    public Transform groundCheck;

    public LayerMask whatIsGround;




    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
         amountOfJumpsLeft = amountOfJumps;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckIfCanJump();
        UpdateAnimations();
        CheckMovementDirection();
    }
    void FixedUpdate(){
        CheckSurroundings();
        ApplyMovement();
    }
    private void UpdateAnimations(){
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isAttacking",isAttacking);
        animator.SetFloat("yVelocity",rigidBody2D.velocity.y);
    }
    //Tuşa Basıldı mı Kontrol Et
    private void CheckInput()
    {   
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonUp("Fire1"))
        {
            isAttacking = !isAttacking;
        }if(Input.GetButtonDown("Fire1"))
        {
            isAttacking = !isAttacking;
        }
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        if(Input.GetButtonUp("Jump"))
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x,rigidBody2D.velocity.y * variableJumpHeightMultiplier);

        }
    }
    //Temasları kontrol et
    private void CheckSurroundings(){
        // GroundCheck çemberinin pozisyonu, açısı ve yeri belirtiyoruz.Eğer değiyorsa true sonuç dönüyor.
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
    }
    private void CheckIfCanJump(){
        if(isGrounded && rigidBody2D.velocity.y <=0)
        {
            amountOfJumpsLeft = amountOfJumps;
        }
        if(amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else{
            canJump = true;
        }
    }
  
    //Horizontal değere göre (-1,1) Yönünü değiştir. 
    private void CheckMovementDirection(){
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }
        if(rigidBody2D.velocity.x != 0)
        {
            isWalking =true;
        }
        else{
            isWalking = false;
        }
    }
    
    //Haraketleri Uygula
    private void ApplyMovement()
    {   
        rigidBody2D.velocity = new Vector2(movementSpeed * movementInputDirection, rigidBody2D.velocity.y);
         
    }
    private void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0f,180f,0);
    }
    private void Jump(){
        if(canJump)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.position.x, jumpForce);
            amountOfJumpsLeft --;
        }
    }
   
    //Gizmos ile Şekil Çiz
    private void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
    }
}
