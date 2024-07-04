// const { MongoClient } = require('mongodb');
// let dbConnection;

// module.exports = {
//           connectToDb: (cb) => {
//                     MongoClient.connect('mongodb://localhost:27017/bookstore', { useNewUrlParser: true, useUnifiedTopology: true })
//                               .then((client) => {
//                                         dbConnection = client.db(); // Save the database connection
//                                         return cb(); // Callback without error
//                               })
//                               .catch(err => {
//                                         console.log(err);
//                                         return cb(err); // Callback with error
//                               });
//           },
//           getDb: () => dbConnection
// };

const { MongoClient } = require('mongodb');
let dbConnection;

module.exports = {
    connectToDb: (cb) => {
        MongoClient.connect('mongodb://localhost:27017/bookstore')
            .then((client) => {
                dbConnection = client.db(); // Save the database connection
                return cb(); // Callback without error
            })
            .catch(err => {
                console.log(err);
                return cb(err); // Callback with error
            });
    },
    getDb: () => dbConnection
};
