#!/bin/sh
TAG=$1
KEY=$2

dotnet pack -c Release -o ../dist IGDB/IGDB.csproj \
  -p:PackageVersion=$TAG \
  -p:Title="IGDB API Wrapper" \
  -p:Authors="kayub" \
  -p:PackageDescription="A .NET Standard wrapper around the IGDB v3 games database API" \
  -p:PackageLicenseExpression="Apache-2.0" \
  -p:PackageTags="igdb;games;api;wrapper"

dotnet nuget push dist/IGDB.$TAG.nupkg -k $KEY -s https://www.nuget.org