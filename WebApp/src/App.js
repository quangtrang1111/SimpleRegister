import React, { useState, useEffect } from 'react';
import ReactJson from 'react-json-view'
import { Modal } from 'antd';
import 'antd/dist/antd.css';
import SignUpForm from './SignUpForm';
import logo from './logo.svg';
import './App.css';
import api from './apiService';

function App() {
  const [profile, setProfile] = useState(null)

  useEffect(() => {
    async function fetchAccountProfile() {
      try {
        const response = await api.get('api/Account');
        setProfile(response)     
      } catch (error) {}
    }

    fetchAccountProfile()
  }, []);

  const submitSignUp = async (values) => {
    try {
      await api.post('api/Account/SignUp', values);    
      
      Modal.confirm({
        title: 'Cool',
        content: 'Please check your email inbox (or spam) to verify your email',
        okText: 'Ok',
        cancelButtonProps: { hidden: true }
      });
    } catch (error) {
      Modal.confirm({
        title: 'NOT Cool',
        content: error,
        okText: 'Ok',
        cancelButtonProps: { hidden: true }
      });      
    }
  }

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        {profile
          ? <ReactJson src={profile} />
          : (
            <SignUpForm onSubmit={submitSignUp}/>
          )
        }        
      </header>
    </div>
  );
}

export default App;
