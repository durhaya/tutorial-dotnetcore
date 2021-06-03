const express = require('express');
const service = express();

service.listen(3000, () => {
    console.log("The server is running on port 3000");
});

service.get("/tasks", (req, res) => {
    res.send('Reading the tasks');
});

service.get("/tasks/:id", (req, res)=>{
    const {id} = req.params;
    res.send(`Reading the task #${id}`);
});

service.post("/tasks", (req, res)=>{
    res.send(`Creating the task.`);
});
service.put("/tasks", (req, res)=>{
    res.send(`updating the task.`);
});
service.delete("/tasks/:id", (req, res)=>{
    const {id} = req.params;
    res.send(`Deleting the task ${id}.`);
});