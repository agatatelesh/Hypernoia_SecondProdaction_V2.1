using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScript : MonoBehaviour
{
    public List<GameObject> toBeActive_firstGroup = new List<GameObject>();
     public List<GameObject> toBeActive_secondGroup = new List<GameObject>();

    public bool isActive_1 = false;
    public bool isActive_2 = false;

   // public GameObject toActivate;
    //public GameObject toDeactivate;

    // Update is called once per frame
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            ActivateFirstGroup();
            
        }
        if(Input.GetKeyDown(KeyCode.K)){
            ActivateSecondGroup();
            
        }
        
    }

    public void ActivateFirstGroup(){
        //toActivate.SetActive(true);
        //toDeactivate.SetActive(false);
        isActive_1 = !isActive_1;
        foreach(GameObject obj in toBeActive_firstGroup){
            obj.SetActive(isActive_1);
        }
    }

    public void ActivateSecondGroup(){
        //toActivate.SetActive(true);
        //toDeactivate.SetActive(false);
        isActive_2 = !isActive_2;
        foreach(GameObject obj in toBeActive_secondGroup){
            obj.SetActive(isActive_2);
        }
    }



}
