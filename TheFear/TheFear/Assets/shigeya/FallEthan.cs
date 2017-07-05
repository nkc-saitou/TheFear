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
    }

    void FallEthanFlg()
    {
        Instantiate(ethan, transform.position, transform.rotation);
    }
}
