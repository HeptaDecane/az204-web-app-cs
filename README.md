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