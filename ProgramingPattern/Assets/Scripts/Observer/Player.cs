//================================================================
// オブザーバー
// 観察される側 -> 何が起きたかのみ管理する
//================================================================

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ダメージオブザーバー用インターフェース
/// </summary>
public interface IDamage
{
    /// <summary>
    /// 継承先の子クラスで必ず実装
    /// </summary>
    void Damage(int currentHp);

    // interface
    // GameObjectとして存在できない
    // MonoBehaviourでもComponentでもない
    // -> newできない
    // -> 実体を持てない
    // 
    // GameObject
    // -> MonoBehaviour（実体）
    // 　 -> interface（役割）
}

/// <summary>
/// プレイヤー基本クラス
/// </summary>
public class Player : MonoBehaviour
{
    // ダメージメソッド呼び出し用オブザーバー
    private List<IDamage> damageObserver = new List<IDamage>();

    // プレイヤーHP
    private int hp = 0;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        hp = 50;
    }

    public void AddDamageObserver(IDamage iDamage)
    {
        damageObserver.Add(iDamage);
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ReceiveDamage(10);
        }
    }

    /// <summary>
    /// ダメージを受けたときの処理
    /// </summary>
    /// <param name="damage"> ダメージ量 </param>
    private void ReceiveDamage(int damage)
    {
        foreach (var observer in damageObserver)
        {
            observer.Damage(damage);
        }
    }
}

//===============================================================================
// オブザーバーのメリット
// 疎結合にできる
// 通知する側は誰が受け取るか、何をするかを知らなくていい
// とにかく通知するだけ
// -> エラー発生時に登録から外すだけでもエラーの確認ができる
//    -> 登録から外したことによるエラーは出ない
// 
// 機能追加に強い
// HPバー表示、効果音等を追加しても通知側の処理は一切変えなくていい
// ->登録するオブザーバーを増やすだけ
// 
// 「出来事」と「処理」を分離できる
// 状態変化は通知送信側
// それに対する反応処理はObserver側