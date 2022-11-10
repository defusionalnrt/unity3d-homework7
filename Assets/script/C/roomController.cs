using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomController : MonoBehaviour{
    topController topcontroller;
    float[] X = {-15.0f,-5.0f,5.0f,15.0f};
    float[] Z = {15.0f,5.0f,-5.0f,-15.0f};
    float range = 4.0f;
    int cnt = 0;
    void Update(){
        topcontroller = director.GetSingleton().currentSceneController as topController;
        GameObject player = topcontroller.player;
        float x = player.transform.position.x;
        float z = player.transform.position.z;
        player.GetComponent<playerData>().roomID = (int)(((x+20) / 10) + 1) + (int)(4-(z+20) / 10) * 4;
        cnt++;
        if(cnt == 30){
            keepinRoom();
            cnt = 0;
        }
    }
    void keepinRoom() {
        for(int i = 0 ; i < topcontroller.scouts.Count ; i++) {
            GameObject scout = topcontroller.scouts[i];
            Vector3 pos = scout.transform.position;
            //房间对应的行数和列数
            int roomID = scout.GetComponent<scoutData>().roomID;
            int row = (roomID-1) % 4;
            int col = (roomID-1) / 4;
            if(pos.x < X[row] - range || pos.x > X[row] + range || pos.z < Z[col] - range || pos.z > Z[col] + range){
                //将巡逻兵离开房间的操作视为一次碰撞
                scout.GetComponent<scoutData>().needTurn = true;
            }
        }
    }
}
