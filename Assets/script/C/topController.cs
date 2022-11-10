using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topController : MonoBehaviour,sceneController{
    public List<GameObject> scouts = new List<GameObject>();
    public GameObject player;
    public totalGUI totalgui;
    public scoutFactory scoutfactory;
    public playerFactory playerfactory;
    public gameEventController gameeventcontroller;
    public scoutActonManager scoutactionManager;
    public roomController roomcontroller;
    public scoreController scorecontroller;
    public camController camcontroller;
    int time;
    int cnt;
    // Start is called before the first frame update
    void Start(){
        Application.targetFrameRate = 60;
        time = cnt = 0;
        director.GetSingleton().currentSceneController = this;
        gameObject.AddComponent<scoutFactory>();
        scoutfactory = singleton<scoutFactory>.Instance;

        gameObject.AddComponent<playerFactory>();
        playerfactory = singleton<playerFactory>.Instance;
        load();
        gameObject.AddComponent<scoutActonManager>();
        scoutactionManager = singleton<scoutActonManager>.Instance;
        gameObject.AddComponent<gameEventController>();
        gameeventcontroller = singleton<gameEventController>.Instance;

        gameObject.AddComponent<totalGUI>();
        totalgui = singleton<totalGUI>.Instance;

        gameObject.AddComponent<roomController>();
        roomcontroller = singleton<roomController>.Instance;

        gameObject.AddComponent<scoreController>();
        scorecontroller = singleton<scoreController>.Instance;

        Camera.main.GetComponent<camController>().player = player;
        for(int j = 0;j < scouts.Count;++j){
            scoutactionManager.walk(player,scouts[j]);
        }
    }

    // Update is called once per frame
    void Update(){
        if(totalgui.start && !totalgui.failed){
            ++cnt;
            if(cnt == 60){
                cnt = 0;
                ++time;
            }
        }
        totalgui.UpdateoutputText(scorecontroller.score,time);
    }
    //load scene
    public void load(){
        Debug.Log("loading");
        player = playerfactory.getPlayer();
        Debug.Log("player ready");
        scouts.Clear();
        for(int j = 1;j <= 16;++j){
            Debug.Log("add");
            if(j != 10){
                GameObject scout1 = scoutfactory.getScout(j,2,2);
                scouts.Add(scout1);
                GameObject scout2 = scoutfactory.getScout(j,-3,-2);
                scouts.Add(scout2);
                GameObject scout3 = scoutfactory.getScout(j,1,-3);
                scouts.Add(scout3);
            }
            if(j == 3 || j == 7 || j == 12 || j == 16){
                GameObject scout4 = scoutfactory.getScout(j,1,2);
                scouts.Add(scout4);
                GameObject scout5 = scoutfactory.getScout(j,3,2);
                scouts.Add(scout5);
            }
        }
        Debug.Log("add scout");
        
    }
    //player逃出scout视线
    public void runaway(GameObject scout){
        scoutactionManager.walk(player,scout);
        Debug.Log(scout.GetInstanceID());
        if(!player.GetComponent<playerData>().getCatched){
            scorecontroller.add();
        }
    }
    //player被scout发现
    public void chasing(GameObject scout){
        if(!player.GetComponent<playerData>().getCatched){
            scoutactionManager.chase(player,scout);
        }
    }
    //player被抓
    public void catched(){
        Debug.Log("gg");
        for(int j = 0;j < scouts.Count;++j){
            scouts[j].SetActive(false);
        }
        totalgui.failed = true;
    }
        
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable(){
        gameEventController.runaway += runaway;
        gameEventController.chasing += chasing;
        gameEventController.catched += catched;
    }
    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable(){
        gameEventController.runaway -= runaway;
        gameEventController.chasing -= chasing;
        gameEventController.catched -= catched;
    }
}
