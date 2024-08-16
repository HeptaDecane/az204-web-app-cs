# az204-web-app-cs

### development script
```sh
dotnet build 
dotnet run --project Az204WebApp
```

### deployment script
```sh
dotnet publish -c Release -o publish
cd publish
zip -r ../publish.zip .
cd ..
az webapp deploy --resource-group az204-rg --name az204-web-app-cs --src-path publish.zip
rm -rf publish/
rm publish.zip
az webapp browse --name az204-web-app-cs --resource-group az204-rg
```

### docker cheat sheet

```sh
# run as superuser
sudo su
```

```sh
# list running containers
docker container ls

# list all containers
docker container ls --all

# stop a container
docker container stop <CONTAINER_ID>

# remove a container
docker container rm <CONTAINER_ID>

# remover all containers
docker rm $(docker ps -aq)

# list docker images
docker image ls

# pull an image from dockerhub
docker pull <IMAGE>
# eg: https://hub.docker.com/_/httpd
docker pull httpd

# run an image as container
docker run <IMAGE>
# eg:
docker run -d -p 8000:80 httpd

```
