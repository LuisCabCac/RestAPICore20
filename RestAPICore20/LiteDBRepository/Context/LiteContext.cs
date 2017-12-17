using LiteDB;
using System;

namespace RestAPICore20.NoSQL.LiteDB.Context
{
    public class LiteDBInstance<T>
    {
        protected static LiteDBInstance<T> instance;

        private static string connectionString = "MyData.db";
        private static LiteDatabase liteClient;

        private LiteDBInstance()
        {
            {
                liteClient = new LiteDatabase(connectionString);
            }
        }

        /// <comentarios/>
        public static LiteDBInstance<T> Instance
        {
            get
            {
                if (LiteDBInstance<T>.instance == null)
                {
                    LiteDBInstance<T>.instance = new LiteDBInstance<T>();
                }

                return LiteDBInstance<T>.instance;
            }
        }

        public LiteCollection<T> GetMongoDatabase(string DatabaseName)
        {

            return liteClient.GetCollection<T>(DatabaseName);

        }


        public static void SetConguration(string _connectionString)
        {

            connectionString = _connectionString;

        }
    }
   
}