using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutChasing : SSAction{
    public float v;
    public GameObject scout;
    public GameObject player;
    public scoutData scoutD;
    public playerData playerD;
    public static scoutChasing getAction(GameObject player, GameObject scout){
        scoutChasing ac = CreateInstance<scoutChasing>();
        ac.player = player;
        ac.scout = scout;
        return ac;
    }
    public override void Start(){
        scoutD = scout.GetComponent<scoutData>();
        v = 0.8f;
        playerD = player.GetComponent<playerData>();
    }
    public override void Update(){
        bool outofRoom = (scoutD.roomID != playerD.roomID);
        if(scoutD.running && (!scoutD.found || outofRoom || scoutD.needTurn || playerD.getCatched)){
            Debug.Log("giveup"+scoutD.needTurn);
            this.destroy = true;
            this.enable = false;
            this.gameObject.GetComponent<scoutData>().running = false;
            singleton<gameEventController>.Instance.runAway(this.gameObject);
        }
        else{
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, v*Time.deltaTime);
        }
    }
}
