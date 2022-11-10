using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour{
    private List<int> destroyList = new List<int>();
    private List<SSAction> addList = new List<SSAction>();
    public Dictionary<int, SSAction> actionDict = new Dictionary<int, SSAction>();
    protected void Update(){
        foreach (SSAction ac in addList){
            actionDict[ac.GetInstanceID()] = ac;
        }
        addList.Clear();
        foreach (var p in actionDict){
            SSAction ac = p.Value;
            if (ac.enable){
                ac.Update();
            }
            else if (ac.destroy){
                destroyList.Add(ac.GetInstanceID()); // release action
            }
        }
        foreach (int key in destroyList){
            SSAction ac = actionDict[key];
            actionDict.Remove(key);
            Destroy(ac);
        }
        destroyList.Clear();
    }

    public void RunSSAction(GameObject gameObject, SSAction ac){
        ac.gameObject = gameObject;
        ac.transform = gameObject.transform;
        addList.Add(ac);
        ac.Start();
    }
    public void DestroyAll(){
        foreach (var p in actionDict){
            SSAction ac = p.Value;
            ac.destroy = true;
        }
    }
    protected void Start() {
        
    }
}
