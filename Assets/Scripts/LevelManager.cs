using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// oyunun merkezi modülü. pek çok görevi var.
public class LevelManager : MonoBehaviour
{

    public float waitToRespawn;					// respawn olmadan beklenecek süre
    public PlayerController thePlayer;			// PlayerController'a referans değişkeni

    public GameObject deathSplosion;			// sağlık sıfırlandığında veya düştüğünde oynatılacak animasyon

    public int coinCount;						// o anki altın sayısı
    private int coinBonusLifeCount;				// aşağıdaki değişkenin sayacı
    public int bonusLifeThreshold;				// kaç altın 1 ışınlanma hakkı versin

    public AudioSource coinSound;				// altın alındığında çalacak ses

    public Text coinText;						// arayüzde altın sayısını gösteren eleman

    public Image heart1;						//
    public Image heart2;						//
	public Image heart3;						// arayüzde sağlık ikonları

    public Sprite heartFull;					//
    public Sprite heartHalf;					//
    public Sprite heartEmpty;					// ikonlara verilecek sprite'lar

    public int maxHealth;						// maksimum sağlık puanı
    public int healthCount;						// sağlık puanının anlık değeri

    private bool respawning;					// o an player'ın respawn olup olmadığı

    public ResetOnRespawn[] objectsToReset;		// respawn'da resetlenecek nesneleri tutacak dizi

	public bool invincible;						// sağlık puanının azalmaması durumu (peşpeşe hamle yememek için)

    public Text livesText;						// ışınlanma sayısı arayüz yazısı
    public int currentLives;					// o anki ışınlanma sayısı sayacı

    public GameObject gameOverScreen;			// game over'da çıkacak ekran

    public AudioSource levelMusic;				// 
    public AudioSource gameOverMusic;			// bölümde çalınacak ses ve müzikler

	[HideInInspector]
	public bool respawnCoActive;				// boss dövüşünde kullanılan değişken, respawn işleminde olup olunmadığını tutuyor


    void Start ()
    {
		// oyuncu referansını doldur
        thePlayer = FindObjectOfType<PlayerController>();

		// respawn'da resetlenmesi istenen nesneleri bul (ilgili script'e sahip olanları)
        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

		// sağlık puanını tam yap
        healthCount = maxHealth;

		// bölüm altınını sıfırla
		coinCount = 0;
     
		// altın sayısını ekrana yaz
        coinText.text = "X " + coinCount;

		// dosyadan ışınlanma sayısını oku
        currentLives = PlayerPrefs.GetInt("LifeWallet");

        // ışınlanma sayısını ekrana yaz
        livesText.text = "X " + currentLives;

    }

	void Update ()
    {
		// sağlık 0 veya altına düştüyse ve o an zaten respawn'da değilse respawn işlemini başlat
	    if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }

		// ekstra ışınlanma hakkı sayacı doldukça yeni hak ekle, arayüzde ilgili yeri güncelle
        if(coinBonusLifeCount >= bonusLifeThreshold)
        {
            currentLives += 1;
			PlayerPrefs.SetInt ("LifeWallet", currentLives);
            livesText.text = "X " + currentLives;
            coinBonusLifeCount -= bonusLifeThreshold;
        }
	}

	// respawn 
    public void Respawn()
    {
        currentLives -= 1;
		PlayerPrefs.SetInt ("LifeWallet", currentLives);
        
        if(currentLives>=0)
        { 
			livesText.text = "X " + currentLives;
            StartCoroutine("RespawnCo");
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameOverMusic.Play();
			currentLives = 0;
			PlayerPrefs.SetInt ("LifeWallet", currentLives);
        }
    }

    public IEnumerator RespawnCo()
    {
		// respawn işleminde olduğunu bildrmek için true yap
		respawnCoActive = true;

        thePlayer.gameObject.SetActive(false);

        Instantiate(deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);

        yield return new WaitForSeconds(waitToRespawn);

		// respawn işleminin bittiğini bildrmek için false yap
		respawnCoActive = false;

        healthCount = maxHealth;
        respawning = false;
        UpdateHeartMeter();

		// bölüm altınını 25 azalt (negatif olmamasına dikkat et)
        coinCount -= 25;
		if (coinCount < 0)
		{
			coinCount = 0;
		}

		// bonus ışınlanma verecek altın sayacını 25 azalt (negatif olmamasına dikkat et)
        coinBonusLifeCount -= 25;
		if (coinBonusLifeCount < 0)
		{
			coinBonusLifeCount = 0;
		}
		coinText.text = "X " + coinCount;

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);

        for(int i=0 ; i < objectsToReset.Length ; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }


	// altın ekleme (gerektiğinde çağrılır, örn: Coin.cs)
    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinBonusLifeCount += coinsToAdd;
        coinText.text = "X " + coinCount;
        coinSound.Play();
    }

	// oyuncuya zarar verme (gerektiğinde çağrılır, örn: HurtPlayer.cs)
    public void HurtPlayer(int damageToTake)
    {
        if(!invincible)
        { 
            healthCount -= damageToTake;
            UpdateHeartMeter();
            thePlayer.Knockback();
            thePlayer.hurtSound.Play();
        }
    }

	// sağlık puanı ekleme (gerektiğinde çağrılır, örn: HealthPickup.cs)
    public void GiveHealth(int healtToGive)
    {
        if(healthCount<maxHealth)
        { 
            healthCount += healtToGive;
			if (healthCount > maxHealth)
			{
				healthCount = maxHealth;
			}
        }
        coinSound.Play();
        UpdateHeartMeter();
    }

	// ışınlanma hakkı ekle (gerektiğinde çağrılır, örn: ExtraLife.cs)
    public void AddLives(int livesToAdd)
    {
        coinSound.Play();
        currentLives += livesToAdd;
		PlayerPrefs.SetInt ("LifeWallet", currentLives);
        livesText.text = "X " + currentLives;
    }

	// arayüzde kalplerin durumunu güncelleyebilen fonksiyon (can değiştikçe çağırılır)
    public void UpdateHeartMeter()
    {
        switch (healthCount)
        {
            case 6:
                heart3.sprite = heartFull;
                heart2.sprite = heartFull;
                heart1.sprite = heartFull;
                return;
            case 5:
                heart3.sprite = heartHalf;
                heart2.sprite = heartFull;
                heart1.sprite = heartFull;
                return;
            case 4:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartFull;
                heart1.sprite = heartFull;
                return;
            case 3:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartHalf;
                heart1.sprite = heartFull;
                return;
            case 2:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart1.sprite = heartFull;
                return;
            case 1:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart1.sprite = heartHalf;
                return;
            case 0:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart1.sprite = heartEmpty;
                return;

            default:
                heart3.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart1.sprite = heartEmpty;
                return;
        }
    }

}
