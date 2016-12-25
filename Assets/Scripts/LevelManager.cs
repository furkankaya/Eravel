using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float waitToRespawn;
    public PlayerController thePlayer;

    public GameObject deathSplosion;

    public int coinCount;
    private int coinBonusLifeCount;
    public int bonusLifeThreshold;

    public AudioSource coinSound;

    public Text coinText;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    public int maxHealth;
    public int healthCount;

    private bool respawning;

    public ResetOnRespawn[] objectsToReset;

    public bool invincible;

    public Text livesText;
    public int startingLives;
    public int currentLives;

    public GameObject gameOverScreen;

    public AudioSource levelMusic;
    public AudioSource gameOverMusic;

	[HideInInspector]
	public bool respawnCoActive;				// boss dövüşünde kullanılan değişken, respawn işleminde olup olunmadığını tutuyor


    void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();



        objectsToReset = FindObjectsOfType<ResetOnRespawn>();

        healthCount = maxHealth;

        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
        
        coinText.text = "Coins: " + coinCount;

        if(PlayerPrefs.HasKey("PlayerLives"))
        {
            currentLives = PlayerPrefs.GetInt("PlayerLives");
        }
        else
        {
            currentLives = startingLives;
        }
        
        livesText.text = "Lives: " + currentLives;

    }

	void Update ()
    {
	    if (healthCount <= 0 && !respawning)
        {
            Respawn();
            respawning = true;
        }

        if(coinBonusLifeCount >= bonusLifeThreshold)
        {
            currentLives += 1;
            livesText.text = "Lives: " + currentLives;
            coinBonusLifeCount -= bonusLifeThreshold;
        }
	}

    public void Respawn()
    {
        currentLives -= 1;
        livesText.text = "x " + currentLives;

        if(currentLives>=0)
        { 
            StartCoroutine("RespawnCo");
        }
        else
        {
            thePlayer.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            levelMusic.Stop();
            gameOverMusic.Play();
			currentLives = 3;	///// !!!!!!!!!!! sabit 3 değeri verme
            //levelMusic.volume /= 2;
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

        coinCount = 0;
        coinText.text = "x " + coinCount;
        coinBonusLifeCount = 0;

        thePlayer.transform.position = thePlayer.respawnPosition;
        thePlayer.gameObject.SetActive(true);

        for(int i=0 ; i < objectsToReset.Length ; i++)
        {
            objectsToReset[i].gameObject.SetActive(true);
            objectsToReset[i].ResetObject();
        }
    }

    public void AddCoins(int coinsToAdd)
    {
        coinCount += coinsToAdd;
        coinBonusLifeCount += coinsToAdd;
        coinText.text = "Coins: " + coinCount;
        coinSound.Play();
    }

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

    public void GiveHealth(int healtToGive)
    {
        if(healthCount<maxHealth)
        { 
            healthCount += healtToGive;
        }
        coinSound.Play();
        UpdateHeartMeter();
    }

    public void AddLives(int livesToAdd)
    {
        coinSound.Play();
        currentLives += livesToAdd;
        livesText.text = "X " + currentLives;
    }

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
