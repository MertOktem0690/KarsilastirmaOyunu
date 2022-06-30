using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GeriSayimManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GerisayimObje;

    [SerializeField]
    private Text geriSayimText;

    GameManager gameManager;

    private void Awake ( )
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( GeriyeSayRoutine() );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GeriyeSayRoutine()
    {
        geriSayimText.text = "3";

        yield return new WaitForSeconds( 0.5f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 1, 0.5f ).SetEase(Ease.OutBack);

        yield return new WaitForSeconds( 1f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 0, 0.5f ).SetEase( Ease.InBack );

        yield return new WaitForSeconds( 0.5f );

        geriSayimText.text = "2";

        yield return new WaitForSeconds( 0.5f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 1, 0.5f ).SetEase( Ease.OutBack );

        yield return new WaitForSeconds( 1f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 0, 0.5f ).SetEase( Ease.InBack );

        yield return new WaitForSeconds( 0.5f );

        geriSayimText.text = "1";

        yield return new WaitForSeconds( 0.5f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 1, 0.5f ).SetEase( Ease.OutBack );

        yield return new WaitForSeconds( 1f );

        GerisayimObje.GetComponent<RectTransform>().DOScale( 0, 0.5f ).SetEase( Ease.InBack );

        yield return new WaitForSeconds( 0.5f );

        StopAllCoroutines();
        gameManager.OyunaBasla();
        //Debug.Log( "Oyun Baþladý" );
    }
}
