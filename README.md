# Gesbanc
How to run the project: 

1) GesBanc.Server -> AppSettings.json:

Change ConnectionString to the desired (the Initial Catalog is "gesbanc" by default).

2) Open Package Admin Console:

  a) Select Gesbanc.Infrastructure as default project.
  b) execute: "update-database" to migrate database structure and example data.

3) Compile and run the Project with "Gesbanc.Server" as default.

Notes:

* Added some Unit testing with MSTest.
* Added JWT authentication.
* Added Automapper.
* Swagger:
  - Added swagger, to access go to the next url: https://localhost:44313/swagger
  - It has security by default. To proceed with, go to "Security" controller and log in as: 
    - username: test  
    - password: 098f6bcd4621d373cade4e832627b4f6
    
    It will return the token auth, copy this token in "Authorise" button, located at the top, including the word "bearer" before the token.
    i.e.: "bearer xxxtokenxxxx" (without quotes)

