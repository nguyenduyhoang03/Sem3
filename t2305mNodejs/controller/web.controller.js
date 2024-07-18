const Student = require("./../model/student.model");
const Classroom = require("./../model/classroom.model");
exports.student_get = async function(req,res){  
    // query
    let list = await Student.find().populate("classroom").exec();
    // res.sendFile(__dirname+"/views/home.html");
    let x =0;
    res.render("home",{
        students: list,
        count : x
    });
}
exports.form_new = async (req, res) => {
    const classes = await Classroom.find();
    res.render('new',{
      classes: classes
    });
  };

exports.save_student = async (req, res) => {
    try {
      const student = new Student(req.body);
      await student.save();
      res.redirect('/');
    } catch (error) {
      res.status(400).send(error);
    }
  }  