import { useParams } from "react-router-dom"
import axios from "axios";
import { useEffect, useState } from "react";

export default function Detail(){
    const {id} = useParams();
    const [product,setProduct] = useState({});
    const _getDetail = async () => {
        const URL = `https://dummyjson.com/products/${id}`;
        try{
            const rs = await axios.get(URL); //auto convert to json
            setProduct(rs.data)
        }catch(error){
            console.log(error)
        }
    }

    useEffect(() => {
        _getDetail();
    });
    
    return(
        <div className="container">
            <h1>{product.tittle}</h1>
            <img src={product.thumbnail} />
            <p>{product.price}</p>
            <p>{product.description}</p>
        </div>
    )
}