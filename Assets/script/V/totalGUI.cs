using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totalGUI : MonoBehaviour{
    string outputText;
    public bool failed;
    public bool start;

    void Start(){
        failed = false;
        start = false;
        outputText = "score: 0 time: 0s";
    }
     
    public void UpdateoutputText(int score,int second){
        outputText = "score: " + score + " time: " + second + "s";
    }
    void OnGUI(){
        if (Input.anyKeyDown) {
            start = true;
        }

        GUIStyle outputTextStyle = new GUIStyle();
        outputTextStyle.normal.textColor = Color.white;
        outputTextStyle.fontSize = 20;
        outputTextStyle.alignment = TextAnchor.MiddleCenter;
        GUI.Button(new Rect(30, 10, Screen.width - 60, 50), outputText, outputTextStyle);

        GUIStyle GameStartStyle = new GUIStyle();
        GameStartStyle.normal.textColor = Color.white;
        GameStartStyle.fontSize = 30;
        GameStartStyle.alignment = TextAnchor.MiddleCenter;
        if(!start){
            GUI.Button(new Rect(30, 30, Screen.width - 60, Screen.height - 60), "点击屏幕或按任意键以开始游戏", GameStartStyle);
        }
        else if(failed) {
            GUI.Button(new Rect(30, 30, Screen.width - 60, Screen.height - 60), "游戏结束", GameStartStyle);
        }
    }
}
