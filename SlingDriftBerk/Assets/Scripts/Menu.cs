using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public GameObject endMenu, Win;
    
    void Start()
    {
        
    }  
    void Update()
    {
        
    }
   
    public void MenuCreate(bool Lose)
    {
        if (Lose == false)
            endMenu.SetActive(true);
        else
        {
            endMenu.SetActive(true);
            Win.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
