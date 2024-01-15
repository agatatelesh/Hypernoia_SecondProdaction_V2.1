using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScript : MonoBehaviour
{
    public GameObject toActivate;
    public GameObject toDeactivate;

    // Update is called once per frame
     void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            ActivateObj();
            
        }
        
    }

    public void ActivateObj(){
        toActivate.SetActive(true);
        toDeactivate.SetActive(false);
    }

}
