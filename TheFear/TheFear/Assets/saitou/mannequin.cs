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
    public Animator manequinAnim;

    public int Limit = 0; //マネキンを出す数
    public int manequinDisplay = 0; //車に座っているマネキンを表示するタイミング

    //--------------------------------------
    // private
    //--------------------------------------

    int current = 0; //現在のウェーブ
    float dis = 10;

    bool instantiateFlg; //マネキン増えるFlg
    bool swich_RightLeft; //左右どちらに表示させるかを切り替えるFlg
    bool manequinDistanceFlg; //生成するマネキンの距離が、他のマネキンと一定距離離れているかを判定するFlg

    List<GameObject> manequinObjLis = new List<GameObject>(); //生成したオブジェクトを記憶

    Vector3 randomPos; //ランダムに取得した座標を保存

    GameObject manequinObj; //生成したオブジェクト

    Color materialArm;

    void Start()
    {
        manequinCar.SetActive(false);
        manequinAnim.SetBool("ArmAnimationFlg", false);
    }

    void Update()
    {
        //外に５体のマネキンが出たら、車後ろに乗っているマネキン表示
        if (current == manequinDisplay)
        {
            manequinCar.SetActive(true);
            manequinAnim.SetBool("ArmAnimationFlg", true);
        }
        ManequinPosSetting();
    }

    //--------------------------------
    // マネキンを設置する場所や条件などを設定するメソッド
    //--------------------------------
    void ManequinPosSetting()
    {
        //上限数に達していない、かつマネキン増えるColliderに当たった場合のみ以下の処理を実行
        if (ManequinCondition) return;

        manequinDistanceFlg = false;

        //左右交互にオブジェクトを出現させる
        swich_RightLeft = !swich_RightLeft;

        ManequinDistance();

        //同じ座標位置が出てきたらやり直す
        if (manequinDistanceFlg)
        {
            return;
        }

        current++;

        manequinObj =
            Instantiate(manequinAdd, RandomPos(), Quaternion.identity, manequinParent.transform) as GameObject;

        //重ならないように、生成したオブジェクトをリストに追加
        //manequinPos.Add(RandomPos());
        manequinObjLis.Add(manequinObj);

        //Colliderに当たるまで待機
        instantiateFlg = false;
    }

    //-----------------------------------
    //マネキンが近すぎない位置設置するメソッド
    //-----------------------------------
    void ManequinDistance()
    {
        //生成されているオブジェクトが１体以下だったら
        if (manequinObjLis.Count <= 0) return;

        //リスト内に格納されているオブジェクトと、生成したオブジェクトの距離を取得
        foreach (GameObject obj in manequinObjLis)
        {
            Vector3 objPos = RandomPos();
            Vector3 lisAddpos = obj.transform.position;

            dis = Vector3.Distance(objPos, lisAddpos);

            //生成したマネキンの距離が他とくっついていたらtrue
            if (dis < 5) manequinDistanceFlg = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            instantiateFlg = true;
        }
    }

    //------------------------------------
    // マネキンを設置できるときの条件
    //------------------------------------
    bool ManequinCondition
    {
        //リミットが上限に達している、またはマネキン増えるColliderに当たっていない場合にtrueを返す
        get { return Limit < current || instantiateFlg == false; }
    }

    //------------------------------------
    // 左右それぞれのランダムな座標を取得
    //------------------------------------
    Vector3 RandomPos()
    {
        //ランダムに座標を取得
        Vector3 randomPos_Left = new Vector3(Random.Range(-30, -33), 1.5f, Random.Range(55, 60));
        Vector3 randomPos_Right = new Vector3(Random.Range(-20, -17), 1.5f, Random.Range(55, 60));

        //左右交互にマネキンを設置
        if (swich_RightLeft) randomPos = randomPos_Left;
        if (swich_RightLeft == false) randomPos = randomPos_Right;

        return randomPos;
    }
}