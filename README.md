# csADB
This is a simple Android Debug Bridge library for .NET!

## Usage/Examples

Compile the library and add the file as a dependency of your project. It may be GuNet package or .dll file

Usage Examples:
```javascript
using System;
using csADB;

namespace AdbApp
{
    
    class Program
    {
        static void Main(string[] args)
        {
            csadb adb = new csadb();

            adb.RunAdbCmd("devices"); //adb devices
            adb.RunFastbootCmd("oem unlock go"); //fastboot oem unlock go
            adb.GetPackage(); //Get lastest ADB packages from Google
            Console.WriteLine(adb.LastStdout); //ADB console output of latest cmd
            Console.WriteLine(adbPath); //Get adb package location
            Console.WriteLine(fbPath); //Get fastboot package location
        }
    }
}


```
