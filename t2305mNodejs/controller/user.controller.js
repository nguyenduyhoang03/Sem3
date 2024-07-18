const User = require("./../model/user.model")
const bcrypt = require("bcryptjs");
const gmail = require("./../mail/gmail");
const nodeMailer = require("nodemailer");
const crypto = require('crypto');

exports.register = (req,res)=>{
    res.render("user/register");
}

exports.postRegister = async (req, res) => {
    try {
        const data = req.body;

        // Hash password
        const salt = await bcrypt.genSalt(10);
        const hashed = await bcrypt.hash(data.password, salt);
        data.password = hashed;

        const user = new User(data);
        await user.save();

        try {
            await gmail.sendMail({
                from: '"Markus Pham" <markuspham20@gmail.com>',
                to: user.email,
                subject: "Created Success!!",
                html: "<h1>Sign Up successfully!!</h1><br><p>Thank you for creating this account.</p>"
            });
        } catch (emailError) {
            console.error("Failed to send email:", emailError);
        }

        res.redirect("/");
    } catch (error) {
        res.status(400).send(error);
    }
};

exports.open_login = (req, res) => {
    res.render("user/login")
}

exports.show_reset_request = (req, res) => {
    res.render('user/reset_request'); // Make sure to create this view
};

// Handle the form submission
exports.reset_password_request = async (req, res, next) => {
    try {
        const { email } = req.body;
        const user = await User.findOne({ email });

        if (!user) {
            return res.status(400).send('User with that email does not exist.');
        }

        // Generate a token for password reset
        const token = crypto.randomBytes(20).toString('hex');

        // Set token and expiry on the user model (adjust fields accordingly)
        user.resetPasswordToken = token;
        user.resetPasswordExpires = Date.now() + 3600000; // 1 hour
        await user.save();

        // Set up nodemailer (ensure you have correct credentials)
        const transporter = nodeMailer.createTransport({
            service: 'gmail',
            auth: {
                user: 'markuspham20@gmail.com',
                pass: 'vyjg qwyl wtbx prlh', // Use environment variables for security
            },
        });

        const mailOptions = {
            from: '"Markus Pham" <markuspham20@gmail.com>',
            to: user.email,
            subject: 'Password Reset',
            html: `<h1>Password Reset</h1><br><p>Please click the following link to reset your password: <a href="http://${req.headers.host}/reset/${token}">Reset Password</a></p>`,
        };

        await transporter.sendMail(mailOptions);

        res.redirect('/');
    } catch (error) {
        next(error);
    }
};

exports.show_reset = async (req, res, next) => {
    try {
        const user = await User.findOne({
            resetPasswordToken: req.params.token,
            resetPasswordExpires: { $gt: Date.now() },
        });

        if (!user) {
            return res.status(400).send('Password reset token is invalid or has expired.');
        }

        res.render('user/reset', { user });
    } catch (error) {
        next(error);
    }
};

// Handle password reset form submission
exports.reset_password = async (req, res, next) => {
    try {
        const { token, password, confirmPassword } = req.body;

        if (password !== confirmPassword) {
            return res.status(400).send('Passwords do not match.');
        }

        const user = await User.findOne({
            resetPasswordToken: token,
            resetPasswordExpires: { $gt: Date.now() },
        });

        if (!user) {
            return res.status(400).send('Password reset token is invalid or has expired.');
        }

        // Update the user's password
        user.password = bcrypt.hashSync(password, 10);
        user.resetPasswordToken = undefined;
        user.resetPasswordExpires = undefined;
        await user.save();

        res.send('Password has been successfully reset.');
    } catch (error) {
        next(error);
    }
};

exports.postLogin = async (req, res) => {
    try {
        const { email, password } = req.body;

        // Check if email and password are provided
        if (!email || !password) {
            return res.status(400).send("Email and password are required.");
        }

        // Find the user by email
        const user = await User.findOne({ email });
        if (!user) {
            console.error(`User with email ${email} not found.`);
            return res.status(400).send("Invalid email or password.");
        }

        // Compare the provided password with the stored hashed password
        const isMatch = await bcrypt.compare(password, user.password);
        if (!isMatch) {
            console.error(`Password for user with email ${email} does not match.`);
            return res.status(400).send("Invalid email or password.");
        }

        // Set up the session (or use JWT)
        if (req.session) {
            req.session.user = user;
            res.redirect("/");
        } else {
            console.error("Session is not defined.");
            res.status(500).send("Session is not defined.");
        }
    } catch (error) {
        console.error("Server error:", error);
        res.status(500).send("Server error.");
    }
};