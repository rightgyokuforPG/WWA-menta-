using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    //��肽���̂�
    //Inventory
    //{
    //  �� : 3�{
    //  ... :0��
    //  �r���A�҃A�C�e�� : 2��
    //  ... :0��
    //}
    //�Ȃ̂ł����炭�A�A�C�e���}�ӂ��p�����č쐬����Ɗy���ۂ�
    //
    //



    [SerializeField]
    public List<Items> itemList;

    /// <summary>
    /// �����Ȃ���
    /// </summary>
    public Inventory()
    {

    }
}

/// <summary>
/// �A�C�e���N���X�̎q�N���X
/// ���\�L��������
/// �ړI�FInventory�ɕێ�����ہA����ێ��ł��Ȃ���1�������ĂȂ��ׁB
/// </summary>
[System.Serializable]
public class Items : Item
{
    public float Number;

    /// <summary>
    /// �����Ȃ���
    /// </summary>
    public Items()
    {

    }
}