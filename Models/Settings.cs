using System;
using System.IO;
using Utf8Json;

namespace Models
{
    /// <summary>設定クラス</summary>
    public class Settings
    {
        /// <summary>アプリケーション名</summary>
        public string AppName { get; set; } = "メモ帳";

        /// <summary>接続文字列</summary>
        public string ConnectionString { get; set; }

        /// <summary>設定ファイル保存</summary>
        /// <param name="path">保存先</param>
        public void SaveJson(string path)
        {
            try
            {
                var j = JsonSerializer.ToJsonString(this);
                using var strm = new StreamWriter(path);
                strm.Write(j);
                strm.Flush();
            }
            catch (Exception)
            {
            }
        }
    }
}