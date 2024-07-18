const express = require("express");
const bodyParser = require('body-parser');
const session = require("express-session");
const app = express();
const port = 2305;

app.listen(port, function() {
    console.log("Server is running....");
});

app.use(bodyParser.urlencoded({ extended: true }));

// Set static files
app.use(express.static("public"));

// Set view engine
app.set("view engine", 'ejs');

// Session configuration
app.use(
    session({
        resave: true,
        saveUninitialized: true,
        secret: "t2305m",
        cookie: {
            maxAge: 600000,
            secure: false
        }
    })
);

// Connect to database
require("./model/database");

// Routes
const webrouter = require("./routes/web.route");
app.use("/", webrouter);

// Routes classroom 
const classroom_router = require("./routes/classroom.route");
app.use("/classroom", classroom_router);

// Authentication
const user_router = require("./routes/user.route");
app.use("/auth", user_router);
