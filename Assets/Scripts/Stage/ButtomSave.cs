using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtomSave : MonoBehaviour
{
    public void OnClick()
    {
        //�Z�[�u���s��
        GameObject.FindWithTag("GameManager").GetComponent<SaveManager>().Save();
        Debug.Log("�Z�[�u���܂���");
    }
}