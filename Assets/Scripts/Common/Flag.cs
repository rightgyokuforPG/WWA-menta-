using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �t���O�N���X�̐e�N���X
/// EnemyFlag��ItemFlag�AProgressParamFlag�ɔh������ <-�H�������Ă邩�s��w
/// ->����A�q�N���X�ł�Enemy�AItem�̃t���O�͈ꏏ�ɂ���A�ϐ��Ŏ�ޕ�������
/// 
/// �C���[�W
/// RPG�c�N�[���̃t���O�Ǘ����
/// bool�^��int�^��text�^���������Ă���z
/// �e�X�e�[�W��Enemy�|������/�|���ĂȂ���
/// �e�X�e�[�W��Item������������ĂȂ������Ǘ�����
/// ���ƁA�`���[�g���A����������ǂ������B
/// 
/// 
/// ��Enemy��Item�Ŏ�ޕ������Ȃ��Ȃ�킴�킴�p��������K�v�Ȃ��Ȃ��H
/// 
///  2021/09/25 �ǋL ���������Ă�̂��s��
/// </summary>
[System.Serializable]
public class Flag
{
    // �񋓌^�F��ނ�񋓂���
    public enum Type
    {
        _bool,    //bool�^�̃t���O
        _int,    //int�^�̃t���O
        _string,  //string�^�̃t���O

    }

    public Type type;       //���

    bool _boolFlag;
    int _intFlag;
    string _stringFlag;

    /// <summary>
    /// �A�C�e���������Ȃ���
    /// </summary>
    public Flag()
    {

    }

    /// <summary>
    /// �A�C�e���������K��Type���擾����
    /// </summary>
    public Flag(Type type)
    {
        this.type = type;
    }
}

//Flag.cs�́A�����̃N���X�݌v�}
//�C���X�^���X��������Type�ɂ���ĕϐ��̌^��ύX������
//�������炭�A�f�[�^get,set���ɂǂ̕ϐ��Ɋi�[���邩��type�ŕ�����΍s����͂�
//2021/09/25 �ǋL ���������Ă�̂��s��
