using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScript : MonoBehaviour
{
    public List<GameObject> toBeActive_firstGroupL = new List<GameObject>();
    public List<GameObject> toBeActive_secondGroupK = new List<GameObject>();

    public List<GameObject> toBeActive_thirdGroupJ = new List<GameObject>();

    public bool isActive_1 = false;
    public bool isActive_2 = false;

    public bool isActive_3 = false;

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
         if(Input.GetKeyDown(KeyCode.J)){
            ActivateThirdGroup();
            
        }
        
    }

    public void ActivateFirstGroup(){
        //toActivate.SetActive(true);
        //toDeactivate.SetActive(false);
        isActive_1 = !isActive_1;
        foreach(GameObject obj in toBeActive_firstGroupL){
            obj.SetActive(isActive_1);
        }
    }

    public void ActivateSecondGroup(){
        //toActivate.SetActive(true);
        //toDeactivate.SetActive(false);
        isActive_2 = !isActive_2;
        foreach(GameObject obj in toBeActive_secondGroupK){
            obj.SetActive(isActive_2);
        }
    }

    public void ActivateThirdGroup(){
        //toActivate.SetActive(true);
        //toDeactivate.SetActive(false);
        isActive_3 = !isActive_3;
        foreach(GameObject obj in toBeActive_thirdGroupJ){
            obj.SetActive(isActive_3);
        }
    }



}
