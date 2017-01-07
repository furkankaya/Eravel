using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

// bu script bölüm seçim ekranındaki kapılara bağlanır ve bölümlere gidiş sağlar
public class LevelDoor : MonoBehaviour
{

    public string levelToLoad;			// kapının ait olduğu bölüm

	//[HideInInspector]
    public bool unlocked;				// bölümün açık olup olmadığı

    public Sprite doorBottomOpen;		//
    public Sprite doorTopOpen;			//
    public Sprite doorBottomClosed;		//
    public Sprite doorTopClosed;		// kapının açık ve kapalı hallerine ait alt-üst sprite'lar

    public SpriteRenderer doorTop;		//
    public SpriteRenderer doorBottom;	// sprite'ların bağlanacağı alt-üst renderer'lar

	public GameObject unlockDoorButton;	// kapı kilidi açma butonu (editörden ata)
	public GameObject enterDoorButton;	// kapıdan girme butonu (editörden ata)

	private bool canLoadLevel;			// level yüklebilecek durumda olup olmadığı
	private bool canUnlockLevel;		// level unlock edebilecek durumda olup olmadığı

	public int levelValue;				// bölümü açmak için kaç altın gerektiği

	void Start ()
	{
		// Level01 her zaman açık
        PlayerPrefs.SetInt("Level01", 1);
		PlayerPrefs.SetInt("LevelA", 1);

		// kapının ait olduğu level'in açık olup olmadığı PlayerPrefs'ten okunur
        if(PlayerPrefs.GetInt(levelToLoad) == 1)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
			
		// bölümün kilitli olup olmamasına göre kapının açık/kapalı görünümünü değiştir
        if(unlocked)
        {
            doorTop.sprite = doorTopOpen;
            doorBottom.sprite = doorBottomOpen;
        }
        else
        {
            doorTop.sprite = doorTopClosed;
            doorBottom.sprite = doorBottomClosed;
        }

		// loadLevel durumunu 0 yap, kapılara gidilirse 1 olur
		canLoadLevel = false; 
		canUnlockLevel = false;
			
	}

	void Update()
	{
		// bölüme gidebilir durumdaysa ve enter tuşuna basılırsa bölümü yükle
		if (canLoadLevel)
		{
			if (CrossPlatformInputManager.GetButtonDown ("EnterDoor"))
			{
				SceneManager.LoadScene (levelToLoad);
			}
		}

		// bölüm kilidi açılabilir durumdaysa ve unlock tuşuna basılırsa bölüm açma diyalogu göster
		if (canUnlockLevel)
		{
			if ( CrossPlatformInputManager.GetButtonDown ("UnlockDoor") && PlayerPrefs.GetInt("CoinWallet")>levelValue )
			{
				unlocked = true;
				doorTop.sprite = doorTopOpen;
				doorBottom.sprite = doorBottomOpen;

				unlockDoorButton.SetActive (false);
				enterDoorButton.SetActive (true);
			}
		}



	}


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
			if (unlocked)
			{
				enterDoorButton.SetActive (true);
				canLoadLevel = true;
			}
			else
			{
				unlockDoorButton.SetActive (true);
				canUnlockLevel = true;
			}

        }
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			enterDoorButton.SetActive (false);
			unlockDoorButton.SetActive (false);
			canLoadLevel = false;
			canUnlockLevel = false;
		}
	}
}
