﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Win32Interop.WinHandles.Tests
{
  public class TopLevelWindowUtilsTests
  {
    [Test]
    public void ListAllWindows()
    {
      var allWindows = TopLevelWindowUtils.FindWindows(w => w.GetWindowText() != "");

      Console.WriteLine("All the windows that are currently present:");

      foreach (var windowHandle in allWindows)
      {
        Console.WriteLine(windowHandle.GetWindowText());
      }
    }

    [Test]
    public void ShowForeground()
    {
      var windowHandle = TopLevelWindowUtils.GetForegroundWindow();
      Console.WriteLine(windowHandle.GetWindowText());
    }

    [Test]
    public void FindNotepad()
    {
      var window = TopLevelWindowUtils.FindWindow(w => w.GetWindowText().Contains("Notepad"));
      // TODO we should really just create a window that we control and check against that

      Assert.That(window.GetWindowText(), Contains.Substring("Notepad"));
    }
  }
}