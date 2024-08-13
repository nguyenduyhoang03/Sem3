import React, { useContext, useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import Context from '../context/context';

function Product(props) {
    const {state,setState} = useContext(Context);
    const [products, setProducts] = useState([]);

    const addToCart = () => {
        const cart = state.cart;
        cart.push(products);
        setState({...state,cart:cart});
    }

    const _getProduct = async () => {
            const URL = 'https://dummyjson.com/products?limit=12';
            let response = await fetch(URL);
            let data = await response.json();
            setProducts(data.products);
    }

    useEffect(() => {
        _getProduct();
    }, []);

    return (
        <div className='container'>
            <h1>Products</h1>
                <div className='row'>
                    {products.length > 0 ? (
                        products.map((product, key) => (
                            <div className='col-3 md-3 mb-3' key={key}>
                                <div className='card'>
                                    <img src={product.thumbnail} className='card-img-top' alt={product.title} />
                                    <div className='card-body'>
                                        <h5 className='card-title'>{product.title}</h5>
                                        <p className='card-text'>abcxyz</p>
                                        <Link to={`/product/${product.id}`} className='btn btn-primary'>Detail</Link>
                                        <a href='#' onClick={addToCart``} className='btn btn-primary'>Add To Cart</a>
                                    </div>
                                </div>
                            </div>
                        ))
                    ) : (
                        <p>No products available</p>
                    )}
                </div>
        </div>
    );
}

export default Product;
