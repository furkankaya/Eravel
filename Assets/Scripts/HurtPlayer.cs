using UnityEngine;
using System.Collections;

// bu script oyuncu sağlık puanını düşürecek nesnelere bağlanır
public class HurtPlayer : MonoBehaviour
{
	private LevelManager theLevelManager;

	// nesnenin oyuncudan düşüreceği sağlık puanı ( arayüzdeki 1 kalp == 2 sağlık puanı)
    public int damageToGive;

	void Start ()
	{
		theLevelManager = FindObjectOfType<LevelManager>();
	}
		
	void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {
            // oyuncuya zarar verme fonksiyonu LevelManager üzerinden çalışır
            theLevelManager.HurtPlayer(damageToGive);
        }

	}
}
