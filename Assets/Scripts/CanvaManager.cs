using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvaManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void doExitGame() {
        Application.Quit();
    }

    public void LaunchGame()
    {
        SceneManager.LoadScene(1);
    }
}
