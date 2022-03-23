using System.Text.RegularExpressions;

namespace Models
{
    /// <summary>
    /// string 拡張メソッド
    /// </summary>
    public static class StringExtension
    {
        /// <summary>空の文字列チェック</summary>
        /// <param name="str">ターゲット</param>
        /// <returns>
        /// true: 空
        /// false: 空ではない
        /// </returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>正規表現検索を行う</summary>
        /// <param name="str">文字列</param>
        /// <param name="pat">正規表現パターン</param>
        /// <param name="m">マッチ結果</param>
        /// <returns>
        /// true: マッチした
        /// false: マッチしなかった
        /// </returns>
        public static bool Match(this string str, string pat, out Match m)
        {
            m = null!;
            if (str.IsEmpty()) return false;
            m = Regex.Match(str, pat);
            return m.Success;
        }

        /// <summary>Emailアドレスか判定する</summary>
        /// <param name="str">文字列</param>
        /// <returns>
        /// true: Emailアドレス
        /// false: Emailアドレスではない
        /// </returns>
        public static bool IsEmailAddr(this string str)
        {
            return str.Match(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$", out var _);
        }

        /// <summary>文字列から最初に発見したEmailアドレスを抽出する</summary>
        /// <param name="str">文字列</param>
        /// <returns>Emailアドレス</returns>
        public static string GetEmailAddr(this string str)
        {
            return str.Match(@"(?<e>^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4})", out var m) ? m.Groups["e"].Value : "";
        }

        /// <summary>Emailの名前とメールアドレスを分離する</summary>
        /// <param name="str">文字列</param>
        /// <returns>名前とEmailの配列</returns>
        public static (string name, string mail) GetSplitEmail(this string str)
        {
            return str.Match("(?<name>.+?)<(?<mail>.+?)>", out var m) ? (m.Groups["name"].Value, m.Groups["mail"].Value) : ("", "");
        }

        /// <summary>文字列から整数を返す</summary>
        /// <param name="str">文字列</param>
        /// <param name="def">変換できなかった際に返す値</param>
        /// <returns>文字列の示す整数</returns>
        public static int ToInt(this string str, int def = 0)
        {
            if (str == null) return def;
            return int.TryParse(str.Trim(), System.Globalization.NumberStyles.AllowThousands, null, out int t) ? t : def;
        }
    }
}