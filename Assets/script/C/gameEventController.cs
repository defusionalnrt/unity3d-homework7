using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEventController : MonoBehaviour{
    //玩家摆脱巡逻兵
    public delegate void runAwayEvent(GameObject ghost);
    public static event runAwayEvent runaway;
    //玩家被发现
    public delegate void ChasingEvent(GameObject scout);
    public static event ChasingEvent chasing;
    //玩家被捕获
    public delegate void CatchedEvent();
    public static event CatchedEvent catched;

    public void runAway(GameObject scout){
        if(runaway != null){
            runaway(scout);
        }
    }
    public void chasingPlayer(GameObject scout){
        if (chasing != null){
            chasing(scout);
        }
    }

    public void playerCatched(){
        if(catched != null){
            catched();
        }
    }
}
