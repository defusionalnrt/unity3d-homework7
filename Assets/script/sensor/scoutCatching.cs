using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutCatching : MonoBehaviour{
    topController topcontroller;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other){
        Debug.Log("coll");
        topcontroller = director.GetSingleton().currentSceneController as topController;
        if(other.gameObject.Equals(topcontroller.player)){
            Debug.Log("catch");
            singleton<gameEventController>.Instance.playerCatched();

        }
        else{
            this.GetComponent<scoutData>().needTurn = true;
        }
    }
}
