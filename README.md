# WindowsFormsApp1
Access  data from Progress 4GL Appserver to C# client.
1. Created procedure in Progress 4GL, with one input and output parameters.
2. Compile the code, through ProxyGenerator tool, generate required proxy files.
3. Make sure that Appserver is  running.

1. Copy the below dlls generated by Proxygen to C# code directory.
  guestProxxy.dll
  Progress.Messages.dll
  Progress.04glrt.dll
  runbproxygen.bat
  Make sure to reference above dlls to C# project.
