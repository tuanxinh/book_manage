
import mongoose from "mongoose";

const bookTable = mongoose.Schema({
    title: {
        type: String,
        require: true,
        unique: true
    },
    author: {
        type: String,
        require: true
    },
    category: {
        type: String,
        require: true
    },
    quantity: {
        type: Number,
        require: true
    },
}, {timestamps: true, versionKey: false});

export default mongoose.model("bookModel", bookTable, "books");