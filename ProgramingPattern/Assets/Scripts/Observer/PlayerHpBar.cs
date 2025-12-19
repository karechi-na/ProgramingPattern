//================================================================
// オブザーバー
// 観察者側 -> 観察対象で起こったことに対して自身で処理する
//================================================================

using UnityEngine;

/// <summary>
/// プレイヤーHPバークラス
/// </summary>
public class PlayerHpBar : MonoBehaviour, IDamage
{
    [Header("Playerクラス")]
    [SerializeField] private Player player = null;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // オブザーバー登録
        player.AddDamageObserver(this);
        //---------------------------------------------
        // IDamage damage = this; ←キャスト
        // player.AddDamageObserver(damage);
        // ↑これを一行で済ませれる(暗黙的キャスト)
        //---------------------------------------------
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    // IDamageインターフェースに登録されているクラスを実行
    public void Damage(int currentHp)
    {
        Debug.Log("ダメージバー変更");
    }
}
