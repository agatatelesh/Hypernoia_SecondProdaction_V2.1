using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBoundary_Warning : MonoBehaviour
{
    public GameObject warningGrid;

    void OnTriggerStay(Collider col) 
        {
            if (col.gameObject.tag == "MainCamera")
            {                      
                warningGrid.SetActive(false);
                //Debug.Log("User is IN a traking zone ") ;           
            }
        }

    void OnTriggerExit(Collider col) 
    {
        if (col.gameObject.tag == "MainCamera")
        {                      
            warningGrid.SetActive(true); 
            Debug.Log("User is OUT! a traking zone ") ;             
        }
    }
}
