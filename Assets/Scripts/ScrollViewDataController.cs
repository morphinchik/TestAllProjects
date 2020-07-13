using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollViewDataController : MonoBehaviour
{
    // Start is called before the first frame update
 
    public RectTransform prefab;
    public Text contentOutput;
    
    public RectTransform content;
    private Button lastSelectedButton = null;

    public void UpdateItems(){
        StartCoroutine(GetItems(results => OnReceivedModels(results)));
    }
    void OnReceivedModels(TestItemModel[] models){
        foreach(Transform child in content){
            Destroy(child.gameObject); 
        }
        foreach(var model in models){
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content,false);
            InitializeItemView(instance,model);
        }
    
    }
    void InitializeItemView(GameObject viewGameObject, TestItemModel model){
        TestItemView view = new TestItemView(viewGameObject.transform);
        view.clickbutton.GetComponentInChildren<Text>().text = model.buttonText;
        view.clickbutton.onClick.AddListener(
            ()=>
            {
               contentOutput.text = model.PersonInfo;
               if(lastSelectedButton!=null ){
                   if(view.clickbutton != lastSelectedButton){
                    lastSelectedButton.image.color = Color.white;
                    view.clickbutton.image.color = new Color32(255,183,18,255);
                    lastSelectedButton = view.clickbutton;  
                   }
                    else return;
               }
               else {
                    view.clickbutton.image.color = new Color32(255,183,18,255);
                    lastSelectedButton = view.clickbutton;
               }
               
                  
               
               
               
                 
            }
        );
        
    }
    IEnumerator GetItems (System.Action<TestItemModel[]> callback){
        yield return new WaitForSeconds(1f);
        List<UserData> usersData = SQL_Engine.GetUsersData();
        var results = new TestItemModel[usersData.Count];
        for(int i=0;i<usersData.Count;i++){
            results[i] = new TestItemModel();
            results[i].buttonText = string.Format("{0} {1}. {2}.", usersData[i].Surname, usersData[i].Name[0], usersData[i].Patronymic[0]);
            results[i].PersonInfo = string.Format("{0} {1} {2} {3}", usersData[i].Surname, usersData[i].Name, usersData[i].Patronymic, usersData[i].Identificator);
        }
        callback(results);
    }

    public class TestItemModel{
        public string buttonText;
        public string PersonInfo;
       
    }
    public class TestItemView{
       
        public Text titleText;
        public Button clickbutton;

        public TestItemView (Transform rootView){
            clickbutton = rootView.Find("ClickButton").GetComponent<Button>();
        }
    }
   
}
