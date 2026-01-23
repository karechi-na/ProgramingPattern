using UnityEngine;
using TMPro;

/// <summary>
/// プレイヤーの名前を変更するクラス
/// </summary>
public class PlayerName : MonoBehaviour
{
    [Header("プレイヤー名テキストフィールド")]
    [SerializeField] private TMP_Text playerNameTextField = null;

    /// <summary>
    /// プレイヤー名設定
    /// </summary>
    public void SetPlayerName(string name)
    {
        // 引数の名前に変更
        playerNameTextField.text = name;    
    }
}
