using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomSave : MonoBehaviour
{
    public void OnClick()
    {
        //セーブを行う
        GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().Save();
        Debug.Log("セーブしました");
    }
}