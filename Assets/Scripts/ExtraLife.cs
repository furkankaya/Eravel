using UnityEngine;
using System.Collections;

// ekstra ışınlanma hakkı veren toplanabilir kapsüller bu scripte bağlanır
public class ExtraLife : MonoBehaviour {

    public int livesToGive;					// kaç ışınlanma hakkı vereceği

    private LevelManager theLevelManager;	// referans ataması için

	void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
		
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
			// player'a ışınlanma hakkı ekle
            theLevelManager.AddLives(livesToGive);
			// alınan kapsülü yok et
            gameObject.SetActive(false);
        }
    }
}
