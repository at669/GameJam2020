using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public Transform PageHolder;
    private int curIdx = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < PageHolder.childCount; i++){
            PageHolder.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextButton(){
        curIdx++;
        PageHolder.GetChild(curIdx - 1).gameObject.SetActive(false);
        PageHolder.GetChild(curIdx).gameObject.SetActive(true);
    }

    public void prevButton(){
        curIdx--;
        PageHolder.GetChild(curIdx + 1).gameObject.SetActive(false);
        PageHolder.GetChild(curIdx).gameObject.SetActive(true);
    }
}
