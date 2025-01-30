This docker-compose.yml works with the external images from the Docker Hub.

## External Images

  * djamka/mysql
  * djamka/todosapi 
  * djamka/nginx


## Pull, Build and Run All Containers
```
docker-compose down
docker-compose up -d
```

## Pull an image from Docker Hub manually
```
docker pull djamka/mysql:8.0
docker pull djamka/todosapi
docker pul djamka/nginx
```
```
