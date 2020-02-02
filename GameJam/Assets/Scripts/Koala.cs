using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koala : MonoBehaviour
{
    public GameController GameController;
    private bool CollRescuer = false;
    private SpriteRenderer KoalaSprite;

    // Start is called before the first frame update
    void Start()
    {
        KoalaSprite = this.GetComponent<SpriteRenderer>();
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollRescuer){
            if (Input.GetKeyDown(KeyCode.RightShift)){
                KoalaSprite.color = Color.white;
                GameController.KoalaHealed();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Vet") {
            CollRescuer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Vet") {
            CollRescuer = false;
        }
    }
}
