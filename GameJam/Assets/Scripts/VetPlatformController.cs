using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VetPlatformController : MonoBehaviour
{
    public GameController GameController;
    private Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isGrounded = false;
    private bool onBox = false;

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
        if (Input.GetKey(KeyCode.LeftArrow)){ x = -1.0f; }
        else if (Input.GetKey(KeyCode.RightArrow)){ x = 1.0f;}
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }

    void Jump() {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded || onBox)) {
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

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Box") {
            if (!isGrounded){
                onBox = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Pickup") {
            GameController.foundPiece();
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
        else if (collision.gameObject.tag == "Box") {
            if (onBox){
                onBox = false;
            }
        }
    }
}
