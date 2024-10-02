import userModel from '../model/users'
import moment from 'moment-timezone';
export const AuthLogin = async (req, res) => {
    try {

        const { username, password } = req.body;
        var data = await userModel.findOne({ username })

        if(!data){
            return res.status(201).json({
                status: 0,
                message: "Không tìm thấy tài khoản",
                users: {}
            })
        }
        if(password != data.password){
            return res.status(201).json({
                status: 0,
                message: "Tài khoản hoặc mật khẩu không chínhh xác",
                users: {}
            })
        }   
        const createdAtInVN = moment(data.createdAt).tz('Asia/Ho_Chi_Minh').format('YYYY-MM-DD HH:mm:ss');

        return res.status(201).json({
            status: 1,
            message: "Đăng nhập thành công",
            users: {
                fullname: data.fullname,
                username: data.username,
                email: data.email,
                phone: data.phone,
                permission: data.permission,
                id: data._id,
                createdAt: createdAtInVN 
            }
        })
    } catch (error) {
        console.log(error)
        return res.status(500).json({
            status: 1,
            message: error,
            users: {}
        })
    }
 }

 export const Register = async (req, res) => {
    try {

        
        var data = await userModel.create(req.body)

        if(data){
            return res.status(201).json({
                status: 1,
                message: "Thêm thành công"              
            })
        }else{
            return res.status(201).json({
                status: 0,
                message: "Thêm không thành công"              
            })
        }
       
    } catch (error) {
        return res.status(500).json({
            status: 0,
            message: error
        })
    }
 }

 export const GetUsers = async (req, res) => {
    try {
        var data = await userModel.find();
        return res.status(201).json(data)
        
    } catch (error) {
        return res.status(500).json({
            status: 0,
            message: error
        })
    }
 }
 export const DeleteUsers = async (req, res) => {
    try {
        const { username } = req.params; 
        
        const data = await userModel.findOneAndDelete({ username });
        if(data){
            return res.status(201).json({
                status: 1,
                message: "Successs"
            })
        }
        return res.status(201).json({
            status: 0,
            message: "Fail"
        })
        
    } catch (error) {
        return res.status(500).json({
            status: 0,
            message: error
        })
    }
 }

 export const EditUsers = async (req, res) => {
    try {
        const { username, fullname, phone, email, permission } = req.body;

        if (!username) {
            return res.status(201).json({ status: 0, message: "Username is required" });
        }

        const dataNew = {   
            fullname,
            phone,
            email,
            permission
        };

        console.log(dataNew);

        const data = await userModel.findOneAndUpdate(
            { username: username },
            dataNew,  
            { new: true }
        );
   
        if(data){
            return res.status(201).json({
                status: 1,
                message: "Successs"
            })
        }
        return res.status(201).json({
            status: 0,
            message: "Fail"
        })
    } catch (error) {
        return res.status(500).json({
            status: 0,
            message: error
        })
    }
 }