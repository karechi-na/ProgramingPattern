using UnityEngine;

/// <summary>
/// Managerパターン確認用クラス
/// </summary>
public class ManagerTest : MonoBehaviour
{
    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // プレイヤー名変更
        InGameUIManager.Instance.SetPlayerName("tanaka tarou");

        // プレイヤーカラー変更
        InGameUIManager.Instance.ChangeColor(Color.blue);
    }

}
