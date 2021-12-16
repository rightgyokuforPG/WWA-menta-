using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header("Z軸座標")] public float z;
    [SerializeField, Header("追従させるオブジェクト")] private Transform targetObject;
    [SerializeField, Header("座標誤差調整用")] private Vector2 epsilon;

    private RectTransform canvasRT;
    private RectTransform uiImage;
    private Vector2 newPos;

      void Start()
    {
        //参考サイト
        //https://robamemo.hatenablog.com/entry/2019/09/02/082742

        newPos = new Vector2();

        //追従させる従属側のRectTransformを取得
        //uiImage = GameObject.Find("BattleView").GetComponent<RectTransform>();
        //非アクティブ時、取得出来ないので方法を変える
        uiImage = this.transform.Find("BattleView") as RectTransform;
        //RectTransformはTransformのサブクラスらしいのでこれで大丈夫らしい

        canvasRT = GetComponent<RectTransform>();
    }

    void Update()
    {
        newPos = Vector2.zero;

        //追従させる主動側のワールド座標をスクリーン座標に変換
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);

        //スクリーン座標をRectTransform座標に変換
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRT, screenPos, Camera.main, out newPos);

        uiImage.localPosition = new Vector3(newPos.x + epsilon.x, newPos.y + epsilon.y, z);
    }
}
