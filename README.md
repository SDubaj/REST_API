# Requirements to test the project:
1. Any API client, which allows to test APIs (e.g Postman etc.)
2. IDE, which allows to run .NET Core project (e.g. Visual Studio 2019 etc.)

# How to test the REST API ? 

1. Download project from github to your computer.
2. Unzip the package with files.
3. Run file named "RESTAPI.sln" with VS 2019.
4. When project is ready, build and run it.
5. Run Postman to add new word to collection.
6. Choose POST request, then enter URL e.g. https://localhost:YOUR_PORT/api/Words
7. ![image](https://user-images.githubusercontent.com/38839364/110171680-5e2a6780-7dfc-11eb-8963-ed2fe959ae1e.png)
8. In body, enter: { "name" : "<AnyWord> } and press SEND to create new object with id and any word you wan(you can do it how many times you want)
9. If you want to check existing data, change request to GET, and enter suitable URL e.g.:
      - https://localhost:44367/api/Words - to get all existing words,
      - https://localhost:44367/api/Words/{id} - to get object with exact id,
      - https://localhost:44367/api/Words/numberOf/{name} - to get the number of appearances of the word in collection,
      - https://localhost:44367/api/Words/unique - to get all unique words from collection,
    you can also enter these URLs in the browser.
10. If you want to DELETE any object from collection, choose DELETE request and enter URL with id of object you want to delete, e.g.: https://localhost:44367/api/Words/{id}.


