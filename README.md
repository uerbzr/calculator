# calculator


## Old Workflow:
name: "Deploy to GitHub NuGet"

on:
  push:
    tags:
      - "v*"

jobs:
  deploy:
    permissions:
      contents: read
      packages: write

    runs-on: ubuntu-latest

    steps:
      - name: Checkout code
        uses: actions/checkout@v2

      - name: Setup .NET SDK
        uses: actions/setup-dotnet@v1
        with:
          dotnet-version: "9.0.x" # adjust as needed

      - name: Configure GitHub NuGet source
        run: |
          dotnet nuget add source https://nuget.pkg.github.com/uerbzr/index.json \
            --name github \
            --username uerbzr \
            --password ${{ secrets.GITHUB_TOKEN }} \
            --store-password-in-clear-text

      - name: Restore dependencies
        run: dotnet restore workshop.calculator/workshop.calculator.csproj

      - name: Build project
        run: dotnet build workshop.calculator/workshop.calculator.csproj --configuration Release

      - name: Pack NuGet package
        run: dotnet pack workshop.calculator/workshop.calculator.csproj --configuration Release --output ./nupkgs

      - name: Push to GitHub NuGet
        run: dotnet nuget push ./nupkgs/*.nupkg --source github --api-key ${{ secrets.GITHUB_TOKEN }}

