using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoutFactory : MonoBehaviour{
    public List<scoutData> datas = new List<scoutData>();
    int[] X = {-15,-5,5,15};
    int[] Z = {15,5,-5,-15};

    public GameObject getScout(int roomID,int x,int z){
        int row = (roomID - 1) % 4;
        int col = (roomID - 1) / 4;
        GameObject scout = Instantiate(Resources.Load<GameObject>("Prefabs/scout"));
        if(scout == null){
            Debug.Log("failed load scout");
        }
        scout.transform.position = new Vector3(X[row]+x,0, Z[col]+z);
        scout.AddComponent<scoutData>();
        scout.AddComponent<scoutCatching>();
        scout.transform.GetChild(2).gameObject.AddComponent<scoutSearching>();
        scout.transform.GetChild(2).gameObject.GetComponent<scoutSearching>().scout = scout;

        scoutData data = scout.GetComponent<scoutData>();
        if(data == null){
            Debug.Log("nul");
        }
        
        data.roomID = roomID;
        data.range = 5;
        data.needTurn = data.found = data.running = false;
        datas.Add(data);
        return scout;
    }
}
