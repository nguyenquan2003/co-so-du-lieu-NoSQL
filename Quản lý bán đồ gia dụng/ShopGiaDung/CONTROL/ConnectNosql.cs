using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Data;
using MongoDB.Bson;
namespace ShopGiaDung.CONTROL
{
    class ConnectNosql
    {
        public MongoClient connection()
        {
            // Chuỗi kết nối tới MongoDB
            string connectionString = "mongodb://localhost:27017";

            // Khởi tạo MongoClient
            MongoClient client = new MongoClient(connectionString);

            // Lấy tên MongoDB database
            return client;

        }

        public IMongoCollection<BsonDocument> Laycollection(string databaseName, string CollectionName)
        {
            IMongoDatabase database = connection().GetDatabase(databaseName);

            // Lấy reference tới collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(CollectionName);

            return collection;
        }


        public DataTable Load(string databaseName, string collectionName, List<string> columns = null)
        {
            // Kết nối tới MongoDB database
            IMongoDatabase database = connection().GetDatabase(databaseName);

            // Lấy reference tới collection
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);

            // Lấy dữ liệu từ collection
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();

            // Khởi tạo DataTable
            DataTable dataTable = new DataTable();

            // Tạo các cột cho DataTable chỉ từ các cột mong muốn
            foreach (var column in columns)
            {
                dataTable.Columns.Add(new DataColumn(column));
            }

            // Thêm dữ liệu vào DataTable
            foreach (var document in documents)
            {
                DataRow row = dataTable.NewRow();

                foreach (var column in columns)
                {
                    if (document.Contains(column))  // Kiểm tra nếu document chứa cột mong muốn
                    {
                        row[column] = document[column].ToString();
                    }
                }

                dataTable.Rows.Add(row);
            }

            // Trả về DataTable
            return dataTable;
        }
    }

}
