using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    [SerializeField]
    string text = "���͂悤";

    //�v���C���[�X�e�[�^�X
    [SerializeField]
    public PlayerStatus playerStatus;

    //(�v���C���[��) �����A�C�e�����X�g
    [SerializeField]
    public Inventory inventory;


    //���@�ȉ��̓}�X�N�f�[�^

    //�A�C�e������t���O
    [SerializeField]
    public List<ItemFlag> itemFlagList;

    //�V���{�������t���O
    //�� stage1�̉E��̃A�C�e������������[�@�Ƃ��B�V���{���G���J�E���g����B

    //[SerializeField]
    //public List<SymbolExistFlag> symbolExistFlagList;

    //�� �}�ӂ͂����ȒP�ɕς��Ȃ�����ObjectScripting�ł�������

    public SaveData()
    {
        playerStatus = new PlayerStatus();
        inventory = new Inventory();
        itemFlagList = new List<ItemFlag>();
    }

}