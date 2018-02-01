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
using AndroidTests.RunnersAndData;
using static AndroidTests.RunnersAndData.DataBuilder;
using System.Collections.Generic;

namespace AndroidTests
{
    [TestFixture]
    public class SeekBarTests:ViewsPage
    {
        private static readonly object[] TestDataXScale =
        {
            new object[] {DataRepository.Get().ScaleXDataMax() }           
        };

        private static readonly object[] TestDataXTrans =
        {
            new object[] {DataRepository.Get().TransXDataMax() }
        };

        private static readonly object[] TestDataYScale =
        {
            new object[] {DataRepository.Get().ScaleYDataMax() }
        };

        private static readonly object[] TestDataMultiBars =
        {
            new object[] {DataRepository.Get().CombChangesInBars() }
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


		[Test, TestCaseSource(nameof(TestDataXScale))]
		public void SeekBarScaleTest(string barId, double perc)
		{
            if (driver.FindElementById("io.appium.android.apis:id/container").Displayed)
            {
                GoToRotatingButton();
            }
            SearchAndMoveSeekBar(barId, perc);
            double buttonWidthActual = driver.FindElementByAccessibilityId("Rotating Button").Size.Width;
            double buttonMaxWidthExpected = driver.Location.Latitude;
            Assert.IsTrue(buttonMaxWidthExpected < buttonWidthActual);
		}

        [Test, TestCaseSource(nameof(TestDataXTrans))]
        public void SeekBarScaleYTest(string barId, double perc)
        {
            if (driver.FindElementById("io.appium.android.apis:id/container").Displayed)
            {
                GoToRotatingButton();
            }
            SearchAndMoveSeekBar(barId, perc);
            Assert.IsTrue(driver.FindElementById(barId).Displayed);
        }

        [Test, TestCaseSource(nameof(TestDataYScale))]
        public void SeekBarTransXTest(string barId, double perc)
        {
            if (driver.FindElementById("io.appium.android.apis:id/container").Displayed)
            {
                GoToRotatingButton();
            }
            SearchAndMoveSeekBar(barId, perc);
            double buttonRightBorderActual = driver.FindElementByAccessibilityId("Rotating Button").Location.X + driver.FindElementByAccessibilityId("Rotating Button").Size.Width;
            double buttonRightBorderExpected = driver.Location.Latitude;
            Assert.IsTrue(buttonRightBorderActual > buttonRightBorderExpected);
        }

        [Test, TestCaseSource(nameof(TestDataMultiBars))]
        public void MultiSeekBar(List <IData> barList)
        {
            if (driver.FindElementById("io.appium.android.apis:id/container").Displayed)
            {
                GoToRotatingButton();
            }
            foreach (IData bar in barList)
            {
                SearchAndMoveSeekBar(bar.GetSeekBarId(),bar.GetPercentToMove());
            }
            Assert.IsTrue(driver.FindElementById("io.appium.android.apis:id/rotatingButton").Displayed);
        }
    }
}