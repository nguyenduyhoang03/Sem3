// index.js
const express = require('express');
const app = express();
const port = 2305;
const connectDB = require('./config/db/database');

app.use(express.static("public"));

app.get("/", (req, res) => res.send("hello word"));

app.listen(port, () => {
  console.log(`example app listening on port ${port}`);
  connectDB(); // Gọi hàm kết nối đến MongoDB
});
