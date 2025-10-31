
/// <summary>
/// UI���[�e�B���e�B�N���X
/// </summary>
public static class UIUtility
{
    /// <summary>
    /// 3�����ƂɁu,�v��}������������𐶐����郁�\�b�h
    /// </summary>
    public static string NumberFormatter(int number)
    {
        // 3�����ƂɃJ���}��}��
        // # �͌����Ȃ��ꍇ�\�����Ȃ��A0�͌����Ȃ��ꍇ0��\������
        // , ��3�����Ƃɋ�؂�
        return number.ToString("#,0");
    }

    /// <summary>
    /// ���l���p�[�Z���g�\���ɕϊ�(������2�ʂ܂�)���郁�\�b�h
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        // �󂯎����������100�{����
        float convertRatio = ratio * 100.0f;

        // �l�̌ܓ���������2�ʂ܂ŕ\��
        // F2 �͏�����2�ʂ܂ŕ\�����鏑���w��q
        // �߂�l�Ɂu%�v��t�^���ĕԂ�
        return convertRatio.ToString("F2") + "%";
    }
}
