using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeSceneOnClick : MonoBehaviour //Resumes the scene on click. Is used in the pause canvas
{

    public GameManager gameManager;

    private void Start()
    {
        gameManager.GetComponent<GameManager>();

    }



    public void ResumeGame()
    {
        gameManager.ResumeGame(); //Calls the game manager to unfreeze the game
    }


}
