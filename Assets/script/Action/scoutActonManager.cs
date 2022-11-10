using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutActonManager : SSActionManager{
    public scoutChasing chasing;
    public scoutWalking walking;
    public void walk(GameObject player,GameObject scout){
        // Debug.Log("start walking");
        walking = scoutWalking.getAction(player,scout);
        RunSSAction(scout,walking);
    }
    public void chase(GameObject player,GameObject scout){
        chasing = scoutChasing.getAction(player,scout);
        RunSSAction(scout,chasing);
    }
    public void stop(){
        DestroyAll();
    }
}