using BitCoinIRAProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace BitCoinIRAProject.StepDefinations
{
    [Binding]
    public sealed class AngularBusySteps
    {
        public IWebDriver driver { get; set; }

        MainPage page = null;

        [BeforeScenario]
        public void BeforeHooks()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Given(@"User is on Angular busy app")]
        public void GivenUserIsOnAngularBusyApp()
        {
            //var htmlReporter = new ExtentHtmlReporter();
            page = new MainPage(driver);
            page.goToAngularApp();
        }

        [When(@"User enters message '(.*)' in textbox")]
        public void WhenUserEntersMessageInTextbox(string message)
        {
            if (!String.IsNullOrWhiteSpace(message))
                page.enterMessage(message);
        }

        [When(@"clicks Demo button")]
        public void WhenClicksDemoButton()
        {
            page.clickDemo();
        }

        [When(@"User enters message '(.*)' and clicks Demo button")]
        public void WhenUserEntersMessageAndClicksDemoButton(string message)
        {
            page.enterMessage(message);
            page.clickDemo();
        }

        [When(@"User set minimum duration to '(.*)' ms")]
        public void WhenUserSetMinimumDurationToMs(string minDuration)
        {
            if (!String.IsNullOrWhiteSpace(minDuration))
                page.setMinDuration(minDuration);
        }

        [When(@"User set delay value to '(.*)' ms")]
        public void WhenUserSetDelayValueToMs(string delay)
        {
            if (!String.IsNullOrWhiteSpace(delay))
                page.setDelay(delay);          
        }

        [When(@"User select template drop down as '(.*)'")]
        public void WhenAndUserSelectTemplateDropDownAs(string value)
        {
            page.selectTemplate(value);
        }

        [Then(@"the busy indicator with message should be displayed")]
        public void ThenTheBusyIndicatorWithMessageShouldBeDisplayed()
        {
            page.IsBusySpinnerVisible();
        }

        [Then(@"the busy indicator with message doesnt display")]
        public void ThenTheBusyIndicatorWithMessageDoesntDisplay()
        {
            page.IsSpinnerNotVisible();
        }

        [AfterScenario]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
