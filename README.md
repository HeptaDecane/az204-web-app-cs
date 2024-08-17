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

### containerization script
```sh
# sudo su
dotnet publish -c Release -o Az204WebApp/bin/publish
docker build -t az204-web-app Az204WebApp/
docker run -e ASPNETCORE_ENVIRONMENT=Development -d -p 80:8080 az204-web-app
```

### docker cheat sheet

```sh
# run as superuser
sudo su
```

```sh
# list running containers
docker container ls
```

```sh
# list all containers
docker container ls --all
```

```sh
# stop a container
docker container stop <CONTAINER_ID>
```

```sh
# remove a container
docker container rm <CONTAINER_ID>
```

```sh
# remover all containers
docker rm $(docker ps -aq)
```

```sh
# list docker images
docker image ls
```

```sh
# pull an image from dockerhub
docker pull <IMAGE>

# eg: https://hub.docker.com/_/httpd
docker pull httpd
```

```sh
# build a docker image
docker image build -t <TAG> <PATH/TO/DOCEKRFILE>

#eg:
docker image build -t az204-web-app Az204WebApp/

```

```sh
# run an image as container
docker run <IMAGE>

# eg:
# -d => runs the container in detached mode, i.e. it runs in the background and doesn't block your terminal
# -p 8000:80 => maps a port on your local machine (8000) to a port inside the container (80)
# -e => set environment variables
docker run -d -p 8000:80 httpd
docker run -e ASPNETCORE_ENVIRONMENT=Development -d -p 8000:8080 az204-web-app

```

```sh 
# login to a registry
docker login <SERVER>

# create an image tag
docker image tag <SOURCE_IMAGE:TAG> <TARGET_IMAGE:TAG>

# upload image to a registry
docker image push <IMAGE:TAG>
```
