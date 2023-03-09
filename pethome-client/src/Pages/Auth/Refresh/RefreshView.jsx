import React, { useState } from 'react';
import AuthService from '../../../HTTP/AuthService';

export default function RefreshView() {
  const [responseText, setResponseText] = useState('');

  const handleSubmit = async (event) => {
    event.preventDefault();

    const storedToken = localStorage.getItem('refresh')
    if (!storedToken) {
        alert("You are not logged in!")
        return      
    }

    AuthService.refresh(storedToken).then(data => {
      setResponseText('Refreshed')
      localStorage.setItem('access', data.data.access)
      localStorage.setItem('refresh', data.data.refresh)
    }).catch(error => {
      setResponseText(`Error: ${JSON.stringify(error.response.data)}`)
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
        <h3>Refresh</h3>
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
        >Refresh</button>
      </form>

      <div>
        <h2>Response:</h2>
        <p style={{ overflowWrap: 'anywhere', backgroundColor: 'white', borderRadius: '5px', boxShadow: '0px 2px 4px rgba(0, 0, 0, 0.25)' }}>{responseText}</p>
      </div>
    </div>
  );
}