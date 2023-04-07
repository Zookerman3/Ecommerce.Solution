# Ecommerce Website

#### An Ecommerce website utilizing an Api to store products and product information.

#### By Zachary Cipolletta, Stephen Zook & James Provance

## Technologies Used

* C#
* .Net 6
* HTML
* JavaScript
* JSON
* SQL
* EFCore
* Identity
* Authentication

## Description


## Setup/Installation Requirements

1. Clone this repo.
2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory named "E-Commerce_website".
3. Create a file named ['appsettings.json'] in the production directory (ParksLookup) and include a new database connection string. The string should be as follows:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306[Or-Your-Desired-Port-Number];database=[DATABASE-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];",
  }
}

4. In the terminal type 'dotnet restore' to install the necessary packages for the application to run
5. Make sure you have MySql install on your local computer and then in the terminal type 'dotnet ef database update'
6. Run the application by typing in the terminal 'dotnet watch run'


## Known Bugs
*No known bugs at this time.

## License
MIT

Copyright (c) Zachary Cipolletta, Stephen Zook & James Provance

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