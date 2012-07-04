CLS

SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319;C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools\x64


RegAsm.exe Mingle.GherkinExtractor.dll 
REM GacUtil.exe /i Mingle.GherkinExtractor.dll

regedit /s Register.reg


