
import bookModel from '../model/books'

export const getBooks = async (req, res) => {
    try
    {
        const data = await bookModel.find();
        return res.status(201).json(data)
    }
    catch(error){
        res.status(401).json({
            status: 0,
            message: error
        })
    }
}

export const insertBook = async (req, res) => {
    try
    {
        const data = await bookModel.create(req.body);
        if(data){
            return res.status(201).json({
                status: 1,
                message: "Successs",
            })
        }
        return res.status(201).json({
            status: 0,
            message: "Fail",
        })
    }
    catch(error){
        res.status(401).json({
            status: 0,
            message: error
        })
    }
}
export const DeleteBook = async (req, res) => {
    try {
        const { title } = req.params; 
        
        const data = await bookModel.findOneAndDelete({ title });
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

 export const EditBook = async (req, res) => {
    try {
        const { title, author, category, quantity } = req.body;

        if (!title) {
            return res.status(400).json({ status: 0, message: "Title not Found" });
        }

        const dataNew = {   
            author,
            category,
            quantity
        };

        console.log(dataNew);

        const data = await bookModel.findOneAndUpdate(
            { title: title },
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