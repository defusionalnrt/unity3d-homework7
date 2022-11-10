using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class director : System.Object{
    private static director singletonInstance;
    public sceneController currentSceneController { get; set; }
    public static director GetSingleton(){

        if (singletonInstance == null){
            singletonInstance = new director();
        }
        return singletonInstance;
    }

}
