using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Models
{
    public static partial class Utility
    {
        /// <summary>指定のパスまでのディレクトリを作成する</summary>
        /// <param name="path">指定パス</param>
        public static void MakeDirectory(string path)
        {
            var dir = Path.GetPathRoot(path);
            var exroot = Regex.Match(path, @"^.+:\\(?<s>.+)").Groups["s"].Value;
            foreach (var item in Path.GetDirectoryName(exroot)?.Split(new char[] { '\\' }) ?? Array.Empty<string>())
            {
                if (dir == null || item == null) continue;
                dir = Path.Combine(dir, item);
                Directory.CreateDirectory(dir);
            }
        }

        /// <summary>ベースディレクトリのパスを取得</summary>
        /// <returns>ベースディレクトリ</returns>
        public static string GetBaseDirectory()
        {
            return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) ?? Directory.GetCurrentDirectory();
        }
    }
}