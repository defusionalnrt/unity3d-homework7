using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camController : MonoBehaviour{		
    private Vector3 targetPos;
    Transform camTarget;
    public GameObject player;
    // Start is called before the first frame update
    void Start(){
        
    }
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void LateUpdate(){
        camTarget = player.transform.GetChild(2);
        targetPos = camTarget.position + Vector3.up * 3.0f - camTarget.forward * 3.0f;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 2.0f);
        //指定摄像机的指定角度
        transform.LookAt(camTarget);
    }
}
