const mongoose = require("mongoose");

const class_schema = new mongoose.Schema({
    name: {
        type: String,
        unique: true,
        required: true
    },
    program_code: {
        type: String,
        required: true,
        validate: {
            validator: (v)=>{
               const reg = '';
               return true;     
            },
            message: (t)=> ``
        }
    },
    room: String,
    students: [
        {
           type: mongoose.Schema.Types.ObjectId,
           ref: "Student"    
        }
    ]
});
module.exports = mongoose.model("Classroom",class_schema);