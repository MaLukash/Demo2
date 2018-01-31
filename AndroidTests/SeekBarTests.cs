using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using AndroidTests.Pages;

namespace AndroidTests
{
    [TestFixture]
    public class SeekBarTests:ViewsPage
    {
        private static readonly object[] TestData =
        {
            new object[] { "io.appium.android.apis:id/scaleX",1}
        };

        private void SearchAndMoveSeekBar(string seekBarId, double percentToMove)
        {
            if (percentToMove > 1)
            {
                throw new Exception("percentToMove variable can be set only in [0,1] range");
            }
            IWebElement seekBar = driver.FindElementById(seekBarId);
            //Get start point of seekbar.
            double startX = seekBar.Location.X;
            double yPos = seekBar.Location.Y;
			//Setting where to move 
			double bound = seekBar.Size.Width;
			double moveByX = bound * percentToMove;
            //Moving seekbar using TouchAction class.
            TouchAction act = new TouchAction(driver);
            act.Press(startX, yPos).MoveTo(moveByX-1,yPos).Release().Perform();
        }


		[Test, TestCaseSource(nameof(TestData))]
		//[Test, TestCaseSource(nameof(TestData))]
		public void SearchAndMoveSeekBar(int numberOfBars, string barsIds, double[] percentsToMove)
		{
            if (driver.FindElementById("io.appium.android.apis:id/container").Displayed)
            {
                GoToRotatingButton();
            }
			string[] barId = barsIds.Split(',');
			for (int i = 0; i < percentsToMove.Length; i++)
			{
				SearchAndMoveSeekBar(barId[i], percentsToMove[i]);
			}
		}
	}
}