using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool CollFirefighter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CollFirefighter){
            if (Input.GetKeyDown(KeyCode.LeftShift)){
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
