namespace Models.Services
{
    /// <summary>計算インターフェース</summary>
    public interface ICalculation
    {
        /// <summary>合計算出</summary>
        /// <param name="a">対象A</param>
        /// <param name="b">対象B</param>
        /// <returns>計算結果</returns>
        
        public uint Sum(uint a, uint b);

        // メモ保存
        public bool SaveMemo(string value);
    }
}