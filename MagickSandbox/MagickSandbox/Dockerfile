FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as builder

COPY . /source
WORKDIR /source
COPY MagickSandbox.csproj ./
RUN dotnet restore -r linux-x64 MagickSandbox.csproj
COPY . .
RUN dotnet publish --no-restore -c Release -r linux-x64 --sc false -o out "MagickSandbox.csproj"


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as final

WORKDIR /app
EXPOSE 80
EXPOSE 8080
EXPOSE 443

COPY --from=builder /source/out .
# RUN cp /app/Magick.Native-Q8-x64.dll.so /app/Magick.Native-Q8-x64.dll
ENTRYPOINT ["dotnet", "MagickSandbox.dll"]
