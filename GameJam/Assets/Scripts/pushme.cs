using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushme : MonoBehaviour
{
    private bool Moveable = false;
    private bool firefighterBool = false;
    private bool vetBool = false;
    private Rigidbody2D rb;

    public GameObject _vet;
    public GameObject _firefighter;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics2D.IgnoreCollision(_vet.GetComponent<Collider2D>(), _firefighter.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Moveable) {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        else {
            rb.bodyType = RigidbodyType2D.Static;
        } 
        
        CanPush();       
    }

    void CanPush(){
        // vetBool and firefighterBool must both be there
        // if they are not, turn the box static
        if ((firefighterBool) && (vetBool)) {
            Moveable = true;
        }
        else {
            Moveable = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Firefighter") {
            firefighterBool = true;
            // Debug.Log("firefighterBool collission "+ System.DateTime.Now);
        }
        if (collision.gameObject.tag == "Vet") {
            vetBool = true;
            // Debug.Log("vetBool collission "+ System.DateTime.Now);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Firefighter") {
            firefighterBool = false;
            // Debug.Log("firefighterBool left "+ System.DateTime.Now);
        }
        if (collision.gameObject.tag == "Vet") {
            vetBool = false;
            // Debug.Log("vetBool left "+ System.DateTime.Now);
        }
    }
}
