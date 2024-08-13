import logo from './logo.svg';
import './App.css';
import Nav from './components/common/nav';
import { Route, Routes } from 'react-router-dom';
import Category from './components/common/page/category';
import Account from './components/common/page/account';
import index from './components/common/page';
import Product from './components/product';
import Detail from './components/common/page/detail';
import Home from './components/common/page/home';
import STATE from './context/initState';
import Context from './context/context';
import { UserProvider } from './context/context';
import { useState } from 'react';

//state
function App() {
  const [state,setState] = useState(STATE);
  return (
   <UserProvider value={{state,setState}}>
    <Nav/>
    <main>
      <Routes>
        <Route path = '/' Component={Product} />
        <Route path = '/category' Component={Category} />
        <Route path = '/account' Component={Account} />
        {/* <Route path='/product' Component={Product} /> */}
        <Route path='/product/:id' Component={Detail} />
      </Routes>   
    </main>
   </UserProvider>
  );
}

export default App;
