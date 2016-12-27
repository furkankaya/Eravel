using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// bu script bölüm sonunu işaret eden nesneye eklenir, yani bölüm tamamlandığında çalışır
public class LevelEnd : MonoBehaviour
{

    public string levelToLoad;				// açılacak bölüm
    public string levelToUnlock;			// kilidi açılacak bölüm

    private PlayerController thePlayer;		//
    private CameraController theCamera;		//
    private LevelManager theLevelManager;	// referans değişkenleri

    public float waitToMove;				// player'ın bölüm sonu nesnesine gelince kaç saniye bekleyeceği
    public float waitToLoad;				// waitToMove'dan sonra, sıradaki bölümün açılması için kaç sene bekleyeceği

    private bool movePlayer;				// player hareket etsin mi etmesin mi

    public Sprite flagOpen;					// nesnenin geçildiğinde alacağı hali tutan sprite		

    private SpriteRenderer theSpriteRenderer;

	void Start ()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraController>();
        theLevelManager = FindObjectOfType<LevelManager>();

        theSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
		// movePlayer aktif olduğunda player'ı ekranın sağına doğru gönder
	    if(movePlayer)
        {
            thePlayer.myRigidbody.velocity = new Vector3(thePlayer.moveSpeed, thePlayer.myRigidbody.velocity.y, 0f);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
			// nesnenin görünümünü güncelle
            theSpriteRenderer.sprite = flagOpen;

			// bölüm bitirme corouitine'ini çalıştır
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
		// oyuncu hareket edemez
        thePlayer.canMove = false;
		// kamera oyuncuyu takip etmez
        theCamera.followTarget = false;
		// oyuncu zarar göremez
        theLevelManager.invincible = true;

		// müzik durur
        theLevelManager.levelMusic.Stop();
		// bölüm bitirme müziği oynatılır
        theLevelManager.gameOverMusic.Play();

		// oyuncunun hızı sıfırlanır
        thePlayer.myRigidbody.velocity = Vector3.zero;

		// toplanan altınları altın cüzdanına ekle
		PlayerPrefs.SetInt("CoinWallet", PlayerPrefs.GetInt("CoinWallet") + theLevelManager.coinCount);

		// kilidi açılacak bölüm neyse kilidini aç
        PlayerPrefs.SetInt(levelToUnlock, 1);

		// bekle
        yield return new WaitForSeconds(waitToMove);

		// movePlayer'ı true yap (bu, update içinde oyuncunun sağa yönlendirilmesini sağlayan kodu çalıştırır)
        movePlayer = true;

		// sıradaki bölümün yüklenmesinden önce waitToLoad kadar bekle
        yield return new WaitForSeconds(waitToLoad);

		// sıradaki bölümü yükle
        SceneManager.LoadScene(levelToLoad);
    }
}
