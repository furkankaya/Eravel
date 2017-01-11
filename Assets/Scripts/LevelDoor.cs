using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

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

	public GameObject theDialogueScreen;// ekranda belirecek diyalog arayüzü !!! editör üzerinden atanır
	public Text theDialogueText;		// ekranda belirecek diyalogun yazı elemanı !!! editör üzerinden atanır

	private PlayerController thePlayer;	// diyalog sırasında oyuncu durdurulurken kullanılacak, otomatik atanır

	public bool playCutscene;			// bölüm başında cutscene oynayıp oynamayacağı
	public string cutsceneToPlay;		// oynatılacak cutscene bölüm adı


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

		// diyalog ekranında durdurma metodu çağrılacak
		thePlayer = FindObjectOfType<PlayerController>();
	}

	void Update()
	{
		// bölüme gidebilir durumdaysa ve enter tuşuna basılırsa bölümü (veya cutscene'ini) yükle
		if (canLoadLevel)
		{
			if (CrossPlatformInputManager.GetButtonDown ("EnterDoor"))
			{
				if (playCutscene){
					SceneManager.LoadScene (cutsceneToPlay);
				} else {
					SceneManager.LoadScene (levelToLoad);
				}
			}
		}

		// bölüm kilidi açılabilir durumdaysa ve unlock tuşuna basılırsa bölüm açma diyalogu göster
		if (canUnlockLevel && CrossPlatformInputManager.GetButtonDown ("UnlockDoor"))
		{
			Time.timeScale = 0f;
			theDialogueScreen.SetActive(true);
			thePlayer.canMove = false;
			theDialogueText.text = "BÖLÜMÜ " + levelValue.ToString() + " ALTIN KARŞILIĞINDA AÇMAK İSTİYOR MUSUN?";
		}

		if (canUnlockLevel && CrossPlatformInputManager.GetButtonDown ("DialogueYes"))
		{
			if (PlayerPrefs.GetInt ("CoinWallet") >= levelValue) {
				unlocked = true;
				doorTop.sprite = doorTopOpen;
				doorBottom.sprite = doorBottomOpen;

				unlockDoorButton.SetActive (false);
				enterDoorButton.SetActive (true);
			}

			Time.timeScale = 1f;
			theDialogueScreen.SetActive(false);
			//theDialogueScreen.transform.parent.gameObject.SetActive(true);
			thePlayer.canMove = true;
		}

		if (CrossPlatformInputManager.GetButtonDown ("DialogueNo"))
		{
			Time.timeScale = 1f;
			theDialogueScreen.SetActive(false);
			thePlayer.canMove = true;
		}

	}
		
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
			if (unlocked)
			{
				enterDoorButton.SetActive (true);
				unlockDoorButton.SetActive (false);
				canLoadLevel = true;
			}
			else
			{
				enterDoorButton.SetActive (false);
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
