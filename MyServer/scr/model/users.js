import mongoose from "mongoose";

const userTable = new mongoose.Schema({
    fullname:{
        type: String,
        require: true,          
    },
    username:{
        type: String,
        require: true,  
        unique: true,   
    },
    password:{
        type: String,
        require: true,  
    },
    email:{
        type: String,
        require: true,  
        unique: true
    },
    phone:{
        type: String,
        require: true,  
    },
    permission:{
        type: Number,
        require: true,  
        default: 0,      
    },
}, {timestamps: true, versionKey: false});

export default mongoose.model("userModel", userTable, "users")