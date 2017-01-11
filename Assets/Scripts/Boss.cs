using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {


	private bool bossActive;			// oyuncu mücadeleyi başlatacak collider'dan geçtiğinde aktif olur

	public float timeBetweenDrops;		// havadan düşman düşürme olayları arasındaki zaman (her iterasyonda 2 kat azalır, daha çok düşman düşer)
	private float timeBetwwenDropsStore;// yukarıdaki değişkenin programlamada kullanılmayacak sabit hali
	private float dropCount;			// yukarıdaki değişkenin programlama içinde değişerek kullanılacak hali

    public float waitForPlatforms;		// platformların ekranda kalma süresi
	private float platformCount;		// yukarıdaki değişkenin programlama içinde değişerek kullanılacak hali

    public Transform leftPoint;			// boss alanının sol noktası
    public Transform rightPoint;		// boss alanının sağ noktası
    public Transform dropSawSpawnPoint; // havadan düşman atılacak nokta

    public GameObject dropSaw;			// havadan bırakılacak düşmanın nesnesi

    public GameObject theBoss;			// boss nesnesi

    private bool bossRight;				// boss'un pozisyonunu bağlayan boolean değişken

    public GameObject rightPlatforms;	// boss sağdayken belirecek platformlar
    public GameObject leftPlatforms;	// boss soldayken belirecek platformlar

	public GameObject rightHolder;		// boss'u havada tutacak platformlar
	public GameObject leftHolder;		// boss'u havada tutacak platformlar

	[HideInInspector]
	public bool takeDamage;				// düşmana vurulduğunda zarar alma durumu

	public int startingHealth;			// boss'un başlangıçtaki sağlık puanı
	private int currentHealth;			// yukarıdaki değişkenin programlama içinde değişerek kullanılacak hali

	private CameraController theCamera;	// kamera script'ine erişmeye yarayacak referans

	private LevelManager theLevelManager;	// respawn işleminde olup olmadığını LevelManager script'ten öğrenmek için referans

	public bool waitingForRespawn;

	void Start ()
    {
		timeBetwwenDropsStore = timeBetweenDrops;
        dropCount = timeBetweenDrops;
        platformCount = waitForPlatforms;
		currentHealth = startingHealth;

		theCamera = FindObjectOfType<CameraController> ();

		// boss'u sağda başlat
        theBoss.transform.position = rightPoint.position;
        bossRight = true;

		theLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update ()
    {
		if (theLevelManager.respawnCoActive)
		{
			bossActive = false;
			waitingForRespawn = true;
		}

		// artık respawn için beklenmiyorsa, boss savaşını yok et, yeniden başlamaya hazır hale getir
		if (waitingForRespawn && !theLevelManager.respawnCoActive)
		{
			theBoss.SetActive (false);
			leftPlatforms.SetActive (false);
			rightPlatforms.SetActive (false);

			timeBetweenDrops = timeBetwwenDropsStore;

			platformCount = waitForPlatforms;
			dropCount = timeBetweenDrops;

			theBoss.transform.position = rightPoint.position;

			currentHealth = startingHealth;

			theCamera.followTarget = true;

			waitingForRespawn = false;
		}


		// kullanıcı alana girdiyse
	    if(bossActive)
        {
			//theCamera.followTarget = false;

			// kamerayı ortalayacak pozisyonu bul
			Vector3 middlePosition = new Vector3( (leftPoint.transform.position.x + rightPoint.transform.position.x)/2, theCamera.transform.position.y, theCamera.transform.position.z);
			// kamerayı bu noktaya ortala
			theCamera.transform.position = Vector3.Lerp (theCamera.transform.position, middlePosition, theCamera.smoothing * Time.deltaTime);

			// boss'u aktifleştir
            theBoss.SetActive(true);

			//

			// dropCount 0 olana dek her saniye bir azalt
            if(dropCount > 0)
            {
                dropCount -= Time.deltaTime;
            }
			// dropCount 0 olduğunda, düşmanları bırakmak için random yeni bir nokta belirle. bu nokta leftPoin ve rightPoint arasında olsun
            else
            {
				// düşmanları bırakacak nokta'nın X'i her seferinde random olarak değişsin
                dropSawSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropSawSpawnPoint.position.y, dropSawSpawnPoint.position.z);
				// verilen position ve rotation'u dikkate alarak, istenen nesneyi instantiate et
                Instantiate(dropSaw, dropSawSpawnPoint.position, dropSawSpawnPoint.rotation);
				// dropCount şu anda 0, ilk haline döndür
                dropCount = timeBetweenDrops;
            }

			// boss sağdaysa
            if(bossRight)
            {
				// boss'u havada tutacak platformu oluştur
				rightHolder.SetActive (true);

				// platformların havada kalma zamanını azalt, platformlar yoksa yarat
                if(platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    rightPlatforms.SetActive(true);
                }
            }
			//boss soldaysa
            else
            {
				// boss'u havada tutacak platformu oluştur
				leftHolder.SetActive (true);

				// platformların havada kalma zamanını azalt, platformlar yoksa yarat
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    leftPlatforms.SetActive(true);
                }
            }

			// boss zarar görme durumundaysa
			if (takeDamage) 
			{
				// sağlığını bir puan düşür
				currentHealth -= 1;

				if (currentHealth <= 0)
				{
					// levelExit.SetActive (true);		// levelExit'için tasarlanan bir kısım bu kod ile aktifleşir ve bölümden çıkılabilir
					theCamera.followTarget = true;
					// boss savaşı bittiği için boss sistemini durdur
					gameObject.SetActive (false);
				}

				// sağdaysa sola ışınla
				if (bossRight)
				{
					theBoss.transform.position = leftPoint.position;
				}
				// soldaysa sağa ışınla
				else
				{
					theBoss.transform.position = rightPoint.position;
				}

				// sağ-solda bulunma durumunu tersini al
				bossRight = !bossRight;

				// boss zarar gördüğü anda onu havada tutan platformları kaldır
				leftHolder.SetActive (false);
				rightHolder.SetActive (false);

				// platformları yok et
				rightPlatforms.SetActive (false);
				leftPlatforms.SetActive (false);

				// platformların ışınlanma zaman sayacını sıfırla
				platformCount = waitForPlatforms;

				// düşman düşme hızını iki kat artır
				timeBetweenDrops /= 2f;

				// zarar verme modunu kapat
				takeDamage = false;		
			}
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		// oyuncu alana girdiğinde savaşı aktifleştir
        if(other.tag == "Player")
        {
            bossActive = true;
        }
    }
}
