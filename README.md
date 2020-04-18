# CSharpADB
A package allowing ADB and Fastboot operations from C#.
### Initialization
Add **CSharpADB.cs** to your project.
You also have to install **Ionic.Zip.dll** in References.
```cs
using RNDN.CSharpADB; 
CSharpADB adb = new CSharpADB();
```

### How to use?
You can download ADB Recourses from Google automatically.
```cs
adb.DownloadADBpkg();
adb.adbPath = System.IO.Path.GetTempPath() + "\\unzipPlat\\platform-tools\\adb.exe";
adb.fbPath = System.IO.Path.GetTempPath() + "\\unzipPlat\\platform-tools\\fastboot.exe";`
```
### How to run commands?
```cs
//ADB
adb.RunAdb("devices");
Console.WriteLine(adb.stdout);

//Fastboot
adb.RunFastboot("oem unlock go");
Console.WriteLine(adb.stdout);
```


