using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Transform kafa;

    [SerializeField]
    private Transform startBtn;

    // Start is called before the first frame update
    void Start()
    {
        kafa.transform.GetComponent<RectTransform>().DOLocalMoveX( 0f, 1.5f ).SetEase( Ease.OutBack );

        startBtn.transform.GetComponent<RectTransform>().DOLocalMoveY( -700f, 1.5f ).SetEase( Ease.OutBack );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunaBasla ( )
    {
        SceneManager.LoadScene( "GameLevel" );
    }

}