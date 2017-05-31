using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMove : MonoBehaviour
{
    //----------------------------------
    // 定数
    //----------------------------------

    const float STAGE_WARP_FORWARD = 300.0f;
    const float STAGE_WARP = 190.0f;

    //----------------------------------
    // public
    //----------------------------------

    public GameObject[] stage;

    [SerializeField,Range(0,80)]
    public float speed = 22.0f;

    //----------------------------------
    // private
    //----------------------------------

    Vector3[] stagePos = new Vector3[3];

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].transform.localPosition -= Vector3.forward*speed * Time.deltaTime;

            if (stage[i].transform.localPosition.z < -STAGE_WARP)
            {
                stagePos[i] = stage[i].transform.localPosition;
                stagePos[i].z = STAGE_WARP_FORWARD;
                stage[i].transform.localPosition = stagePos[i];
            }
        }
    }
}
