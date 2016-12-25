using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// bu script oyun duraklatıldığında belirecek menüye ait fonksiyonları içerir.
// bu fonksiyonları çağıran butonlar ve çağırma işlemleri editör üzerinden düzenlenir.
public class PauseScreen : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;

    private LevelManager theLevelManager;
    public GameObject thePauseScreen;
    private PlayerController thePlayer;

	void Start ()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			Debug.Log ("esc pressed");
            if(Time.timeScale == 0f)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    public void PauseGame()
    {
        Time.timeScale = 0f;
        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
        theLevelManager.levelMusic.Pause();
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1f;
        thePlayer.canMove = true;
        theLevelManager.levelMusic.Play();
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("CoinCount", theLevelManager.coinCount);

        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }


}
