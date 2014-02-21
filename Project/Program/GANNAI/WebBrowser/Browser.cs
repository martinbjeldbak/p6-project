using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;

namespace WebBrowser {
	public class Browser {
    protected IWebDriver driver;

		public Browser() {
      driver = new PhantomJSDriver();
      driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
		}

    public void quit() {
      driver.Quit();
      driver.Dispose();
    }
	}
}

