﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pin : MonoBehaviour
{
   public string name;
   [TextArea(1,3)]
   public string description;
   public Sprite icon;
   public string ID;
   private Image mapSymbolImg;
   private Sprite mapSymbol;
   private bool isFavorite;

   [SerializeField] private bool isInfo;

void Start()
{
    mapSymbolImg = gameObject.GetComponent<Image>();

    if(!isInfo)
    {
    mapSymbol = Singleton.GetInstance.normalMapSymbol;
    }

    else
    {
        mapSymbol = Singleton.GetInstance.infoSprite;
    }

    if(PlayerPrefs.HasKey(ID))
    {
     mapSymbolImg.sprite = Singleton.GetInstance.favoritedMapSymbol;
    }

    else
    {
      if(!isInfo)
      {
        mapSymbolImg.sprite = mapSymbol;
      }
      else
      {
        mapSymbol = Singleton.GetInstance.infoSprite;
      }
    }

    if(PlayerPrefs.HasKey("Redirected"))
    {
        if(PlayerPrefs.GetString("Redirected") == name)
        {               
            SendInformation();
            Singleton.GetInstance.pinManager.ToggleBoxes();
            PlayerPrefs.DeleteKey("Redirected");
        }
    }

}
public void SendInformation()
{
    
    Singleton.GetInstance.pinManager.ShowInfo(icon, name , description,ID);
}

public void Favorite()
{
  if(!isFavorite)
  {  
  mapSymbolImg.sprite = Singleton.GetInstance.favoritedMapSymbol;
  isFavorite = true;
  PlayerPrefs.SetInt(ID , 1);
  
  }
  else
  {
    mapSymbolImg.sprite = mapSymbol;  
    isFavorite = false;
    PlayerPrefs.DeleteKey(ID);
  }

}


}