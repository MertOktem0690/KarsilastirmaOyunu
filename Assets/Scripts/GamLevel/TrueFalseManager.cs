using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TrueFalseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject trueIcon, falseIcon;

    // Start is called before the first frame update
    void Start ( )
    {
        ScaleDegeriniKapat(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TrueFalseScaleAc(bool dogrumuYanlismi)
    {
        if(dogrumuYanlismi)
        {
            trueIcon.GetComponent<RectTransform>().DOScale( 1, 0.2f );
            falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }else
        {
            falseIcon.GetComponent<RectTransform>().DOScale( 1, 0.2f );
            trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        Invoke( "ScaleDegeriniKapat", 0.5f );
    }

    void ScaleDegeriniKapat()
    {
        trueIcon.GetComponent<RectTransform>().localScale = Vector3.zero;

        falseIcon.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

}
