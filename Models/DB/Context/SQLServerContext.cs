using Microsoft.EntityFrameworkCore;

namespace Models.DB.Context
{
    /// <summary>SQLServerのDBコンテキスト</summary>
    public sealed class SQLServerContext : DbContextBase
    {
        /// <summary>接続文字列</summary>
        private readonly string connectionString;

        /// <summary>コンストラクタ</summary>
        public SQLServerContext()
        {
            // マイグレーション用
        }

        /// <summary>コンストラクタ</summary>
        /// <param name="settings">設定</param>
        public SQLServerContext(Settings settings)
        {
            connectionString = settings.ConnectionString;
        }

        /// <summary>設定値の変更</summary>
        /// <param name="optionsBuilder">オプション構成オブジェクト</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (connectionString == null)
            {
                // マイグレーション用。接続文字列はコマンドで指定
                optionsBuilder.UseSqlServer();
            }
            else
            {
                optionsBuilder.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60));
            }
        }
    }
}