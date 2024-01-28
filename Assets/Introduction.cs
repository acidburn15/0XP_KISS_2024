using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{

    [SerializeField] private GameObject[] panels;
    private int currentPanel=0;

    // Start is called before the first frame update
    void Start()
    {
        panels[0].SetActive(true);

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentPanel == 8)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                changePanel();
            }
            
        }
           
    }

    public void changePanel()
    {
        
        
            panels[currentPanel].SetActive(false);
            currentPanel++;
            panels[currentPanel].SetActive(true);
        

    }
}
