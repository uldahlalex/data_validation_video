import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [name, setName] = useState("Bobby")

  return (
    <>
        {
            name.length < 3 && <div>Name is not valid</div>
        }
        <input onChange={e => setName(e.target.value)} value={name} />
        <button disabled={name.length < 3} onClick={() => {
          fetch('http://localhost:5269/users',
              {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({name: name})
              }
              )
      }}>Send!</button>
    </>
  )
}

export default App
