#!/bin/sh
TAG=$1
KEY=$2

dotnet pack -c Release -o ../dist IGDB/IGDB.csproj -p:PackageVersion=$TAG;Title="IGDB API Wrapper";Authors="kayub";PackageDescription="A .NET Standard wrapper around the IGDB v3 games database API";PackageLicenseExpression="Apache-2.0";PackageTags="igdb;games;api;wrapper"

dotnet nuget push ./dist/IGDB-$TAG.nupkg -k $KEY -s https://www.nuget.org