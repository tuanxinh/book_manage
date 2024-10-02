
import timestamps from "mongoo/lib/plugins/timestamps";
import mongoose, { version } from "mongoose";

const manageTable = mongoose.Schema({
    masv: {
        type: String,
        unique: true,
        require: true
    },
    name: {
        type: String,
        require: true
    },
    phone: {
        type: String,
        require: true
    },
    nameclass: {
        type: String,
        require: true
    },
    bookborrow: {
        type: String,
        require: true
    },
    quantity: {
        type: Number,
        require: true
    },
    dateborrow: {
        type: Date,
        require: true
    },
    daterepay: {
        type: Date,
        require: true
    },
    status: {
        type: Number,
        require: true,
        default: 0
    },
}, { versionKey: false})

manageTable.index({masv: 1});

export default mongoose.model("bookManage", manageTable, "manage")