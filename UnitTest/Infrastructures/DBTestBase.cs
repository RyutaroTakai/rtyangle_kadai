using Models.DB.Context;
using System;

namespace UnitTest.Infrastructures
{
    /// <summary>DBのテスト用のベースクラス</summary>
    public abstract class DBTestBase : IDisposable
    {
        protected readonly DbContextBase dataContext;

        protected DBTestBase()
        {
            dataContext = new InMemorySQLiteDataContext();
            dataContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            dataContext.Dispose();
        }
    }
}