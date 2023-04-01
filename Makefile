	#win-x64
runtime= linux-x64 

all: build

build:
	dotnet build --configuration Debug

publish:
	dotnet publish --configuration Release --runtime $(runtime) --self-contained -p:PublishTrimmed=True -p:TrimMode=Link -p:PublishSingleFile=true

run:
	dotnet run --configuration Debug

exe:
	dotnet ./bin/Debug/net5.0/codewars.dll

chek:
	@bash ./chek.sh
