using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField]
    private Text dogruAdetTxt, yanlisAdetTxt, puanTxt;

    int puanSure = 10;

    bool sureBittimi = true;

    int toplamPuan, yazdirilicakPuan, artisPuani;

    private void Awake ( )
    {
        sureBittimi = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SonuclariGoster ( int dogruAdet, int yanlisAdet, int puan )
    {
        dogruAdetTxt.text = dogruAdet.ToString();

        yanlisAdetTxt.text = yanlisAdet.ToString();

        puanTxt.text = puan.ToString();

        toplamPuan = puan;

        artisPuani = toplamPuan / 10;

        StartCoroutine( PuaniYazdirRoutine() );
    }

    IEnumerator PuaniYazdirRoutine()
    {
        while(sureBittimi)
        {
            yield return new WaitForSeconds( 0.1f );

            yazdirilicakPuan += artisPuani;

            if(yazdirilicakPuan>=toplamPuan)
            {
                yazdirilicakPuan = toplamPuan;
            }

            puanTxt.text = yazdirilicakPuan.ToString();

            if(puanSure<=0)
            {
                sureBittimi = false;
            }

            puanSure--;
        }
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene( "menuLevel" );
    }

    public void TekrarOyna ( )
    {
        SceneManager.LoadScene( "gameLevel" );
    }
}
