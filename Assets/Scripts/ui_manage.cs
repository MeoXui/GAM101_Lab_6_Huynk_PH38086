using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ui_manage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject btnContinue, btnPause;

    public void StartPlay()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void pause()
    {
        btnContinue.SetActive(true);
        btnPause.SetActive(false);
        Time.timeScale = 0;
    }

    public void cntinue()
    {
        btnContinue.SetActive(false);
        btnPause.SetActive(true);
        Time.timeScale = 1;
    }
}
