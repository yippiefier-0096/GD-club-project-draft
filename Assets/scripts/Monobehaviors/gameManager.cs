using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Unity.Mathematics;
using Unity.Tutorials.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{   
    [SerializeField]
    static public GameObject player_main;
    [Serializable]
    public struct playerSave
    {
        public float play_time;
        public Vector2 current_position;
        public String current_map;
        public inventoryItem current_item;

        [SerializeField]
        [Tooltip("every set of story related flag in the game. key is id, value is value of the flag. if no flag, return zero.")]
        public Dictionary <int, int> storyflag;

        [SerializeField]
        [Tooltip("Same as above, but for side interactions")]
        public Dictionary <int, int> sideflag;

        [SerializeField]
        [Tooltip("Same as above, but for the state of objects around the map")]
        public Dictionary <int, int> objflag;
    } 

    [SerializeField]
    public static playerSave loaded_file;

    
    void Awake()
    {
        if (FindAnyObjectByType<gameManager>())
        
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }
    void Update()
    {
        loaded_file.play_time+=Time.deltaTime;
    }
    static void initializePlayer(playerSave Data)
    {
        if (Data.play_time == 0)
        {
            Data.current_map="SampleScene";
            Data.current_item=null;
            Data.current_position=Vector2.zero;   
        }
        SceneManager.LoadScene(Data.current_map,LoadSceneMode.Single);
        player_main = Instantiate(Resources.Load<GameObject>("player"));
        player_main.transform.position=Data.current_position;
        print(Data.play_time);
        player_main.GetComponent<playerController>().item_held=Data.current_item; 
        DontDestroyOnLoad(player_main.gameObject);
        print("hello?");  
    }

    static public void saveToFile()
    {   
        loaded_file.current_position=player_main.transform.position;
        loaded_file.current_map=SceneManager.GetActiveScene().name;
        loaded_file.current_item=player_main.GetComponent<playerController>().item_held;
        PlayerPrefs.SetString("Save",JsonUtility.ToJson(loaded_file));
        print(PlayerPrefs.GetString("Save"));   
    }
    static public void loadFromFile()
    {
        loaded_file=PlayerPrefs.GetString("Save").IsNotNullOrEmpty()? 
        JsonUtility.FromJson<playerSave>(PlayerPrefs.GetString("Save")):
        new playerSave();
        initializePlayer(loaded_file);
    }

    static public void Push_text(interactInstance _ins)
    {
        playerController _target= player_main.GetComponent<playerController>();
        _target.can_control=false;
        _target.player_body.linearVelocity=Vector2.zero;
        var text=Resources.Load<GameObject>("prefabs/dialogue");
        GameObject _t=Instantiate(text,Vector3.zero,quaternion.identity);
        _t.GetComponentInChildren<textbox>().content=_ins.msg_content;
        _t.GetComponent<Canvas>().renderMode=RenderMode.ScreenSpaceOverlay;
        _t.transform.SetParent(_target.transform);
    }
    static public void Push_cutscene(cutsceneInstance _ins)
    {
        playerController _target= player_main.GetComponent<playerController>();
        _target.can_control=false;
        _target.player_body.linearVelocity=Vector2.zero;
        GameObject _c= new GameObject();
        _c.AddComponent<cutscenePlayer>();
        _c.GetComponent<cutscenePlayer>().cutscene=_ins;
        _c.GetComponent<cutscenePlayer>().StartCoroutine("Play_cutscene"); 
    }
    static public Dictionary<string,animationTarget[]>    List_animatable()
    {
        Dictionary<string,animationTarget[]> output=new Dictionary<string, animationTarget[]>();
        foreach (animationTarget i in FindObjectsByType<animationTarget>())
        {
            string _n=i.name_ref;
            if (output.ContainsKey(_n))
            {
                output.GetValueOrDefault(_n).Append<animationTarget>(i);
            }
            output.Add(i.name_ref,new animationTarget[] {i});
        }
        return output;
    }
}
