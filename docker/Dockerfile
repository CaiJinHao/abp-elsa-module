FROM mcr.microsoft.com/dotnet/aspnet:8.0

ENV TZ=Etc/UTC
EXPOSE 8080
ENV ASPNETCORE_HTTP_PORTS=8080

#
WORKDIR /app

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

RUN DEBIAN_FRONTEND=noninteractive TZ=Etc/UTC apt-get -y install tzdata

#
COPY app /app

ENTRYPOINT ["dotnet", "Passingwind.WorkflowApp.Web.dll"]
