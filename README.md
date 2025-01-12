# crudDapper - docs

# User Management API Documentation

This API provides endpoints for managing users in the system. It allows for creating, reading, updating, and deleting user records. Each user has a set of attributes such as NomeCompleto (Full Name), Email, Cargo (Position), Salario (Salary), CPF (Brazilian Identification Number), and Situacao (Status). The API is designed to be simple and intuitive, supporting the basic CRUD (Create, Read, Update, Delete) operations.
</br>
<b>Base URL</b>
</br>
The base URL for the API is: http://localhost:5162/api/usuario/
</br>
<h3>Endpoints Overview:</h3>
<ul>
  <li>POST /create: Adds a new user to the system.</li>
  <li>GET /readAll: Retrieves all users from the database.</li>
  <li>PUT /update: Updates the details of an existing user.</li>
  <li>DELETE /delete: Deletes a user from the system.</li>
  <li>GET /findById: Fetches a user by their ID.</li>
</ul>

Each endpoint requires specific parameters in the request body (for POST, PUT, and DELETE), or query parameters (for GET), and returns relevant data or a success/failure status.
This documentation provides a detailed description of each endpoint, including request examples and expected responses. You can use it to interact with your API via tools like Postman or any HTTP client.
</br><hr></br>
## Exemples
# Create
<pre><code>http://localhost:5162/api/usuario/create</code></pre>
<p>Creates a new user in the database. This endpoint requires the new user's details to be provided in the request body. Upon creation, a new user will be added, and a success status will be returned.</p>
<h3>Body</h3>
<pre><code>
  {
    "NomeCompleto" : "Ramadan 6",
    "Email" : "ramadan6@gmail.com",
    "Cargo" : "FullStack6",
    "Salario" : 9996.0,
    "CPF" : "1233ds326",
    "Situacao" : true,
    "Senha" : "1234566"
  }
</code></pre>
</br><hr></br>

# ReadAll
<pre><code>http://localhost:5162/api/usuario/readAll</code></pre>
<p>Fetches all the users registered in the database. This endpoint returns a list of all users, including information like name, email, position, salary, etc.</p>
</br><hr></br>

# Update
<pre><code>http://localhost:5162/api/usuario/update</code></pre>
<p>Updates the details of an existing user based on the provided ID. This endpoint allows you to modify information such as name, email, position, salary, etc. The new user details should be sent in the request body along with the user's ID.</p>
<h3>Body</h3>
<pre><code>
  {
    "id": 6,
    "nomeCompleto": "Ramadan 16",
    "email": "ramadan16@gmail.com",
    "cargo": "FullStack6",
    "salario": 9996,
    "situacao": false
  }
</code></pre>
</br><hr></br>

# Delete
<pre><code>http://localhost:5162/api/usuario/delete</code></pre>
<p>Deletes an existing user from the database based on the provided ID. This endpoint requires the user's ID to be sent in the request body.</p>
<h3>Body</h3>
<pre><code>
  {
    "id" : 4
  }
</code></pre>
</br><hr></br>

# FindById
<pre><code>http://localhost:5162/api/usuario/findById</code></pre>
<p>Fetches a specific user by the provided ID. This endpoint returns the full details of the user corresponding to the given ID.</p>
<pre><code>
  {
    "id" : 3
  }
</code></pre>
