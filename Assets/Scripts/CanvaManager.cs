using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    public GameObject setting;
    public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        setting.SetActive(false);
        main.SetActive(true);
        
    }

    // Update is called once per frame
    public void doExitGame()
    {
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Main_Canvas()
    {
        setting.SetActive(false);
        main.SetActive(true);
    }

    public void Setting_Canvas()
    {
        setting.SetActive(true);
        main.SetActive(false);
    }

}
