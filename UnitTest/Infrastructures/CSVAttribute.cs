using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace UnitTest.Infrastructures
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CSVAttribute : DataAttribute
    {
        private readonly string _fileName;

        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="testMethod">メソッド情報？</param>
        /// <returns>データ配列</returns>
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var ENCODING_CODE = 932;
            var pars = testMethod.GetParameters();
            var parameterTypes = pars.Select(par => par.ParameterType).ToArray();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using var _reader = new CsvReader(new StreamReader(_fileName, Encoding.GetEncoding(ENCODING_CODE)), new CsvConfiguration(CultureInfo.CurrentCulture) { HasHeaderRecord = true });

            // ヘッダ行読み飛ばし
            _reader.Read();

            while (_reader.Read())
            {
                var q = new object[parameterTypes.Length];

                for (var i = 0; i < parameterTypes.Length; i++)
                {
                    q[i] = _reader.GetField(i);
                }
                yield return q;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public CSVAttribute(string fileName)
        {
            _fileName = fileName;
        }
    }
}