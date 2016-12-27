using UnityEngine;
using System.Collections;

//
public class Coin : MonoBehaviour {

    public LevelManager theLevelManager;	// referans atanacak

	public int coinValue;					// nesnenin altın değeri

	void Start ()
	{
        theLevelManager = FindObjectOfType<LevelManager>();
	}
		
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			// bu nesnenin coinValue değeri kadar, kullanıcıya altın ekle
            theLevelManager.AddCoins(coinValue);
			// nesne destroy edilmez, deaktif edilir. böylece tekrar aktif hale getirilebilir
            gameObject.SetActive(false);
        }
    }
}
