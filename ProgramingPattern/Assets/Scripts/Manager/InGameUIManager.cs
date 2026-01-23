using UnityEngine;

/// <summary>
/// ゲームシーンで扱うUIを管理するマネージャークラス
/// </summary>
// Singletonを利用
public class InGameUIManager : SingletonMonobehaviour<InGameUIManager>
{
    [Header("プレイヤーカラークラス")]
    [SerializeField] private PlayerColor playerColor = null;

    [Header("プレイヤー名クラス")]
    [SerializeField] private PlayerName playerName = null;

    /// <summary>
    /// プレイヤーの色を変更する
    /// </summary>
    public void ChangeColor(Color color)
    {
        playerColor.ChangeColor(color);
    }

    /// <summary>
    /// プレイヤー名の変更
    /// </summary>
    public void SetPlayerName(string name)
    {
        playerName.SetPlayerName(name);
    }
}

// Managerクラスでは特定の処理は行わない
// ラッパークラス的立ち振る舞い
// 　→各機能を呼び出してあげるだけ
// 各シーンにシーン全体の管理クラスと、UI管理クラスの2つはあるといい


// ラッパークラス
// ・特定の機能を持ったクラスを保持しておくクラスのこと
// ・ラッパークラスを通じて各機能にアクセスしていく
//
// UIManager    ← UIManagerを通じて以下のクラスにアクセス
// |- PlayerHpGauge
// |- PlayerName
// |- SkillName


// Managerクラスのメリット
// ・責務の集中に依る管理のしやすさ
// 　→ オブジェクト生成、破棄、状態管理等を一元化できる
// 　→ 処理の流れが把握しやすくなる
// 
// ・コードの再利用性向上
// 　→ 共通ロジックをManagerにまとめることで重複を防げる
// 　→ 複数箇所から同じ管理処理を呼び出せる
// 
// ・変更に強くなる(疎結合化)
// 　→ 利用側は「どう管理されているか」を知らなくなる
// 　→ 実装変更の影響範囲をManager内に閉じ込めやすい
// 
// ・システム全体の見通しが良くなる
// 　→「何を管理するクラスか」が名前から明確
// 　→ 中～大規模開発で特に効果が大きい


// デメリット
// ・神クラスになりやすい
// 　→ 責務を詰め込みすぎると肥大化
// 　→ 可読性、保守性が低下
// 
// ・単一責任原則を破りやすい
// 　→「管理する」という言葉が曖昧で、役割が増えがち
// 　→ 設計意図が不明瞭になる可能性
// 
// ・依存関係が集中しやすい
// 　→ 多くのクラスが同じManagerクラスに依存すると修正が困難
// 　→ テストが書きづらくなる場合もある
// 
// ・設計の逃げになりやすい
// 　→ 「とりあえずManagerに入れる」という判断をしがち
// 　→ 本来は責務分割すべき処理が混在する


// うまく使うためのポイント
// ・Managerはひとつの明確な責務に限定する
// ・名前を明確にする
// 　→ × SystemManager
// 　→ 〇 UserSessionManager
// ・一定以上大きくなったら分割を検討する