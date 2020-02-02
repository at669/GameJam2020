using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton(){
        Time.timeScale = 0;
        PauseMenuUI.SetActive(true);
    }

    public void PlayButton(){
        Time.timeScale = 1;
        PauseMenuUI.SetActive(false);
    }

    public void HomeButton(){
        SceneManager.LoadScene("Menu");
    }

    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }


}
