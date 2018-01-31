using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Compatibility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;
using AndroidTests.RunnersAndData;

namespace AndroidTests.Pages
{
    public class MainPage:TestRunner
    {
        protected void GoToViews()
        {

            driver.Swipe(527, 1310, 553, 590, 5000);
            driver.FindElementByAccessibilityId("Views").Click();
        }
    }
}
