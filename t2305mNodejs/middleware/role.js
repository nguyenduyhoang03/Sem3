exports.role_admin =(req, res, next) => {
    const auth = req.session.user;

    if(auth) {
        const role = auth.role;
        if(role == "admin") {
            next();
            return;
        }
    } 
    res.status(404).send("404 not found");
}