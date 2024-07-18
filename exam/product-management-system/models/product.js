// models/Product.js
const mongoose = require('mongoose');

const productSchema = new mongoose.Schema({
    ProductCode: String,
    ProductName: String,
    ProductDate: { type: Date, default: Date.now },
    ProductOriginPrice: Number,
    Quantity: Number,
    ProductStoreCode: String
});

module.exports = mongoose.model('Product', productSchema);
