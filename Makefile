VERSION = $(shell dotnet --version | cut -d '.' -f1,2)
CONTENT = "<Project Sdk=\"Microsoft.NET.Sdk\">\n\t<PropertyGroup>\n\t\t<TargetFramework>net$(VERSION)</TargetFramework>\n\t</PropertyGroup>\n</Project>"
PROJECT_NAME = "GameBuilder"
DIR = .

$(PROJECT_NAME).csproj:
	@echo $(CONTENT) > $(PROJECT_NAME).csproj
	dotnet add package Monogame.Framework.DesktopGL

install: $(PROJECT_NAME).csproj
	dotnet build /p:Optimize=true
	mv ./bin/Debug/net$(VERSION)/$(PROJECT_NAME).dll $(DIR)

clean:
	rm $(PROJECT_NAME).csproj -f
	rm $(PROJECT_NAME).dll -f
	rm bin/ obj/ -fr
