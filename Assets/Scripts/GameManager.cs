using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject SettingsGO;
    #region Singleton
    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int score = 0; // ScoreKeeping

    public bool gameEnded = false;

    /*/public void AddScore(int scoretoAdd)
    {
        // Increase Score Value by incoming score
        score += scoretoAdd;
        // Update UI Here
        UIManager.Instance.UpdateScore(score);
    }
    /*/
    public void GameOver()
    {
        gameEnded = true;
    }

    //Reloads the Current Level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PrevLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SwitchLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
    public void QuitGame()
    {
        //SceneManager.Application.Quit();
    }
    public void OpenSettings()
    {

        /*/switch (MenuSelect)
        {
            case menuSelect.Play:
                break;
            case
            /*/

        Setting.SettingsOpen = !Setting.SettingsOpen;


    }
    void Update()
    {
        if (Setting.SettingsOpen)
        {
            SettingsGO.SetActive(true);
        }
        else if (!Setting.SettingsOpen)
        {
            SettingsGO.SetActive(false);
        }
    }

}
