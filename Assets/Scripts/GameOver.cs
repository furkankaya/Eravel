using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// bu script hem sağlık hem ışınlanma hakları bittiğinde belirecek menüye ait fonksiyonları içerir.
// bu fonksiyonları çağıran butonlar ve çağırma işlemleri editör üzerinden düzenlenir.
public class GameOver : MonoBehaviour
{

    public string mainMenu;
    public string levelSelect;

    private LevelManager theLevelManager;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

	// bölümü baştan başlat
    public void Restart()
    {
        // PlayerPrefs.SetInt("CoinCount", 0);
        // PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	// bölüm seçim ekranına dön
    public void LevelSelect()
    {
        // PlayerPrefs.SetInt("CoinCount", 0);
        // PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(levelSelect);
    }

	// ana menüye dön
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
