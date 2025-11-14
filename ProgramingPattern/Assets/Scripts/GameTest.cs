using UnityEngine;

/// <summary>
/// シングルトン確認用スクリプト
/// </summary>
public class GameTest : MonoBehaviour
{
    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // Aキーを押したとき
        if (Input.GetKeyDown(KeyCode.A))
            // コンソールに表示
            // Instance{get;}でタイプ取得などをする
            GameManager.Instance.OutputTestDebugLog();

        // Sキーを押したとき
        if (Input.GetKeyDown(KeyCode.S))
            // GameManagerのint型変数testNumberに1加算
            GameManager.Instance.testNumber++;
    }
}
