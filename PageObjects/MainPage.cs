using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace BitCoinIRAProject.PageObjects
{
    class MainPage
    {
        public IWebDriver driver { get; }
        private WebDriverWait wait;

        private const String url = "http://cgross.github.io/angular-busy/demo/";

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
           // wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            PageFactory.InitElements(driver, this);
        }

        public WebDriverWait getWait(int delay) => wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(delay));


        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Demo')]")]
        public IWebElement DemoButton { get; set; }


        [FindsBy(How = How.Id, Using = "delayInput")]
        public IWebElement DelayTextBox { get; set; }


        [FindsBy(How = How.Id, Using = "durationInput")]
        public IWebElement minDurationInput { get; set; }


        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement messageBox { get; set; }


        [FindsBy(How = How.Id, Using = "template")]
        public IWebElement templateURlSelector { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='cg-busy cg-busy-animation ng-scope']//div[2]")]
        public IWebElement gifElement { get; set; }

        public int getMinDurationValue()
        {
            return Convert.ToInt32(minDurationInput.GetAttribute("value"));
        }

        public int getDelayValue()
        {
            return Convert.ToInt32(DelayTextBox.GetAttribute("value"));
        }
        public string getTemplateURI()
        {
            return new SelectElement(templateURlSelector).SelectedOption.Text;
        }

        public string getMessage()
        {
            return messageBox.GetAttribute("value");
        }
        public bool IsImageDispalyed()
        {
            var waitTime = getDelayValue() + getMinDurationValue();
            try
            {
                return getWait(waitTime).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='cg-busy cg-busy-animation ng-scope']//div[2]"))).Displayed;
            }
            catch (Exception) { return false; }
        }



        public bool IsSpinnerDisplayed()
        {
            var message = getMessage();
            var waitTime = getDelayValue() + getMinDurationValue(); //Maximum time we can wait for the element to be displayed 
            var xPathQuery = String.Format("//div[contains(text(),'{0}')]", message);
            if (waitTime > 0)
            {
                try
                {
                    return getWait(waitTime).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathQuery))).Displayed;
                }
                catch (Exception) { return false; }
            }              
            else
            {
                try
                {
                    //wait 100ms to find the element
                    return getWait(100).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xPathQuery))).Displayed;
                }
                catch (Exception) { return false; }                    
            }
        }

        // Go to the MainPage
        public void goToAngularApp() => driver.Navigate().GoToUrl(url);

        public void setMinDuration(string minDuration)
        {
            minDurationInput.Clear();
            minDurationInput.SendKeys(minDuration);
        }

        public void setDelay(string delay)
        {
            DelayTextBox.Clear();
            DelayTextBox.SendKeys(delay);
        }

        public void enterMessage(string message)
        {
            messageBox.Clear();
            messageBox.SendKeys(message);
        }

        public void clickDemo() => DemoButton.Click();

        public void selectTemplate(string value)
        {
            new SelectElement(templateURlSelector).SelectByText(value);
        }

        //private readonly string imageUrl = "url(\"http://cgross.github.io/angular-busy/demo/finalfantasy.gif\")";
        public void IsBusySpinnerVisible()
        {
            if (getTemplateURI().Equals("Standard"))
            {
                //Find Spinner
                Assert.IsTrue(IsSpinnerDisplayed());
                Console.WriteLine("Spinner displayed");
            }
            else
            {
                //Find Image
                Assert.IsTrue(IsImageDispalyed());
                Console.WriteLine("Image displayed");
            }
        }
            public void IsSpinnerNotVisible()
            {
                if (getTemplateURI().Equals("Standard"))
                {
                    //Find Spinner
                    Assert.IsFalse(IsSpinnerDisplayed());
                    Console.WriteLine("Spinner Not displayed");
                }
                else
                {
                    //Find Image
                    Assert.IsFalse(IsImageDispalyed());
                    Console.WriteLine("Image Not displayed");
                }
            }
    }
}

