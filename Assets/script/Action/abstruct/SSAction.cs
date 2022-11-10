using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSAction : ScriptableObject{
    public bool enable = true;
    public bool destroy = false;
    public GameObject gameObject{ get; set; }
    public Transform transform{ get; set; }
    protected SSAction(){

    }
    public virtual void Start(){
        
    }
    public virtual void Update(){

    }
    public void Reset(){
        enable = false;
        destroy = false;
        gameObject = null;
        transform = null;
    }
}
