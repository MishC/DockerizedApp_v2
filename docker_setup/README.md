This docker-compose.yml works with the external images from the Docker Hub.

## Pull External Images

  * djamka/mysql
  * djamka/todosapi 
  * djamka/nginx

```
docker pull djamka/mysql:8.0
docker pull djamka/todosapi
docker pull djamka/nginx
```

## Build and Run All Containers
```
docker-compose down
docker-compose up -d
```


