using System;
using System.Data.Entity;

namespace DataAccess.Repository.RepositoryDb
{
    public static class DbHelper
    {
        public static void DbInitialize(AutoServiceDb db, DatabaseConnectionAction connectionAction)
        {
            switch (connectionAction)
            {
                case DatabaseConnectionAction.Create:
                    Create(db);
                    break;
                case DatabaseConnectionAction.CreateIfNotExists:
                    CreateIfNotExists(db);
                    break;
                case DatabaseConnectionAction.Connect:
                    Connect(db);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(connectionAction), connectionAction, null);
            }
        }

        private static void Connect(AutoServiceDb db)
        {
            if (!db.Database.Exists())
                throw new DatabaseMissingException("�� ������� ����������� � ���� ������");
            //������� � LazyLoading. ����� ���������� ������� Cars �� ��.
        }


        private static void CreateIfNotExists(AutoServiceDb db)
        {
            db.Database.CreateIfNotExists();
        }

        private static void Create(AutoServiceDb db)
        {
            if (db.Database.Exists())
                db.Database.Delete();
            db.Database.Create();
        }
    }
}