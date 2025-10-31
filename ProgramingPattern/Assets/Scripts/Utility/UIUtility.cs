
/// <summary>
/// UIユーティリティクラス
/// </summary>
public static class UIUtility
{
    /// <summary>
    /// 3桁ごとに「,」を挿入した文字列を生成するメソッド
    /// </summary>
    public static string NumberFormatter(int number)
    {
        // 3桁ごとにカンマを挿入
        // # は桁がない場合表示しない、0は桁がない場合0を表示する
        // , は3桁ごとに区切る
        return number.ToString("#,0");
    }

    /// <summary>
    /// 数値をパーセント表示に変換(少数第2位まで)するメソッド
    /// </summary>
    public static string ConvertPercent(float ratio)
    {
        // 受け取った引数を100倍する
        float convertRatio = ratio * 100.0f;

        // 四捨五入し少数第2位まで表示
        // F2 は少数第2位まで表示する書式指定子
        // 戻り値に「%」を付与して返す
        return convertRatio.ToString("F2") + "%";
    }
}
