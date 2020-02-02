using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public string TagName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        // Destroy duplicates
        if (GameObject.FindGameObjectsWithTag(TagName).Length > 1){
            Destroy(this.gameObject);
        }
    }

}
