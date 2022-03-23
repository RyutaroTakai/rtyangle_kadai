using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Models.DB.Context
{
    /// <summary>インメモリSQLiteデータコンテキスト</summary>
    public sealed class InMemorySQLiteDataContext : DbContextBase
    {
        /// <summary>接続</summary>
        private SqliteConnection Connection { get; set; }

        /// <summary>破棄処理</summary>
        public override void Dispose()
        {
            base.Dispose();
            Connection?.Dispose();
        }

        /// <summary>設定情報の更新</summary>
        /// <param name="optionsBuilder">オプションビルダ</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Connection = new SqliteConnection("Filename=:memory:");
            Connection.Open();
            optionsBuilder.UseSqlite(Connection);
        }
    }
}