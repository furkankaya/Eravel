using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class StoryBookA : MonoBehaviour {

	public Text text;

	public Text buttonA;
	public Text buttonB;
	public Text buttonC;

	private enum States {
		girisA, depo, tabelaA, anakapiA, girisB, tabelaB, anakapiB, koridor 
	};
	private States myState;

	public string levelToLoad;		// bu kısım tamamlandığında yüklenecek bölüm !!! editör üzerinden yazılmalıdır

	void Start () {
		myState = States.girisA;
	}
		
	void Update () {
		print (myState);
		if 		(myState == States.girisA) 		{girisA();}
		else if (myState == States.tabelaA) 	{tabelaA();}
		else if (myState == States.tabelaB) 	{tabelaB();}
		else if (myState == States.anakapiA) 	{anakapiA();}
		else if (myState == States.anakapiB) 	{anakapiB();}
		else if (myState == States.depo) 		{depo();}
		else if (myState == States.girisB) 		{girisB();}
		else if (myState == States.koridor) 	{koridor();}
	}
		
	void girisA () {
		text.text = 
			"Eravel giriş kapısına yaklaşıp etrafına bakındı. " +
			"Robotlar sırayla ilerleyip ana kapıdan içeri giriyorlardı. " +
			"Kapının etrafındaki cihazlar, sıranın en önündeki robotu tarayıp bir tür giriş izni veriyor gibiydi. " +
			"Kapı her seferinde yalnızca bir tane robotun geçebileceği kadar açık kalıyor, ardından kapanıyordu. " +
			"Duvarda üzerinde yazılar ve işaretler olan bir tabela asılıydı. " +
			"Yan tarafta ise tahtadan, eski görünümlü bir kapı vardı. ";
		
		buttonA.text = "TABELAYI İNCELE";
		buttonB.text = "ANA KAPIDAN İÇERİ GİR";
		buttonC.text = "TAHTA KAPIDAN İÇERİ GİR";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.tabelaA;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.anakapiA;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.depo;
	}

	void depo() {
		text.text = 
			"Tahta kapının ardında tozlu, ufak bir oda vardı. " +
			"Odada pek çok metal kutu, demir parçaları ve değişik aletler bulunuyordu. " +
			"Fakat Eravel'in dikkatini çeken şey, odanın köşesinde çürümeye terk edilmiş robot parçaları oldu. " +
			"Bu parçaları kullanarak kendine robot süsü verebilirdi. ";

		buttonA.text = "ROBOT KILIĞINA GİR";
		buttonB.text = " ";
		buttonC.text = "GERİ DÖN";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.girisB;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.girisA;
	}

	void girisB() {
		text.text = 
			"Eravel robot parçalarını kullanarak kılık değiştirmiş halde girişe geri döndü. " +
			"Tabela halen duvarda asılıydı. " +
			"Robotlar ise ana kapıdan içeri girmeye devam ediyorlardı. ";

		buttonA.text = "TABELAYI İNCELE";
		buttonB.text = " ";
		buttonC.text = "ANA KAPIYA YÖNEL";

		if (CrossPlatformInputManager.GetButtonDown("ButtonA"))
			myState = States.tabelaB;
		else if (CrossPlatformInputManager.GetButtonDown("ButtonC"))
			myState = States.anakapiB;
	}

	void tabelaA () {
		text.text =
			"Duvarda asılı olan şey, bir tür uyarı levhasıydı. " +
			"Eravel üzerinde yazanları okudu: " +
			"\"Benimle işi olanlar robotlarım vasıtasıyla isteklerini iletebilirler. " +
			"Bu kapı sadece robotlarımın kullanımı içindir ve başkaları tarafından kullanılması yasaktır. " +
			"Kapıdaki güvenlik önlemleri robotlarım haricinde kimseye izin vermezler. " +
			" - ROBO-MEKANiK USTASI BUO\"";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.girisA;
	}

	void tabelaB() {
		text.text =
			"Duvarda asılı olan şey, bir tür uyarı levhasıydı. " +
			"Eravel üzerinde yazanları okudu: " +
			"\"Benimle işi olanlar robotlarım vasıtasıyla isteklerini iletebilirler. " +
			"Bu kapı sadece robotlarımın kullanımı içindir ve başkaları tarafından kullanılması yasaktır. " +
			"Kapıdaki güvenlik önlemleri robotlarım haricinde kimseye izin vermezler. " +
			" - ROBO-MEKANiK USTASI BUO\"";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.girisB;
	}

	void anakapiA() {
		text.text =
			"Eravel robotların yanından ilerleyip kapının önüne geldi. " +
			"Şansını deneyip kapıyı iteklese de bunun işe yaramayacağını biliyordu. " +
			"O sırada kapının etrafındaki tarama cihazlarından çıkan ışık demetleri gözünü aldı. " +
			"Kırmızı bir ışık yanıp sönmeye başlarken, mekanik bir ses duyuldu: \"GİRİŞ ONAYLANMADI!\". ";

		buttonA.text = " ";
		buttonB.text = "GİRİŞE GERİ DÖN";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.girisA;
	}

	void anakapiB() {
		text.text = 
			"Eravel, robotlardan oluşan sıranın en arkasına yanaşıp beklemeye koyuldu. " +
			"Sıranın önündeki robotlar kapıdan girdikçe, diğer robotlarla birlikte o da ilerliyordu. " +
			"Robotların sahibi olan Buo'nun, kendisine nasıl bir tepki vereceğini düşünerek endişelenmekteydi. " +
			"\"GİRİŞ ONAYLANDI!\" sesini duyup kendine geldiğinde, önündeki robot da kapıdan geçmekteydi. " +
			"Sıra Eravel'e gelmişti. İlerlemesi gerekiyordu. " ;
		
		buttonA.text = " ";
		buttonB.text = "BİR ADIM İLERLE";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			myState = States.koridor;
	}

	void koridor() {
		text.text =
			"Robot parçalarının altında etrafını bile zar zor görebilen Eravel, kapıya ait tarama cihazlarının hemen önündeydi. " +
			"\"GİRİŞ ONAYLANDI!\" " +
			"Kapı açılır açılmaz içeri fırlayan Eravel, robotların oluşturduğu sıradan ayrılıp üzerindeki parçaları bir kenara bıraktı. " +
			"Metal kaplamalı koridorlarda ilerlemeye başlayıp, Buo'yu aramaya koyuldu. ";

		buttonA.text = " ";
		buttonB.text = "BÖLÜMÜ SONLANDIR";
		buttonC.text = " ";

		if (CrossPlatformInputManager.GetButtonDown("ButtonB"))
			SceneManager.LoadScene (levelToLoad);
	}
}