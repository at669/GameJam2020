using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlatformController : MonoBehaviour
{
    private GameController GameController;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private bool isGrounded = false;
    private bool onBox = false;
    private bool facingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        Move();
        Jump();
        BetterJump();
    }


    void Move() {
        float x = 0.0f;
        if (Input.GetKey(KeyCode.A)){ x = -1.0f; }
        else if (Input.GetKey(KeyCode.D)){ x = 1.0f;}
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if (x > 0 && !facingRight){
            facingRight = true;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x < 0 && facingRight){
            facingRight = false;
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || onBox)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            onBox = false;
        }
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Water") {
            GameController.PieceCollected("Water", true);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Rock") {
            if (!isGrounded){
                onBox = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
        else if (collision.gameObject.tag == "Rock") {
            if (onBox){
                onBox = false;
            }
        }
    }
}
