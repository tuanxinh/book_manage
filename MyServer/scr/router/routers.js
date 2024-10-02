
import express from 'express';
import { AuthLogin, DeleteUsers, EditUsers, GetUsers, Register } from '../controller/users';

const router = express.Router();

router.post('/login', AuthLogin);
router.post('/register', Register);

router.get('/get', GetUsers);
router.put('/edit', EditUsers);
router.delete('/del/:username', DeleteUsers);

export default router;