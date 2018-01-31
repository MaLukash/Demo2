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

namespace AndroidTests.Pages
{
    public class ViewsPage: MainPage
    {
        protected void GoToRotatingButton()
        {
            GoToViews();
			Thread.Sleep(1000);
			driver.Swipe(650, 1700, 650, 250, 2000);
			Thread.Sleep(1000);
			driver.Swipe(650, 1750, 650, 1100, 2000);
			Thread.Sleep(1000);
			driver.FindElementByAccessibilityId("Rotating Button").Click();
        }
    }
}
