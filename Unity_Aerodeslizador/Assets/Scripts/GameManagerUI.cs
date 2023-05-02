using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUI : MonoBehaviour
{

    //public static GameManagerUI Instance { get; private set; }

    //Which data remains:
    bool gamePaused;
    private GameObject pauseButton;
    private GameObject pauseMenu;
    //private void Awake()
    //{
    //    if (Instance != null && Instance != this)
    //    {
    //        Destroy(this);
    //    }
    //    else
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(this);
    //    }

    //}
    private void Start()
    {
        //Initialize data
        gamePaused = false;
        pauseButton = GameObject.Find("Btn_Pause");
        pauseMenu = GameObject.Find("Menu_Pause");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else { ResumeGame(); }
        }
    }
    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void RestartGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
