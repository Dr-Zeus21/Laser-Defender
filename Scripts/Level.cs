using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 2.5f;
    [SerializeField] float gameStartDelay = 1.8f;
    [SerializeField] AudioClip gameStartSound;
    [SerializeField] [Range(0,1)] float gameStartSoundVolume = .7f;
    [SerializeField] [Range(0,1)] float musicDropLevel = .25f;
    public void LoadStartMenu()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        StartCoroutine(DelayGameStart());
    }
    IEnumerator DelayGameStart()
    {
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().volume = musicDropLevel;
        AudioSource.PlayClipAtPoint(gameStartSound, Camera.main.transform.position, gameStartSoundVolume);
        yield return new WaitForSeconds(gameStartDelay);
        FindObjectOfType<MusicPlayer>().DestroyMusicPlayer();
        SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOver());
    }

     IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void setMusicVolume()
    {
        this.GetComponent<AudioSource>().volume = musicDropLevel;
    }
}
