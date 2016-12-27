using UnityEngine;
using System.Collections;

// bu script sağlık puanı veren jetonlara bağlanır
public class HealthPickup : MonoBehaviour
{
	// nesnenin vereceği sağlık puanı
    public int healtToGive;

    private LevelManager theLevelManager;

    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }
		
    void OnTriggerEnter2D(Collider2D other)
    {
		// sağlık ekleme metodu LevelManager üzerinden çalışır
        theLevelManager.GiveHealth(healtToGive);
		// toplanan jetonu ekrandan yok et
        gameObject.SetActive(false);
    }
}