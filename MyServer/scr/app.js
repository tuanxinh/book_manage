
import express from 'express'
import morgan from 'morgan';
import Users from './router/routers';
import Books from './router/books';
import Manage from './router/manage';
import { connectDB } from './config/db';

const app = express()
app.use(morgan('dev'))
app.use(express.json())

connectDB('mongodb://localhost:27017/tuanxinh');

app.use('/users', Users)
app.use('/books', Books)
app.use('/manage', Manage)

export const viteNodeApp = app;