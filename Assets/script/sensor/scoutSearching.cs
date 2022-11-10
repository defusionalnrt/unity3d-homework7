using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutSearching : MonoBehaviour{
    topController topcontroller;
    public GameObject scout;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other){
        topcontroller = director.GetSingleton().currentSceneController as topController;
        if(other.gameObject.Equals(topcontroller.player)){
            scout.GetComponent<scoutData>().found = true;
        }
    }
    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit(Collider other){
        topcontroller = director.GetSingleton().currentSceneController as topController;
        if(other.gameObject.Equals(topcontroller.player)){
            scout.GetComponent<scoutData>().found = false;
        }
    }
}
