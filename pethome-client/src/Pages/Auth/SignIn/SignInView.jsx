import React, { useState } from 'react';
import { MyInput } from '../../../../src/UI/Inputs/MyInput'
import AuthService from '../../../HTTP/AuthService';

export default function SignInView() {
  const [formData, setFormData] = useState({ email: '', password: '' });
  const [responseText, setResponseText] = useState('');

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData(prevState => ({ ...prevState, [name]: value.trim() }));
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!formData.email.trim() || !formData.password.trim()) {
        alert('Please fill in all fields');
        return;
    }

    AuthService.signIn(formData).then(data => {
      setResponseText(`Sign in successful: ${JSON.stringify(data.data)}`);
      localStorage.setItem('access', data.data.access)
      localStorage.setItem('refresh', data.data.refresh)
      console.log(localStorage.getItem('access'), localStorage.getItem('refresh'))
    }).catch(error => {
      setResponseText(`Error: ${JSON.stringify(error.response.data)}`);
    });
  };

  return (
    <div style={{
      width: '450px',
      margin: '50px auto 0 auto',
      backgroundColor: '#f5f5f5',
      border: '1px solid #ccc',
      padding: '20px',
      borderRadius: '10px'
    }}>
    <form onSubmit={handleSubmit}>
        <h3>Sign in</h3>

        <label htmlFor="email">Email:</label>
        <MyInput type="email" id="email" name="email" value={formData.email} onChange={handleChange} />

        <label htmlFor="password">Password:</label>
        <MyInput type="text" id="password" name="password" value={formData.password} onChange={handleChange} />

        <button 
        type="submit"
        style={{
          display: 'block',
          margin: '20px auto',
          padding: '10px 20px',
          backgroundColor: '#0077ff',
          color: '#fff',
          borderRadius: '5px',
          border: 'none',
          boxShadow: '0 3px 6px rgba(0, 0, 0, 0.16)'
        }}
        >Submit</button>
      </form>

      <div>
        <h2>Response:</h2>
        <p style={{ overflowWrap: 'anywhere', backgroundColor: 'white', borderRadius: '5px', boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.25)' }}>{responseText}</p>
      </div>
    </div>
  );
}