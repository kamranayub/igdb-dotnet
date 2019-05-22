#!/bin/sh
TAG=$1
KEY=$2

dotnet pack --no-build -c Release -o ./dist -p:PackageVersion=$TAG -p:Title="IGDB API Wrapper" -p:Authors="kayub" -p:PackageDescription="A .NET Standard wrapper around the IGDB v3 games database API" -p:PackageLicenseExpression="Apache-2.0" -p:PackageTags="igdb;games;api;wrapper" IGDB/IGDB.csproj

dotnet nuget push ./dist/IGDB.nupkg -k $KEY