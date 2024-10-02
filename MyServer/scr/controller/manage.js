
import bookManage from '../model/manage'

export const getManage = async (req, res) => {
    try {
        const data = await bookManage.find()
        return res.status(201).json(data)
       
    } catch (error) {
        res.status(500).json({
            status: 0,
            message: error
        })
    }
}

export const insertManage = async (req, res) => {
    try {
        
        const data = req.body
        console.log(data);
        const dataInsert = {
            ...data,
            dateborrow: new Date(data.dateborrow)?? new Date(), // Use ISO format
            daterepay: new Date(data.daterepay)?? new Date(),  // Use ISO format
          };
        console.log(dataInsert)
        const result = await bookManage.create(dataInsert)

        if(result){
            return res.status(201).json({
                status: 1,
                message: "Successs"
            })
        }
        return res.status(401).json({
            status: 0,
            message: "Fail"
        })
    } catch (error) {
        res.status(500).json({
            status: 0,
            message: error
        })
    }
}
export const editManage = async (req, res) => {
    try {
        const data = req.body
        if(!data || !data.dateborrow || !data.daterepay){
            return res.status(201).json({
                status: 0,
                message: "Faill"
            })
        }
        if(data.status == 1){
            data.daterepay = new Date()
        }
        const dataInsert = {
            name: data.name,
            phone: data.phone,
            nameclass: data.nameclass,
            bookborrow: data.bookborrow,
            quantity: data.quantity,        
            dateborrow: new Date(data.dateborrow)?? new Date(), 
            daterepay: new Date(data.daterepay)?? new Date(),  
            status: data.status
          };
        console.log(dataInsert)
        const result = await bookManage.findOneAndUpdate(
           
            { masv: data.masv },
            dataInsert,
            { new: true }
        )
        if(result){
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
        res.status(500).json({
            status: 0,
            message: error
        })
    }
}
export const deleteManage = async (req, res) => {
    try {
   
        const { username } = req.params; 
        console.log(username)
        const data = await bookManage.findOneAndDelete({ masv: username })
        if(data){
            return res.status(201).json({
                status: 1,
                message: "Successs"
            })
        }
        return res.status(401).json({
            status: 0,
            message: "Fail"
        })
    } catch (error) {
        res.status(500).json({
            status: 0,
            message: error
        })
    }
}