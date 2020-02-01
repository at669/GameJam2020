using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI numFound;
    public int PiecesCollected = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void foundPiece(){
        PiecesCollected++;
        numFound.text = PiecesCollected.ToString();
    }
}
