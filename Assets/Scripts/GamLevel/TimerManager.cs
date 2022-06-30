using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;

    public int kalanSure;

    bool sureSaysinmi;

    GameManager gameManager;

    private void Awake ( )
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sureSaysinmi = true;
    }

    public void SureyiBaslat()
    {
        StartCoroutine( SureTimeRoutine() );
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SureTimeRoutine()
    {
        while(sureSaysinmi)
        {
            yield return new WaitForSeconds( 1f );

            if(kalanSure<10)
            {
                SureText.text = "0" + kalanSure.ToString();
            }else
            {
                SureText.text = kalanSure.ToString();
            }

            if(kalanSure<=0)
            {
                sureSaysinmi = false;

                SureText.text = "";

                gameManager.OyunBitti();
            }

            kalanSure--;
        }
    }
}
