	#win-x64
runtime=linux-x64 

all: build

build:
	dotnet build --configuration Release

publish-self-contained:
	dotnet publish --configuration Release --runtime $(runtime) --self-contained -p:PublishSingleFile=true -p:EnableCompressionInSingleFile=true

publish:
	dotnet publish --configuration Release -p:PublishSingleFile=true --no-self-contained

run:
	dotnet run --configuration Debug
