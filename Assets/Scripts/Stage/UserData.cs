using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
}

[System.Serializable]
public class PlayerStatus : Status
{
    public string Name = "�Ȃ܂�";
}

[System.Serializable]
public class ItemFlag : Flag
{
    public string ItemFlagName = "�A�C�e������t���O";

    [SerializeField]
    public int ItemID;

    [SerializeField]
    public bool isExist;

    [SerializeField]
    public string Bikou;
    public ItemFlag()
    {
        //this.isExist = true;
    }

}


//�o������t���O�́A
//���i�s�t���O
//���G�|�������t���O
//���A�C�e������������t���O�ɕ�������