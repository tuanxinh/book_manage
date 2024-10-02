import express from 'express'
import { DeleteBook, EditBook, getBooks, insertBook } from '../controller/books';

const Books = express.Router();



Books.get('/get', getBooks)

Books.post('/register', insertBook)

Books.put('/edit', EditBook);
Books.delete('/del/:title', DeleteBook);
export default Books;