using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2.0f;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        // Resets Score from ScoreKeeper Script
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("MainLevel");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        // Application.Quit() can't be seen in Game Dev mode
        Debug.Log("Quitting Game");

        /*
         * If in a WebGL game 'Application.Quit()' will not work because it can not "quit" out of the webpage
         * 
         * If mobile game there is a few other things you want to do on top of/instead of 'Application.Quit()'
         */
        Application.Quit();         // This Hard Exits The Game
    }


    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }


}
