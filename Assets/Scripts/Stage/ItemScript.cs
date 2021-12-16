using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    #region//プライベート変数
    [SerializeField] Item.Type itemType;

    [SerializeField]
    int ItemID;

    private Rigidbody2D rb = null;      //いらないかも

    private ObjectCollision oc = null;
    private CapsuleCollider2D col = null;

    #endregion
    void Start()
    {
        //itemTypeに応じでItemを生成する
        ItemID = 1;     //臨時

        rb = GetComponent<Rigidbody2D>();
        oc = GetComponent<ObjectCollision>();
        col = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (oc.playerTouchOn)
        {
            //当たり判定を消す
            col.enabled = false;

            //アイテムを非活性にする
            this.gameObject.SetActive(false);
        }
    }

    //取得したら消す
    public void OnTouchObj()
    {
        //アイテムを取得済みにする
        //プレイヤーのステータス画面を再表示する

        this.gameObject.SetActive(false);
    }
}