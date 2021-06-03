$response = Invoke-RestMethod -Uri "http://localhost:3000/tasks" -Method Get
$response

$response = Invoke-RestMethod -Uri "http://localhost:3000/tasks/123" -Method Get
$response

$body = @{
    ProjectId = 1
    Title = "this is my first task"
    Description = "this is very strange!"
}
$jsonbody = ConvertTo-Json -InputObject $body

$response = Invoke-RestMethod -Uri "http://localhost:3000/tasks" -Method Post -ContentType 'application/json' -Body $jsonbody
$response

$bodyput = @{
    TicketId = 10
    ProjectId = 1
    Title = "this is my first task"
    Description = "this is very strange!"
}
$jsonbodyput = ConvertTo-Json -InputObject $bodyput

$response = Invoke-RestMethod -Uri "http://localhost:3000/tasks" -Method Put -ContentType 'application/json' -Body $jsonbodyput
$response

$response = Invoke-RestMethod -Uri "http://localhost:3000/tasks/123" -Method Delete
$response