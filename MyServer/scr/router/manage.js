
import express from 'express'

import {deleteManage, editManage, getManage, insertManage} from '../controller/manage'

const Manage = express.Router()

Manage.get('/get', getManage)
Manage.post('/register', insertManage)
Manage.put('/edit', editManage)

Manage.delete('/del/:username', deleteManage)

export default Manage;