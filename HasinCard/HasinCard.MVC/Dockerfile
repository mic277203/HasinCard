FROM docker.io/microsoft/aspnetcore

ENV ASPNETCORE_URLS http://+:9527
WORKDIR /app
COPY . .

ENTRYPOINT ["dotnet", "HasinCard.MVC.dll"]
	