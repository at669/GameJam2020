using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    public float amplitude;
    public float frequency;
    private Vector3 initPos;
    private bool toFloat = true;

    // Start is called before the first frame update
    void Start()
    {
        initPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (toFloat){
            initPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = initPos;
        }
        
    }

    public void StopFloating(){
        toFloat = false;
    }
}
