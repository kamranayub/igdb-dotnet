#!/bin/sh
TAG=$1
KEY=$2

dotnet pack -c Release -o ../dist IGDB/IGDB.csproj -p:PackageVersion=$TAG -p:NuspecFile=../IGDB.nuspec

dotnet nuget push dist/IGDB.$TAG.nupkg -k $KEY -s https://www.nuget.org