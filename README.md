---
languages:
- csharp
products:
- dotnet-core
- windows
---

# Extended COM Server Demo

This is an extension of [Microsofts basic example of providing a managed COM server in .NET Core/5+](https://github.com/dotnet/samples/tree/main/core/extensions/COMServerDemo). Documentation on the inner workings of activation can be found [here](https://github.com/dotnet/runtime/blob/main/docs/design/features/COM-activation.md).

## Key Features
My goal was to make MS Access work with .net 6 code. Main pain-points where that back then it wasn't documented that this requires the build to target `x86` and how to create a fitting `.tlb`-file.
Both are addressed in this small sample. The trick for the tlb-issue is that you have a dummy implementation of your original .net 6 code class in the contract project that is used to generate the .tlb-file directly. The contract project is a `netstandard2` project, allowing it to be run with (tlbexp.exe)[(https://docs.microsoft.com/en-us/dotnet/framework/tools/tlbexp-exe-type-library-exporter]

## Build and Run
Run the following commands from the developer powershell
1. `dotnet build`
1. `& 'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\TlbExp.exe' .\Contract\bin\x86\Debug\netstandard2.0\Contract.dll`
1. `move -force .\Contract.tlb .\ComServer\bin\x86\Debug\net6\`
1. Register the .dll from an **admin** cmd/Powershell from: `regsvr32.exe ComServer\bin\x86\Debug\net6\COMServer.comhost.dll`
1. The included `Access2003.mdb` can be used to import the .tlb-file (there is a link which is most likely wrong for your machine, or you copy the contents from step 3 to the folder `c:\ComSample`) and the code should run.

## Notes
The project will only build and run on the Windows platform. 
Remember to unregister the COM server when the demo is complete `regsvr32.exe /u ComServer\bin\x86\Debug\net6\COMServer.comhost.dll`