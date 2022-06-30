using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePaneli;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable ( )
    {
        Time.timeScale = 0f;
    }

    private void OnDisable ( )
    {
        Time.timeScale = 1f;
    }

    public void DevamEt()
    {
        pausePaneli.SetActive( false );
    }

    public void MenuyeDon()
    {
        SceneManager.LoadScene( "menuLevel" );
    }

    public void OyundanCýk()
    {
        Application.Quit();

        Debug.Log( "Oyundan Çýktý" );
    }
}
