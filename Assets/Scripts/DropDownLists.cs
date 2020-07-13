using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DropDownLists : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI output;
    public string[] sceneName;
    private string _sceneToLoad;
    private int _mode = 0;
    
    //for the mode
     public void HandleMode(int val){
        
        if (val==0){
            output.text = "вы проходите обучение";
            _mode = 0;
        }
        if (val==1){
            output.text= "вы проходите тестирование";
            _mode = 1;
        }
    }
    //void the scene
    public void HandleScene(int val){
        if(val==0){
            _sceneToLoad = sceneName[1];
        }
        if(val==1){
             _sceneToLoad = sceneName[2];
        }
        if(val==2){
             _sceneToLoad = sceneName[3];
        }
    } 
    void Awake(){
        _sceneToLoad = sceneName[1];
    }
    public void PlayPressed(){
        SceneManager.LoadScene(_sceneToLoad);
    }
    
}
