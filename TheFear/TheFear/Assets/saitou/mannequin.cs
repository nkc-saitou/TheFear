using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mannequin : MonoBehaviour
{

    //--------------------------------------
    // public
    //--------------------------------------

    public GameObject manequinsAdd; //マネキン用

    //--------------------------------------
    // private
    //--------------------------------------

    int currentWave = 0; //現在のウェーブ
    public List<GameObject> manequinLis = new List<GameObject>();

    void Start()
    {
        //全部隠す
        foreach (Transform t in manequinsAdd.transform)
        {
            manequinLis.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Player" && manequinLis.Count > currentWave)
        {
            //ウェーブを増やす
            manequinLis[currentWave].SetActive(true);
            currentWave++;
        }
    }
}