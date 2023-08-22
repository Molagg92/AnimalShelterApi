# _It's Raining Cats n' Dogs!_

#### _An attempt to create an API using an Animal Shelter_

#### By Erik Z./Molagg92

## Technologies Used

* _C#_
* _.NET v6.0_
* _Git_
* _VSCode_

## API ENDPOINTS

* _GET: `http://localhost:5000/api/Cats`_
* _GET: `http://localhost:5000/api/Cats/{id}`_
* _POST: `http://localhost:5000/api/Cats`_
* _PUT: `http://localhost:5000/api/Cats/{id}`_
* _DELETE: `http://localhost:5000/api/Cats/{id}`_
* _GET: `http://localhost:5000/api/Cats/GetToken`_
===
* _GET: `http://localhost:5000/api/Dogs`_
* _GET: `http://localhost:5000/api/Dogs/{id}`_
* _POST: `http://localhost:5000/api/Dogs`_
* _PUT: `http://localhost:5000/api/Dogs/{id}`_
* _DELETE: `http://localhost:5000/api/Dogs/{id}`_
* _GET: `http://localhost:5000/api/Dogs/GetToken`_
* _``_

## Description

_For the most part, it has CRUD on both Cat and Dog side, Supposed to simulate an app for an Animal Shleter!_

## Setup/Installation Requirements

* _Clone "AnimalShelterApi" from the repository to your desktop_
* _Navigate to the AnimalShelterApi folder in your terminal_
* _Once inside the project folder "AnimalShelterApi", build an appsettings.json file, copy the following into it (replace the password with your server MySQL server password)_
* 
 ``` 
    {"ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=animalshelterapi;uid=root;pwd=[!Yourpassword!];"
    }
  }
```
* _After this, give commane `$ dotnet ef database update` for the databade_ 
* _Then type `dotnet build` in your terminal to make sure everything is up to date and there are no errors_
* _Then launch the webpage by typing `dotnet watch run --launch-profile "production"` in the teminal_
* _For issuing and trusting a security certificate, type `dotnet dev-certs https --trust` in the terminal and restart your browser_

## Known Bugs

* _Curretly this App doesnt not fully support JWT user auntentication/authorization. The app features full crud, and when checked through Postman the app correctly return 401 unauthorized error, but unfortunatly the keys tokens that are generated with /gettoken do not work, the user still gets the 401 unathorize error. making the epp a little unusable 8/18/2023_

## License

MIT License

Copyright (c) [2023] [Erik Z.]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

_If you run into any issues or have questions, ideas or concerns, please reach out to me via email: Molagg92@gmail.com.  Contributions to the code are highly encouraged._
