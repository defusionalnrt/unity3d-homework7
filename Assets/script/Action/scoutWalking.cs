using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutWalking : SSAction{
    public float v;
    bool changeDir;
    public float posX;
    public float posZ;
    public GameObject scout;
    public GameObject player;
    public scoutData scoutD;
    public playerData playerD;
    public static scoutWalking getAction(GameObject player, GameObject scout){
        scoutWalking ac = CreateInstance<scoutWalking>();
        ac.player = player;
        ac.scout = scout;
        ac.posX = scout.transform.position.x;
        ac.posZ = scout.transform.position.z;
        return ac;
    }

    // Start is called before the first frame update
    public override void Start(){
        v = 0.5f;
        changeDir = true;
        scoutD = scout.GetComponent<scoutData>();
        playerD = player.GetComponent<playerData>();
    }

    // Update is called once per frame
    public override void Update(){
        bool inRoom = (scoutD.roomID == playerD.roomID);
        if(!scoutD.running && (scoutD.found && inRoom && !scoutD.needTurn && !playerD.getCatched)){
            Debug.Log("following");
            this.destroy = true;
            this.enable = false;
            this.gameObject.GetComponent<scoutData>().running = true;
            singleton<gameEventController>.Instance.chasingPlayer(this.gameObject);
        }
        else{
            walk();
        }
    }
    void walk(){
        if(changeDir){
            posX = this.transform.position.x + Random.Range(-3F, 3F);
            posZ = this.transform.position.z + Random.Range(-3F, 3F);
            this.transform.LookAt(new Vector3(posX,0,posZ));
            this.gameObject.GetComponent<scoutData>().needTurn = false;
            changeDir = false;
        }

        if(this.gameObject.GetComponent<scoutData>().needTurn){
            // Debug.Log("turning around");
            clashTurn();
        }
        else if(Vector3.Distance(transform.position, new Vector3(posX, 0, posZ)) <= 0.1f){
            changeDir = true;
        }
        else{
            this.transform.Translate(0,0,Time.deltaTime*v);
        }
    }
    void clashTurn(){
        this.transform.Rotate(Vector3.up,Random.Range(120, 180));
        GameObject temp = new GameObject();
        temp.transform.position = this.transform.position;
        temp.transform.rotation = this.transform.rotation;
        temp.transform.Translate(0, 0, Random.Range(0.5f, 2.0f));

        posX = temp.transform.position.x;
        posZ = temp.transform.position.z;
        this.transform.LookAt(new Vector3(posX, 0, posZ));
        Destroy(temp);
        this.gameObject.GetComponent<scoutData>().needTurn = false;
    }
}
