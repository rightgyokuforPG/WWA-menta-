using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L�����N�^�[�̐e�N���X
/// PlayerStatus�ɔh������
/// </summary>
[System.Serializable]
public class Status
{
    [SerializeField]
    public int StatusID;                //�L�����N�^�[�}�ӂƘA�g������ׂ�ID

    //[SerializeField]
    //public float Name;                  //����Ȃ��\������
    [SerializeField]
    public float HP;
    [SerializeField]
    public float ATK;
    [SerializeField]
    public float DEF;
    [SerializeField]
    public float MONEY;

    /// <summary>
    /// �����Ȃ���
    /// </summary>
    public Status()
    {
        //�o������A���̃X�N���v�g���ŁA
        //CharactorListEntity����f�[�^���擾������
        //��
        //public Status(int statusID)
        //this.StatusID = statusID
        //forEach(CharactorListEntity.StatusID -> ID)
        //
        //if(this.StatusID == ID)
        //this.HP = CharactorListEntity.getHP(ID)   //ID���w�肵��HP��Ԃ�
        //this.ATK = CharactorListEntity[ID].ATK    //�������̕��������̂��ȁH
        //this.DEF = 
        //This.Money = 

        //else
        //Debug.Log("status.cs:�}�ӂɂȂ��L�����N�^�[���Q�Ƃ��Ă��܂�")
    }

    //��������A�e�ϐ���Getter,Setter���
}