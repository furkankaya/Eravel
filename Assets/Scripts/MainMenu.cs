using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// bu script ana menüye ait fonksiyonları içerir.
// bu fonksiyonları çağıran butonlar ve çağırma işlemleri editör üzerinden düzenlenir.
// !! bölüm adları bu script'e editör üzerinden tek tek verilmelidir
public class MainMenu : MonoBehaviour {

    public string firstLevel;
    public string levelSelect;

    public string[] levelNames;

    public int startingLives;

	// yeni oyun kullanıcının tüm kaydını silip oyuna sıfırdan başlatır
    public void NewGame()
    {
		// ilk bölümü yükle
        SceneManager.LoadScene(firstLevel);

		// tüm bölümleri kilitle
        for(int i=0; i<levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }

		// kalıcı diğer değerleri resetle
        PlayerPrefs.SetInt("CoinWallet", 0);
        PlayerPrefs.SetInt("LifeWallet", startingLives);
    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
