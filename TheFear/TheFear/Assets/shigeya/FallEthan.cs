using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallEthan : MonoBehaviour
{

    public GameObject ethan;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FallEthanFlg();
        }
    }

    void FallEthanFlg()
    {
        Instantiate(ethan, transform.position, transform.rotation);
    }
}
