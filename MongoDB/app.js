const express = require('express'); // Nhập module Express để xây dựng ứng dụng web
const { connectToDb, getDb } = require('./db'); // Nhập các hàm từ module db để kết nối và lấy đối tượng cơ sở dữ liệu
const { ObjectId } = require('mongodb')

// init app & middleware
const app = express() //khởi tạo một ứng dụng Express mới và gán nó vào biến app.
app.use(express.json())

//db connection
let db
connectToDb((err) => {
          if (!err) {
                    app.listen(3000, () => { //khởi động máy chủ trên cổng 3000. Hàm callback () => {} là rỗng và sẽ được thực thi khi máy chủ khởi động thành công
                              console.log('app listening on port 3000') //hiển thị thông báo và lắng nghe trên cổng 3000  
                    })
                    db = getDb() // lấy đối tượng kết nối cơ sở dữ liệu từ hàm getDb()
          }
})


//Lấy danh sách sách
app.get('/books', (req, res) => { //chỉ ra rằng khi có một yêu cầu GET được gửi đến /books, hàm callback được cung cấp sẽ được thực thi. Hàm callback nhận hai tham số: req (đối tượng yêu cầu) và res (đối tượng phản hồi).
          let books = []
          const page = req.query.p || 0
          const booksPerPage = 3
          db.collection('books')
                    .find()
                    .sort({ author: 1 })
                    //phân trang
                    .skip(page * booksPerPage)
                    .limit (booksPerPage)
                    .forEach(book => books.push(book))
                    .then(() => {
                              res.status(200).json(books)
                    })
                    .catch(() => {
                              res.status(500).json({ error: 'could not fetch the documents' })
                    })

})

//Lấy chi tiết một cuốn sách
app.get('/books/:id', (req, res) => {
          if (ObjectId.isValid(req.params.id)) {
                    db.collection('books')
                              .findOne({ _id: new ObjectId(req.params.id) })
                              .then(doc => {
                                        res.status(200).json(doc)
                              })
                              .catch(err => {
                                        res.status(500).json({ error: 'could not fetch the document' })
                              })
          }
          else {
                    res.status(500).json({ error: 'not a valid doc id' })

          }
})
//Thêm một cuốn sách mới
app.post('/books', (req, res) => {
          const book = req.body

          db.collection('books')
                    .insertOne(book)
                    .then(result => {
                              res.status(201).json(result)
                    })
                    .catch(err => {
                              res.status(500).json({ err: 'could not create a new document' })
                    })
})
//Xóa một cuốn sách
app.delete('/books/:id', (req, res) => {
          if (ObjectId.isValid(req.params.id)) {
                    db.collection('books')
                              .deleteOne({ _id: new ObjectId(req.params.id) })
                              .then(result => {
                                        res.status(200).json(result);
                              })
                              .catch(err => {
                                        res.status(500).json({ error: 'could not delete the document' });
                              });
          } else {
                    res.status(500).json({ error: 'not a valid doc id' });
          }
});

//Cập nhật một cuốn sách
app.patch('/books/:id', (req, res) => {
          const updates = req.body;

          if (ObjectId.isValid(req.params.id)) {
                    db.collection('books')
                              .updateOne({ _id: new ObjectId(req.params.id) }, { $set: updates }) // Corrected line
                              .then(result => {
                                        res.status(200).json(result);
                              })
                              .catch(err => {
                                        res.status(500).json({ error: 'could not update the document' });
                              });
          } else {
                    res.status(500).json({ error: 'not a valid doc id' });
          }
});
