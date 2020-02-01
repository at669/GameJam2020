using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI numWaterFound;
    public TextMeshProUGUI numBandagesFound;
    public TextMeshProUGUI numKoalasHealed;
    public int KoalasHealed = 0;
    public int WaterHeld = 0;
    public int BandagesHeld = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PieceCollected(string val){
        if (val == "Water"){
            WaterHeld++;
            numWaterFound.text = WaterHeld.ToString();
        }
        else if (val == "Bandage"){
            BandagesHeld++;
            numBandagesFound.text = BandagesHeld.ToString();
        }
    }
}
