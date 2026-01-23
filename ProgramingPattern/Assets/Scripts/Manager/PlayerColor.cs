using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの色を変更するクラス
/// </summary>
public class PlayerColor : MonoBehaviour
{
    [Header("プレイヤーとなるイメージ")]
    [SerializeField] private Image playerImage = null;

    /// <summary>
    /// プレイヤーのイメージの色を変更する
    /// </summary>
    public void ChangeColor(Color color)
    {
        // 引数の色に変更
        playerImage.color = color;
    }
}
