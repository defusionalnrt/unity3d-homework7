using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreController : MonoBehaviour{
    public int score = 0;
    // Start is called before the first frame update
    void Start(){
        
    }
    public void add(int i = 1){
        score += i;
    }
    public void set(int target = 0){
        score = target;
    }
}