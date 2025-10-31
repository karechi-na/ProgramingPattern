using UnityEngine;

/// <summary>
/// 動作確認用クラス
/// </summary>
public class TestScripts : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ローカル変数の宣言と初期化
        int a = 1234567890;

        // UIUtilityクラスのNumberFormatterメソッドを呼び出し
        // 3桁ごとに,を入れた文字列を取得
        string b = UIUtility.NumberFormatter(a);



        // ローカル変数の宣言と初期化
        float c = 0.45281f;

        // UIUtilityクラスのConvertPercentメソッドを呼び出し
        // パーセント表示に変換した文字列を取得
        string d = UIUtility.ConvertPercent(c);



        // 結果をコンソールに表示
        Debug.Log($"3桁ずつ,を入れた数字:{b}");
        Debug.Log($"パーセントになおした数字:{d}");
    }

}
