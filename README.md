## Introduction

This is a simple  API  that allows you to manage a list of todos. <br>

The application is built using the following technologies:

	* MySQL 8.0.41 (MySQL Community Server from Docker Hub)
	* ASP.NET Core 8.0
	* Nginx  (latest from Docker Hub)
	* Docker 27.4.0 (to compose the application)

## How The System Works

* MySQL Community Server runs externally as a Docker container.<br/>
* The API is built with .NET 8.0 and communicates with MySQL.
* Nginx acts as a reverse proxy, exposing the necessary ports to access the application.



## Build and run the project in detached mode from your local computer
```
docker-compose up -d --build
```
## Check running containers
```
docker ps
```
## Check logs of a container
```
docker logd mysql_container
docker logs dotnet_api_container
docker logs nginx_container
```
## Stop running containers
```
docker-compose down
```
or 

```
docker stop mysql_container dotnet_api_container nginx_container
```
## Run containers again
```
docker start mysql_container dotnet_api_container nginx_container
```
## Access the API application
```	
http://localhost/api/todos
```
#### Methods

	 GET: Get all todos
		Example: http://localhost/api/todos
		 
	 GET: Get a todo by id
		Example: http://localhost/api/todos/1
		
	 POST: Create a new todo
	   Example:  {"id": 1, "title": "Todo 1",  "isComplete": false}
			
	 PUT: Update a todo
		Example: {"id": 1, "title": "Write README.md",  "isComplete": true}
	 
	 DELETE: Delete a todo
		Example: http://localhost/api/todos/1

	 TOGGLE: Toggle the status of a todo
		Example: api/todos/toggle/1
	   
## Access the MySQL database 

* From inside of the container

   ```docker exec -it mysql_container mysql -u myuser -p```
  
  Then run the following command to access the database

   ```
  SHOW DATABASES;
  USE todosdb;
   SHOW TABLES;
   ```

## External images

  * djamka/mysql
  * djamka/todosapi 
  * djamka/nginx

  ## Check all repositories
  ```
  docker ps -a
  ```
  #### Remove all conflicting containers and images
  ```
  docker compose down

  ```
  You can remove images and containers manually by running the following commands:
  ```
  docker rmi -f djamka/mysql:8.0 djamka/todosapi djamka/nginx
  docker rm -f mysql_container api_container nginx_container
  ```
  Names may vary depending on the name of the containers and images on your local machine.
 
 #### Pull from Docker Hub and run containers on your local 
	
	cd docker-setup
    docker-compose up -d
	
	## Or give absolute path to the docker-compose.yml file
	
	docker-compose -f ./../docker_compose.yml up -d --build