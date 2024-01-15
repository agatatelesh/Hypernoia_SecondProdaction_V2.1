using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTriggerSceneLoader : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        Debug.Log("OptiTrack triggered with: " + other.gameObject.name);
        LoadNextScene();
        
    }

     public void LoadNextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
