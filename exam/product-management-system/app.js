// app.js
const express = require('express');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');
const app = express();

const productRoutes = require('./routes/products');

mongoose.connect('mongodb://localhost:27017/products');

app.set('view engine', 'ejs');
app.set('views', './views'); // Đảm bảo đường dẫn này là chính xác

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static('public'));

app.use('/products', productRoutes);

app.listen(3000, () => {
    console.log('Server is running on port 3000');
});
