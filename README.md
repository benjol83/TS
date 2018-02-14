# TS
Swagger framework is added to test this project, if you manage to run it in VS, you can go to (http://localhost:27417/swagger) to see what are the api availables and test the api directly via swagger.
Unity Dependency Injection framework is used to make components more testable
Some limitations due to time constraints:
- At the moment the data is stored locally in a dictionary instead of database due to time constraint but it is designed to be replaceable with more suitable storage solution. Ideally it should be stored in a sql db instead of plain dictionary to make it scalable.
- GetIssues api is now pulling all of the issues at once, ideally there should be pagination implemented to make it more performant.
- SearchIssues api is returning all possible matches at once based on (if there is any title containing a particular string && priority match && status match && assignedTo containing a particular string), ideally there should be pagination implemented to make it performant. It can also be made more sophisticated, e.g.: make criterias with 'OR'/'AND' clause.
- DeleteIssue can handle only 1 item at a time, ideally it need to handle multiple item at once so that it will be more scalable.
