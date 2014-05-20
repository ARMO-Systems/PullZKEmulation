@echo On
set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

%nuget% restore Source\Main.sln -NoCache -NonInteractive
"%ProgramFiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe" Source\Main.sln /p:Configuration="%config%" /p:Platform="Any CPU" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

cd Packs

set firstPartNuget=%nuget% pack 
set lastPartNuget= -NonInteractive %version%

cmd /c %firstPartNuget%PullZKEmulation.nuspec%lastPartNuget%