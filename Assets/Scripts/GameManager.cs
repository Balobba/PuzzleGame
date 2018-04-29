using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour //The game manager that controlls the state of the game. 
    //Includes game over condition, win condition, pause canvas.
{

    public float waitToReload;
    public float waitToWin;

    public GameObject thePlayer;


    public GameObject pauseScreen;
    public GameObject HUD;
    private bool paused;

    private int tempHP;
    private float tempOxygen;

    public int gameOverIndex;
    public int winIndex;

    public static bool gmExists;



    void Start()
    {
      /*  {
            if (!gmExists)
            {
                gmExists = true;
                DontDestroyOnLoad(transform.gameObject);

            }
            else
            {
                Destroy(gameObject);
            }

        }
        */

        // thePlayer.GetComponent<PlayerHealthManager>();
        //DontDestroyOnLoad(pauseScreen); //This makes the user be able to pause between scenes
  
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!paused)
            {
                PauseGame();
                
            }
            else
            {

                ResumeGame();
            }

        }

        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(1);

        }*/


    }

    private void PauseGame()
    {
        paused = true;
        pauseScreen.SetActive(true);
        HUD.SetActive(false);

        Time.timeScale = 0;

    }


    public void ResumeGame()
    {
        paused = false;
        pauseScreen.SetActive(false);
        HUD.SetActive(true);

        Time.timeScale = 1;


    }


    public void GameOver()
    {

        
        waitToReload -= Time.deltaTime;
        if (waitToReload < 0)
        {
            
            thePlayer.SetActive(false);
            
            SceneManager.LoadScene(gameOverIndex);

            //Application.LoadLevel(Application.loadedLevel); //reloads the level and spawns player where he started
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //another way to to the same thing (loading the scene instead)

        }


    }


    public void WonGame()
    {


        waitToWin -= Time.deltaTime;
        if (waitToWin < 0)
        {

            SceneManager.LoadScene(winIndex);
            thePlayer.SetActive(false);

            


        }

    }


}
