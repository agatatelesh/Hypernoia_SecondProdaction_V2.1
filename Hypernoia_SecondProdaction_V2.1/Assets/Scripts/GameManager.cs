using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool sceneIsLoaded;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N)){
            LoadNextScene();
        }

         if(Input.GetKeyDown(KeyCode.P)){
            LoadPreviosScene();
        }

        
    }

    public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     public void LoadPreviosScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
