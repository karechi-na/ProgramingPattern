using UnityEngine;

/// <summary>
/// ����m�F�p�N���X
/// </summary>
public class TestScripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ���[�J���ϐ��̐錾�Ə�����
        int a = 1234567890;

        // UIUtility�N���X��NumberFormatter���\�b�h���Ăяo��
        // 3�����Ƃ�,����ꂽ��������擾
        string b = UIUtility.NumberFormatter(a);



        // ���[�J���ϐ��̐錾�Ə�����
        float c = 0.45281f;

        // UIUtility�N���X��ConvertPercent���\�b�h���Ăяo��
        // �p�[�Z���g�\���ɕϊ�������������擾
        string d = UIUtility.ConvertPercent(c);



        // ���ʂ��R���\�[���ɕ\��
        Debug.Log($"3������,����ꂽ����:{b}");
        Debug.Log($"�p�[�Z���g�ɂȂ���������:{d}");
    }

}
