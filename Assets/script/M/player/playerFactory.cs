using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFactory : MonoBehaviour{
    public playerData data;
    public GameObject getPlayer(){
        GameObject player = Instantiate(Resources.Load<GameObject>("Prefabs/player"));
        if(player == null){
            Debug.Log("no player found");
        }
        player.AddComponent<playerController>();
        player.AddComponent<playerData>();

        data = player.GetComponent<playerData>();
        data.roomID = 10;
        data.getCatched = false;
        return player;
    }
}
