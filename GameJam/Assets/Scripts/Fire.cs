using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private GameController GameController;
    private bool CollFirefighter = false;
    private float t = 0;
    public float FadeDur = 1.0f;
    private bool isDeactivating = false;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CollFirefighter){
            if (Input.GetKeyDown(KeyCode.LeftShift) && GameController.GetNum("Water") > 0){
                isDeactivating = true;
                GameController.PieceCollected("Water", false);
            }
        }
        if (isDeactivating){
            this.gameObject.transform.localScale = Vector3.Lerp(this.gameObject.transform.localScale, Vector3.zero, t);
                if (t < 1){
                    t += Time.deltaTime/FadeDur;
                }
                else {
                    Destroy(this.gameObject);
                }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Firefighter") {
            CollFirefighter = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.tag == "Firefighter") {
            CollFirefighter = false;
        }
    }
}
