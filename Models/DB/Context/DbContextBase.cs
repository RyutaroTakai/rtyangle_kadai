using Microsoft.EntityFrameworkCore;
using Models.DB.Tables;

namespace Models.DB.Context
{
    /// <summary>DBコンテキストのベースクラス</summary>
    public abstract class DbContextBase : DbContext
    {
        /// <summary>サンプルテーブル</summary>
        public DbSet<Sample> Samples => Set<Sample>();
    }
}