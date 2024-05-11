FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as builder

COPY . /source
WORKDIR /source
COPY MagickSandbox.csproj ./
RUN dotnet restore -r linux-x64 MagickSandbox.csproj
COPY . .
RUN dotnet publish --no-restore -c Release -r linux-x64 --sc false -o out "MagickSandbox.csproj"


FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine as final

WORKDIR /app
EXPOSE 8080

COPY --from=builder /source/out .
# Magick.NET depends on libresolv.so.2, which is not included in Alpine. This compat package resolves this.
RUN apk add --no-cache libc6-compat 
ENTRYPOINT ["dotnet", "MagickSandbox.dll"]
