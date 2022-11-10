using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour{
    public Animator ani;
    private bool run;
    void Start(){
        ani = GetComponent<Animator>();
        run = true;
    }

    void Update(){
        //空格来切换静止/运动状态，asd用于向左/向后/向右转，左右小箭头用于小幅度(pi/6)转动
        if(Input.GetKeyDown(KeyCode.Space)){
            ani.SetBool("run",run);
            run = !run;
        }
        else if(Input.GetKeyDown("a")){
            transform.Rotate(0,-90.0f,0);
        }
        else if(Input.GetKeyDown("s")){
            transform.Rotate(0,180.0f,0);
        }
        else if(Input.GetKeyDown("d")){
            transform.Rotate(0,90.0f,0);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            transform.Rotate(0,-30.0f,0);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            transform.Rotate(0,30.0f,0);
        }
    }
}
