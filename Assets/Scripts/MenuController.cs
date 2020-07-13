using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] Menus;
    private GameObject currentMenu;
    private GameObject lastMenu;
    
    public void FindMActive(){
        Menus[0].SetActive(false);
        Menus[1].SetActive(true);
        currentMenu = Menus[1];
        lastMenu = Menus[0];
    }
    public void CreateMActive(){
        Menus[0].SetActive(false);
        Menus[2].SetActive(true);
        currentMenu = Menus[2];
        lastMenu = Menus[0];
    }
    public void ModeMActive(){
        if(currentMenu.name == Menus[1].name){
            Menus[1].SetActive(false);
            Menus[3].SetActive(true);
            currentMenu = Menus[3];
            lastMenu = Menus[1];
        }
        else{
            Menus[2].SetActive(false);
            Menus[3].SetActive(true);
            currentMenu = Menus[3];
            lastMenu = Menus[2];
        }
    }
    public void BackInMenu(){
        GameObject temp = currentMenu;
        currentMenu.SetActive(false);
        lastMenu.SetActive(true);
        currentMenu = lastMenu;
        lastMenu = Menus[0];
    }
    void Awake(){
        Menus[0].SetActive(true);
        for(int i=1;i<Menus.Length;i++){
            Menus[i].SetActive(false);
        }
    }
    
}
