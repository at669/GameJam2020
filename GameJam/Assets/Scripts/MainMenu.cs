using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject InstructionsPanel;
    public GameObject LevelsPanel;
    public GameObject CreditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        BackButton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (!MainMenuPanel.activeInHierarchy){
                BackButton();
            }
        }
    }

    public void LevelLoad(int val){
        SceneManager.LoadScene(val.ToString());
    }

    public void InstructionsButton(){
        MainMenuPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
        LevelsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void LevelsButton(){
        MainMenuPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        LevelsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void CreditsButton(){
        MainMenuPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
        LevelsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void QuitButton(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BackButton(){
        MainMenuPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
        LevelsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }
}
