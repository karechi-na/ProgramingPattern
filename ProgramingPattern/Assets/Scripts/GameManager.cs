using UnityEngine;

/// <summary>
/// ゲーム管理クラス
/// </summary>
public class GameManager : SingletonMonobehaviour<GameManager>
{
    [Header("テスト用変数")]
    public int testNumber = 0;

    /// <summary>
    /// 外部からのコンソール表示用メソッド
    /// </summary>
    public void OutputTestDebugLog()
    {
        Debug.Log($"現在設定されているテスト変数 : {testNumber}");
    }
}
