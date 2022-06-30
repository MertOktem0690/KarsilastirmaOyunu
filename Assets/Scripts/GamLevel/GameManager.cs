using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject puanSurePaneli;

    [SerializeField]
    private GameObject pausePaneli,sonucPaneli;

    [SerializeField]
    private GameObject PuaniKapYazisi,BuyukSayiyiSecYazisi;

    [SerializeField]
    private GameObject ustDikdortgen, altDikdortgen;

    [SerializeField]
    private Text ustText,altText,skorText;

    TimerManager timerManager;

    DairelerManager dairelerManager;

    TrueFalseManager trueFalseManager;

    SonucManager sonucManager;

    int oyunSayaci, kacinciOyun;

    int ustDeger, altDeger;

    int buyukDeger;

    int butonDegeri;

    int toplamPuan, artisPuani;

    int dogruAdet, yanlisAdet;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip baslangicSesi,dogruSesi,yanlisSesi,bitisSesi;

    private void Awake ( )
    {
        timerManager = Object.FindObjectOfType<TimerManager>();

        dairelerManager = Object.FindObjectOfType<DairelerManager>();

        trueFalseManager = Object.FindObjectOfType<TrueFalseManager>();

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        kacinciOyun = 0;

        oyunSayaci = 0;

        toplamPuan = 0;

        ustText.text = "";

        altText.text = "";

        skorText.text = "";

        SahneEkraniniGuncelle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SahneEkraniniGuncelle()
    {
        puanSurePaneli.GetComponent<CanvasGroup>().DOFade( 1f, 0.5f );

        PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade( 1f, 0.5f );

        ustDikdortgen.GetComponent<RectTransform>().DOLocalMoveX( 0, 1.5f ).SetEase( Ease.OutBack );

        altDikdortgen.GetComponent<RectTransform>().DOLocalMoveX( 0, 1.5f ).SetEase( Ease.OutBack );
    }

    public void OyunaBasla()
    {
        audioSource.PlayOneShot( baslangicSesi );

        PuaniKapYazisi.GetComponent<CanvasGroup>().DOFade( 0f, 1f );

        BuyukSayiyiSecYazisi.GetComponent<CanvasGroup>().DOFade( 1f, 1f );

        KacinciOyun();

        //ustText.text = "???";

        //altText.text = "???";

        //Debug.Log( "Oyun Baþladý" );

        timerManager.SureyiBaslat();
    }

    void KacinciOyun()
    {
        if(oyunSayaci<5)
        {
            kacinciOyun = 1;

            artisPuani = 25;
        }
        else if(oyunSayaci>=5 && oyunSayaci<10)
        {
            kacinciOyun = 2;

            artisPuani = 50;
        }
        else if ( oyunSayaci >= 10 && oyunSayaci < 15 )
        {
            kacinciOyun = 3;

            artisPuani = 75;
        }
        else if ( oyunSayaci >= 15 && oyunSayaci < 20 )
        {
            kacinciOyun = 4;

            artisPuani = 100;
        }
        else if ( oyunSayaci >= 20 && oyunSayaci < 25 )
        {
            kacinciOyun = 5;

            artisPuani = 125;
        }
        else
        {
            kacinciOyun = Random.Range( 1, 6 );

            artisPuani = 150;
        }

        switch (kacinciOyun)
        {
            case 1:
                BirinciFonksiyon();
                break;

            case 2:
                IkinciFonksiyon();

                break;

            case 3:
                UcuncuFonksiyon();

                break;

            case 4:
                DorduncuFonksiyon();

                break;

            case 5:
                BesinciFonksiyon();

                break;
        }
    }

    void BirinciFonksiyon()
    {
        int rastgeleDeger = Random.Range( 1, 50 );

        if(rastgeleDeger<=25)
        {
            ustDeger = Random.Range( 2, 50 );

            altDeger = ustDeger + Random.Range( 1, 15 );
        }else
        {
            ustDeger = Random.Range( 2, 50 );

            altDeger = Mathf.Abs(ustDeger - Random.Range( 1, 15 ));
        }

        if(ustDeger>altDeger)
        {
            buyukDeger = ustDeger;
        }
        else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }

        if(ustDeger==altDeger)
        {
            BirinciFonksiyon();
            return;
        }

        ustText.text = ustDeger.ToString();

        altText.text = altDeger.ToString();

    }

    void IkinciFonksiyon()
    {
        int birinciSayi = Random.Range( 1, 10 );

        int ikinciSayi = Random.Range( 1, 20 );


        int ucuncuSayi = Random.Range( 1, 10 );

        int dorduncuSayi = Random.Range( 1, 20 );

        ustDeger = birinciSayi + ikinciSayi;

        altDeger = ucuncuSayi + dorduncuSayi;

        if(ustDeger>altDeger)
        {
            buyukDeger = ustDeger;
        }else if(ustDeger<altDeger)
        {
            buyukDeger = altDeger;
        }

        if(ustDeger==altDeger)
        {
            IkinciFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "+" + ikinciSayi;

        altText.text = ucuncuSayi + "+" + dorduncuSayi;

    }

    void UcuncuFonksiyon()
    {
        int birinciSayi = Random.Range( 11, 30 );

        int ikinciSayi = Random.Range( 1, 11 );


        int ucuncuSayi = Random.Range( 11, 30 );

        int dorduncuSayi = Random.Range( 1, 11 );

        ustDeger = birinciSayi - ikinciSayi;

        altDeger = ucuncuSayi - dorduncuSayi;

        if ( ustDeger > altDeger )
        {
            buyukDeger = ustDeger;
        }
        else if ( ustDeger < altDeger )
        {
            buyukDeger = altDeger;
        }

        if ( ustDeger == altDeger )
        {
            UcuncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + "-" + ikinciSayi;

        altText.text = ucuncuSayi + "-" + dorduncuSayi;

    }

    void DorduncuFonksiyon ( )
    {
        int birinciSayi = Random.Range( 1, 10 );

        int ikinciSayi = Random.Range( 1, 10 );


        int ucuncuSayi = Random.Range( 1, 10 );

        int dorduncuSayi = Random.Range( 1, 10 );

        ustDeger = birinciSayi * ikinciSayi;

        altDeger = ucuncuSayi * dorduncuSayi;

        if ( ustDeger > altDeger )
        {
            buyukDeger = ustDeger;
        }
        else if ( ustDeger < altDeger )
        {
            buyukDeger = altDeger;
        }

        if ( ustDeger == altDeger )
        {
            DorduncuFonksiyon();
            return;
        }

        ustText.text = birinciSayi + " x " + ikinciSayi;

        altText.text = ucuncuSayi + " x " + dorduncuSayi;

    }

    void BesinciFonksiyon ( )
    {
        int bolen1 = Random.Range( 2, 10 );
        
        ustDeger = Random.Range( 2, 10 );
         

        int bolunen1 = bolen1 * ustDeger;


        int bolen2 = Random.Range( 2, 10 );

        altDeger = Random.Range( 2, 10 );


        int bolunen2 = bolen2 * altDeger;


        if ( ustDeger > altDeger )
        {
            buyukDeger = ustDeger;
        }
        else if ( ustDeger < altDeger )
        {
            buyukDeger = altDeger;
        }

        if ( ustDeger == altDeger )
        {
            BesinciFonksiyon();
            return;
        }

        ustText.text = bolunen1 + " / " + bolen1 ;

        altText.text = bolunen2 + " / " + bolen2;
    }

    public void ButonDegeriniBelirle(string butonAdi)
    {
        if(butonAdi=="ustButon")
        {
            butonDegeri = ustDeger;
        }else if(butonAdi=="altButon")
        {
            butonDegeri = altDeger;
        }

        //Debug.Log( butonDegeri );

        if ( butonDegeri == buyukDeger )
        {
            //Debug.Log( "dogru sonuc" );

            trueFalseManager.TrueFalseScaleAc( true );

            dairelerManager.DaireninScaleAc( oyunSayaci % 5 );

            oyunSayaci++;

            toplamPuan += artisPuani;

            skorText.text = toplamPuan.ToString();

            dogruAdet++;

            audioSource.PlayOneShot( dogruSesi );

            KacinciOyun();
        }else
        {
            //Debug.Log( "yalis sonuc" );

            trueFalseManager.TrueFalseScaleAc( false );

            HatayaGoreSayaciAzalt();

            yanlisAdet++;

            audioSource.PlayOneShot( yanlisSesi );

            KacinciOyun();
        }
    }

    void HatayaGoreSayaciAzalt()
    {
        oyunSayaci -= ( oyunSayaci % 5 + 5 );
        if(oyunSayaci<0)
        {
            oyunSayaci = 0;
        }

        dairelerManager.DairelerinScaleKapat();
    }

    public void PausePaneliAc()
    {
        pausePaneli.SetActive( true );
    }

    public void OyunBitti()
    {
        audioSource.PlayOneShot( bitisSesi );

        sonucPaneli.SetActive( true );

        sonucManager = Object.FindObjectOfType<SonucManager>();

        sonucManager.SonuclariGoster( dogruAdet, yanlisAdet, toplamPuan );
    }

}
