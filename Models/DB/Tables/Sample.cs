using System.ComponentModel.DataAnnotations;

namespace Models.DB.Tables
{
    /// <summary>サンプルテーブル</summary>
    public record Sample
    {
        /// <summary>ID</summary>
        [Key]
        public int ID { get; init; }

        /// <summary>データ</summary>
        public string Data { get; set; }

        
    }
}