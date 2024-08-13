import { useState } from "react"
import { Form } from 'react-bootstrap';
import { Button } from 'react-bootstrap';


export default function Account(){
    const [Account, setAccount] = useState({
        fullname: "",
        telephone: "",
        email: "",
        address: "",
        password: ""
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setAccount({
            ...Account,
            [name]: value
        });
    }
    
    const handleSubmit = () => {

    }
    
    return (
        <div className="container">
            <Form onSubmit={handleSubmit}>
                <h1>Register</h1>
                <Form.Group className="mb-3" controlId="formBasicFullname">
                    <Form.Label>Full Name: {Account.fullname}</Form.Label>
                    <Form.Control 
                        name="fullname" 
                        onChange={handleChange} 
                        value={Account.fullname} 
                        type="text" 
                        placeholder="Enter fullname" 
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicPassword">
                    <Form.Label>Password</Form.Label>
                    <Form.Control 
                        name="password" 
                        onChange={handleChange} 
                        value={Account.password} 
                        type="password" 
                        placeholder="Password" 
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicTelephone">
                    <Form.Label>Telephone: {Account.telephone}</Form.Label>
                    <Form.Control 
                        name="telephone" 
                        onChange={handleChange} 
                        value={Account.telephone} 
                        type="number" 
                        placeholder="Enter telephone" 
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Email {Account.email}</Form.Label>
                    <Form.Control 
                        name="email" 
                        onChange={handleChange} 
                        value={Account.email} 
                        type="email" 
                        placeholder="Enter email" 
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicAddress">
                    <Form.Label>Address {Account.address}</Form.Label>
                    <Form.Control 
                        name="address" 
                        onChange={handleChange} 
                        value={Account.address} 
                        type="text" 
                        placeholder="Enter address" 
                    />
                </Form.Group>

                <Button variant="primary" type="submit">
                    Submit
                </Button>
            </Form>

        </div>
    )
}