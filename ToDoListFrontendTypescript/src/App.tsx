import React from 'react'
import Navbar from './components/navbar/Navbar'
import {Routes, Route} from 'react-router-dom'
import Home from './pages/home/Home.page'
import ToDos from './pages/todos/ToDos.page'
import AddTodo from './pages/todos/AddTodo.page'
import EditTodo from './pages/todos/EditTodo.page'
import DeleteTodo from './pages/todos/DeleteTodo.page'

const App: React.FC = () => {
  return (
    <div>
      {/* Navbar */}
      <Navbar />

      {/* Wrapper */}
      <div className="wrapper">
      {/* Routes */}
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/todos">
          <Route index element={<ToDos />} />
          <Route path="add" element={<AddTodo />} />
          <Route path="edit/:id" element={<EditTodo />} />
          <Route path="delete/:id" element={<DeleteTodo />} />
        </Route>
      </Routes>
      </div>
    </div>
  )
}

export default App