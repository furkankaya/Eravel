using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class StoryBookB : MonoBehaviour {

	public Text text;

	public Text buttonA;
	public Text buttonB;
	public Text buttonC;

	private enum States
	{
		koridor1A, oda1A, oda1B, oda2A, koridor1B, koridor2A, koridor2B, isik, masa, koridor3A
	};
	private States myState;

	public string levelToLoad;		// bu kısım tamamlandığında yüklenecek bölüm !!! editör üzerinden yazılmalıdır
	public string levelToUnlock;			// kilidi açılacak bölüm !!! editör üzerinden yazılmalıdır

	void Start () {
		myState = States.koridor1A;
	}
		
	void Update () {
		print (myState);
		if 		(myState == States.koridor1A) 		{koridor1A();}
		else if (myState == States.oda1A) 			{oda1A();}
		else if (myState == States.oda1B) 			{oda1B();}
		else if (myState == States.oda2A) 			{oda2A();}
		else if (myState == States.koridor1B) 		{koridor1B();}
		else if (myState == States.koridor2A) 		{koridor2A();}
		else if (myState == States.koridor2B) 		{koridor2B();}
		else if (myState == States.koridor3A) 		{koridor3A();}
		else if (myState == States.isik) 			{isik();}
		else if (myState == States.masa) 			{masa();}
	}

	void koridor1A () {
		text.text = 
			"Büyücü Gizmos'un malikanesi ahşap döşememelere ve taştan duvarlara sahipti. " +
			"Duvarlardaki sıra sıra raflarda birbirinden garip cisimler, kavanozlar ve şişeler vardı. " +
			"Eravel, böyle bir yeri daha önce hiç görmediğinden meraklı gözleri bir o yana bir bu yana dönüyordu. " +
			"Düz devam eden ana koridorun solunda ve sağında birer kapı vardı. ";

		buttonA.text = "SOLDAKİ KAPIDAN GİR";
		buttonB.text = "KORİDORDA İLERLE";
		buttonC.text = "SAĞDAKİ KAPIDAN GİR";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.oda1A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor2A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.oda2A;
	}

	void oda1A () {
		text.text = 
			"Odaya girdiği anda yükselen hayvan seslerinden korkan Eravel, odanın onlarca kafesle dolu olduğunu fark etti. " +
			"Büyücü Gizmos, çeşit çeşit canlıyı bu odadaki kafeslere ve kutulara hapsetmişti. " +
			"Eravel, hepsini serbest bırakmak istese de her bir hayvan normalden çok daha saldırgan davranıyordu. " +
			"Tıpkı dışarda da karşılaştığı canlılar gibi. " +
			"Eravel duvara dayalı duran bir çalışma masası üzerinde bazı kağıtlar gördü. ";

		buttonA.text = " ";
		buttonB.text = "KAĞITLARI İNCELE";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.oda1B;

	}

	void oda1B () {
		text.text = 
			"BEKLEDİĞİM ETKİ ELBETTE BU DEĞİLDİ FAKAT BAŞLANGIÇ İÇİN BU DA ÖNEMLİ BİR ADIM. " +
			"ZİHİN TAŞI, HAYVANLARIN ZİHİNLERİ ÜZERİNDE KONTROL KAZANMAMI SAĞLAMASA DA ONLARI ANORMAL DERECEDE SALDIRGANLAŞTIRDI. " +
			"BU DA ONLARI ETKİLEDİĞİNİN GÖSTERGESİ. " +
			"TAŞIN ETKİSİ BURAYI AŞIP DIŞARIDAKİ HAYVANLARA DA ULAŞIYOR, DAHA SONRA TAŞIN KONTROLÜ KONUSUNDA DA ARAŞTIRMALAR YAPMALIYIM. " +
			"DENEMELERİM SÜRECEK. SONRAKİ AŞAMA, İNSALARDAKİ ETKİLERİ. ";

		buttonA.text = " ";
		buttonB.text = "KORİDORA GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor1B;

	}

	void oda2A () {
		text.text = 
			"Eravel'in girdiği odanın her yanı, garip sıvılar içeren şişelerle doluydu. " +
			"Odada yabancı ve ağır bir koku vardı. " +
			"Ne olduğunu bilmediği bu şeylerden oldukça korkan Eravel, odayı bir an önce terk etme isteğiyle doldu. ";

		buttonA.text = " ";
		buttonB.text = "KORİDORA GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor1B;

	}

	void koridor1B () {
		text.text = 
			"Eravel, ahşap döşemeli ve taş duvarlı ana koridora tekrar çıktı. " +
			"Düz devam eden ana koridorun solunda ve sağında birer kapı vardı. ";

		buttonA.text = "SOLDAKİ KAPIDAN GİR";
		buttonB.text = "KORİDORDA İLERLE";
		buttonC.text = "SAĞDAKİ KAPIDAN GİR";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.oda1A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor2A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.oda2A;
	}

	void koridor2A () {
		text.text = 
			"Eravel, yüksek tavanlı ve çok geniş bir odaya ulaştı. " +
			"Odanın yarı karanlık olması, ileride yanıp sönen bir ışığın dikkat çekmesini sağlıyordu. " +
			"Ortada yer alan basamakların sonunda büyük bir kapı görünüyordu. " +
			"Odanın sağında ise yine bir çalışma masası bulunuyordu. ";

		buttonA.text = "IŞIĞIN KAYNAĞINI İNCELE";
		buttonB.text = "MERDİVENLERDEN ÇIK";
		buttonC.text = "ÇALIŞMA MASASINI İNCELE";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.isik;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor3A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.masa;
	}

	void isik () {
		text.text = 
			"Eravel PEMBE'NİN bileğinden hiç ayırmadığı atron cihazını burada gördüğüne çok şaşırdı. " +
			"Atron cihazları, Atuan gezegeninin sakinleri tarafından zaman takibi amacıyla kullanılmış cihazlardı. " +
			"Artık kullanılmayan eski cihazlar olmalarına rağmen, PEMBE'nin atronlara olan ilgisini bilmeyen yoktu. " +
			"Eravel, arkadaşlarının da burada bulunmuş olduğundan artık emindi. ";

		buttonA.text = " ";
		buttonB.text = "ODANIN ORTASINA DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor2B;
	}

	void masa () {
		text.text = 
			"Çalışma masasındaki günlüğe benzer defterin sayfalarını karıştıran Eravel, en son yazılmış sayfayı okudu: " +
			"\"ZİHİN TAŞI'NI ANLAMAMDA BANA YARDIM EDECEK AMA ÖTEKİLERİ BURADAN GÖNDERMEK İSTEMİYOR. " +
			"BURADA GÜVENDE OLACAKLARINA İNANIYOR OLMALI." +
			"BUNU BİR FIRSAT OLARAK DEĞERLENDİRİP TAŞI ONLARIN ÜZERİNDE DE DENEYEBİLİRİM." +
			"BÖYLECE ONLARDAN KURTULMUŞ DA OLACAĞIM.\"\n" +
			"Eravel yazıda neden bahsedildiğini merak ederek arkasını döndü." ;

		buttonA.text = " ";
		buttonB.text = "ODANIN ORTASINA DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor2B;
	}

	void koridor2B () {
		text.text = 
			"Eravel, geniş odanın merkezine döndü. " +
			"Odanın yarı karanlık olması, ileride yanıp sönen bir ışığın dikkat çekmesini sağlıyordu. " +
			"Ortada yer alan basamakların sonunda büyük bir kapı görünüyordu. " +
			"Odanın sağında ise yine bir çalışma masası bulunuyordu. ";

		buttonA.text = "IŞIĞIN KAYNAĞINI İNCELE";
		buttonB.text = "MERDİVENLERDEN ÇIK";
		buttonC.text = "ÇALIŞMA MASASINI İNCELE";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.isik;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor3A;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.masa;
	}

	void koridor3A () {
		text.text = 
			"Merdivenleri çıkıp, büyük kapıyı açan Eravel dikkatlice odaya girdi." +
			"Eravel de odanın içindeki cübbeli yaşlı adam da birbirlerine bakar halde donakaldılar. ";

		buttonA.text = " ";
		buttonB.text = "BÖLÜMÜ SONLANDIR";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown ("ButtonB")) {
			PlayerPrefs.SetInt(levelToUnlock, 1);
			SceneManager.LoadScene (levelToLoad);
		}
	}

}