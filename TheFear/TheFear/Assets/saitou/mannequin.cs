using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mannequin : MonoBehaviour
{
    //--------------------------------------
    // public
    //--------------------------------------

    public GameObject manequinAdd; //マネキン
    public GameObject manequinCar; //車に座っているマネキン
    public GameObject manequinParent; //マネキンの親オブジェクト

    public int Limit = 0; //マネキンを出す数
    public int manequinDisplay = 0; //車に座っているマネキンを表示するタイミング

    //--------------------------------------
    // private
    //--------------------------------------

    int current = 0; //現在のウェーブ

    List<Vector3> manequinPos = new List<Vector3>(); //生成したオブジェクト座標を記憶する用のリスト

    bool instantiateFlg; //マネキン増えるFlg
    bool swich_RightLeft; //左右どちらに表示させるかを切り替えるFlg

    Vector3 randomPos; //ランダムに取得した座標を保存


    void Start()
    {
        manequinCar.SetActive(false);
    }

    void Update()
    {
        //外に５体のマネキンが出たら、車後ろに乗っているマネキン表示
        if(current == manequinDisplay)
        {
            manequinCar.SetActive(true);
        }

        ManequinPosSetting();
    }

    void ManequinPosSetting()
    {
        //上限数に達していない、またはマネキン増えるColliderに当たった場合のみ以下の処理を実行
        if (Limit < current || instantiateFlg == false) return;

        //左右交互にオブジェクトを出現させる
        swich_RightLeft = !swich_RightLeft;

        //同じ座標位置が出てきたらやり直す
        if (manequinPos.Contains(RandomPos()))
        {
            Debug.Log("shigeyama");
            return;
        }

        current++;

        GameObject manequinObj =
            Instantiate(manequinAdd, RandomPos(), Quaternion.identity, manequinParent.transform) as GameObject;

        //重ならないように、生成したオブジェクト座標をリストに追加
        manequinPos.Add(RandomPos());

        //Colliderに当たるまで待機
        instantiateFlg = false;
    }

    Vector3 RandomPos()
    {
        //ランダムに座標を取得
        Vector3 randomPos_Left = new Vector3(Random.Range(-30, -33), 1.5f, Random.Range(55,60));
        Vector3 randomPos_Right = new Vector3(Random.Range(-20, -17), 1.5f, Random.Range(55, 60));

        if (swich_RightLeft) randomPos = randomPos_Left;
        if (swich_RightLeft == false) randomPos = randomPos_Right;

        return randomPos;
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            instantiateFlg = true;
        }
    }
}