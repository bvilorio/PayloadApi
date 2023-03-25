# PayloadApi

Assesment
1.After cloning the repo. From visual studio make sure you set the configuration like below: DEBUG, ANY CPU, IIS Express

2.Start debugging the project.

3.Open Postman and set request type to POST, and the endpoint to https://localhost/api/robots/closest

4.Click on "body" the "raw", on the drop sown select JSON. In the request body include json like below: { "loadId": 231, "x": 5, "y": 3 } make sure to include these 3 properties, Values you can alter.

5.	Hit send. You should get a reponse body with the robot ID,Distance and Battery life of the closest and powerful robot.


If I had more time, I would add things like error handling for the controller. I would add a lot more comments to help other developers and I who will use the project in the future. I would probably abstract the provider some more also.
Overall this was a fun project!
