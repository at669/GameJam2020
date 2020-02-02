using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI numWaterFound;
    public TextMeshProUGUI numBandagesFound;
    public TextMeshProUGUI numKoalasHealed;
    public GameObject KoalaHolder;
    private GameObject Firefighter;
    private GameObject Rescuer;

    private GameObject WinScreen;

    private int totalKoalas = 0;
    private int KoalasHealed = 0;
    private int WaterHeld = 0;
    private int BandagesHeld = 0;

    private bool FireExited = false;
    private bool RescueExited = false;

    private bool WinState = false;

    // Start is called before the first frame update
    void Start()
    {
        totalKoalas = KoalaHolder.transform.childCount;
        numKoalasHealed.text = KoalasHealed.ToString() + "/" + totalKoalas.ToString();

        Firefighter = GameObject.FindGameObjectWithTag("Firefighter");
        Rescuer = GameObject.FindGameObjectWithTag("Vet");
        WinScreen = GameObject.Find("WinScreen");
        WinScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void PieceCollected(string val, bool found){
        if (found){
            if (val == "Water"){
                WaterHeld++;
                numWaterFound.text = WaterHeld.ToString();
            }
            else if (val == "Bandage"){
                BandagesHeld++;
                numBandagesFound.text = BandagesHeld.ToString();
            }
        }
        else {
            if (val == "Water"){
                WaterHeld--;
                numWaterFound.text = WaterHeld.ToString();
            }
            else if (val == "Bandage"){
                BandagesHeld--;
                numBandagesFound.text = BandagesHeld.ToString();
            }
        }
        
    }

    public void KoalaHealed(){
        KoalasHealed++;
        numKoalasHealed.text = KoalasHealed.ToString() + "/" + totalKoalas.ToString();
    }

    public void FireExit(){
        FireExited = true;
        if (KoalasHealed == totalKoalas){
            if (RescueExited){
                WinState = true;
                WinScreen.SetActive(true);
            }
            Destroy(Firefighter);
        }
    }

    public void RescueExit(){
        RescueExited = true;
        if (KoalasHealed == totalKoalas){
            if (FireExited){
                WinState = true;
                WinScreen.SetActive(true);
            }
            Destroy(Rescuer);
        }
    }

    public void LoadNextLevel(){
        int curLevel;
        int.TryParse(SceneManager.GetActiveScene().name, out curLevel);
        curLevel++;

        SceneManager.LoadScene(curLevel.ToString());
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("Menu");
    }
}
