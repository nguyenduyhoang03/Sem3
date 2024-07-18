// routes/products.js
const express = require('express');
const router = express.Router();
const productController = require('../controllers/productController');

// Add new product
router.post('/add', productController.addProduct);

// Delete a product
router.post('/delete/:id', productController.deleteProduct);

// Display all products
router.get('/', (req, res) => {
    res.render('products/index');
});

// Display manage products page with sorting
router.get('/manage', productController.getAllProducts);

// Display add product page
router.get('/add', (req, res) => {
    res.render('products/add');
});

module.exports = router;
