### containerization script
```sh
# sudo su
docker image build -t mysql-college-db .
docker run -e MYSQL_ROOT_PASSWORD=<password> -d -p 8888:3306 mysql-college-db
```