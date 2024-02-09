// See https://aka.ms/new-console-template for more information
using Microsoft.Win32;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

Stopwatch timer = new Stopwatch();
timer.Start();

SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEvents_SessionSwitch);


void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
{
  if (e.Reason == SessionSwitchReason.SessionLock)
  {
    //I left my desk
    timer.Stop();
    Console.WriteLine("I left my desk");
    Console.WriteLine("Time elapsed: " + timer.Elapsed);

  }
  else if (e.Reason == SessionSwitchReason.SessionUnlock)
  {
    //I returned to my desk
    timer.Start();
    Console.WriteLine("I returned to my desk");
  }
}

ConsoleKeyInfo keyInfo = Console.ReadKey();
while (keyInfo.Key != ConsoleKey.Q)
{
  Console.WriteLine("Time elapsed: " + timer.Elapsed);
  keyInfo = Console.ReadKey();
}
Console.WriteLine("Time elapsed: " + timer.Elapsed);
keyInfo = Console.ReadKey();
