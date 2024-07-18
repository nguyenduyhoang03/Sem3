// controllers/productController.js
const Product = require('../models/Product');

// Add new product
exports.addProduct = async (req, res) => {
    const product = new Product({
        ProductCode: req.body.ProductCode,
        ProductName: req.body.ProductName,
        ProductDate: req.body.ProductDate,
        ProductOriginPrice: req.body.ProductOriginPrice,
        Quantity: req.body.Quantity,
        ProductStoreCode: req.body.ProductStoreCode
    });
    await product.save();
    res.redirect('/products/manage');
};

// Delete a product
exports.deleteProduct = async (req, res) => {
    await Product.findByIdAndDelete(req.params.id);
    res.redirect('/products/manage');
};

// Display all products with sorting
exports.getAllProducts = async (req, res) => {
    const sortOrder = req.query.sortOrder === 'asc' ? 1 : -1;
    const products = await Product.find().sort({ ProductStoreCode: sortOrder });
    res.render('products/manage', { products, sortOrder: req.query.sortOrder });
};
