using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    #endregion


    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallBack;

    private void Awake() {
        instance = this;
        }

    public void AddItem(Item item) {
        Debug.Log("Avant" + items);
        items.Add(item);
        Debug.Log("Apres" +items);

        if (OnItemChangedCallBack != null) {
            OnItemChangedCallBack.Invoke();
            } 
        }

    
    }
