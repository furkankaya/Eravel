using UnityEngine;
using System.Collections;

// bu script checkpoint görevi görecek nesnelere bağlanır. geçilmeden önce ve sonrası için iki farklı script gerekir
public class CheckpointController : MonoBehaviour {

    public Sprite flagClosed;					// geçildikten sonraki sprite
    public Sprite flagOpen;						// geçilmeden önceki sprite

    private SpriteRenderer mySpriteRenderer;	// nesnenin sprite'ını değiştirebilmek için referans

    public bool checkpointActive;				// checkpoint'in geçilip geçilmediğine dair değişken

	void Start ()
	{
        mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other.tag == "Player")
		{
			// aktif durumdaki sprite'a geç
            mySpriteRenderer.sprite = flagOpen;
			// durumu aktif olarak değiştir
            checkpointActive = true;
        }
    }
}
