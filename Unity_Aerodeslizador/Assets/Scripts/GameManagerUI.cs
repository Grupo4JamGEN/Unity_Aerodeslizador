using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerUI : MonoBehaviour
{

    //public static GameManagerUI Instance { get; private set; }

    //Important Objects:
    public GameObject playerGameObject;

    //Which data remains:
    public bool gamePaused;
    public bool gameOver;

    private GameObject pauseButton;
    private GameObject pauseMenu;
    private GameObject resumeButton;

    //Chronometer data
    private float startTime=60f;
    private bool isChronometerRunning = false;
    public TextMeshPro timerText;
    public TextMeshPro gameOverText;

    private GameObject blackBackground;
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
        gameOver = false;
        Time.timeScale = 1f;
        pauseButton = GameObject.Find("Btn_Pause");
        pauseMenu = GameObject.Find("Menu_Pause");
        resumeButton=GameObject.Find("Btn_ResumeGame");
        blackBackground = GameObject.Find("BlackBackground");
        pauseMenu.SetActive(false);
        blackBackground.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        //Chronometer initialization
        ResetChronometer();
        StartChronometer();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver){
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gamePaused)
                {
                    PauseGame();
                }
                else { ResumeGame(); }
            }

            //CHRONOMETER:
            if (isChronometerRunning)
            {
                float elapsedTime = Time.time - startTime;
                
                float timeLeft=UpdateTimerText(elapsedTime);
                //LOOSING BY TIME:
                if(timeLeft<=0f){
                    GameOver(false);

                }
                
            }

            //LOOSING BY FALL:
            if(playerGameObject.transform.position.y<=-2.5){
                GameOver(false);
            }
        }
        


        
    }
    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
        blackBackground.SetActive(false);
    }
    public void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
        blackBackground.SetActive(true);
    }

    public void RestartGame()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    void StartChronometer()
    {
        isChronometerRunning = true;
        //startTime = Time.time;
    }
    void ResetChronometer()
    {
        isChronometerRunning = false;
        UpdateTimerText(startTime);
    }
    public void EndChronometer()
    {
        isChronometerRunning = false;
    }

    public void GameOver(bool winCondition){
        EndChronometer();

        if(winCondition){
            gameOverText.text="YOU ARE THE SAVIOUR! \n The Human History is safe in M.O.T.H.E.R.";
        }else{
            gameOverText.text="WE DIDN'T MAKE IT!";
        }

        PauseGame();
        resumeButton.SetActive(false);
        gameOverText.gameObject.SetActive(true);
    }
    

    float UpdateTimerText(float elapsedTime)
    {
        float timeLeft=startTime-elapsedTime;
        string minutes=Mathf.Floor(timeLeft/60).ToString("00");
        string seconds=(timeLeft%60).ToString("00");
        //string minutes = ((int)elapsedTime / 60).ToString("00");
        //string seconds = (elapsedTime % 60).ToString("00.00");
        timerText.text = "Time: " + minutes + ":" + seconds;
        return timeLeft;
    }

}
