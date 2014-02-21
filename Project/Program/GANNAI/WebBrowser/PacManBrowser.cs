using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.IO;
using System.Diagnostics;

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Support.UI;

using System.Threading;
using System.Resources;

namespace WebBrowser {
  public class PacManBrowser : Browser {

    public PacManBrowser() : base() {
      string pacUrl = Directory.GetCurrentDirectory() + dirSep() + "pacman" + dirSep() + "index.htm";


      driver.Navigate().GoToUrl(pacUrl);

      // Wait for javascript to load
      wait(seconds(2));

      // Load canvas up
      IWebElement canvas = driver.FindElement(By.Id("canvas"));

      clickPacMan(canvas);
      clickPlay(canvas);

      wait(seconds(2));

      left();
      wait(seconds(2));
      down();
      wait(seconds(2));
      right();

      wait(seconds(5));

      takeScreenshot(driver, "roflcopter.png");
    }

    private void wait(TimeSpan time) {
      Thread.Sleep((int)time.TotalMilliseconds);
    }

    private void sleep(int milliseconds) {
      Thread.Sleep(milliseconds);
    }

    private void left() {
      keyPress(Keys.ArrowLeft);
    }

    private void right() {
      keyPress(Keys.ArrowRight);
    }

    private void up() {
      keyPress(Keys.ArrowUp);
    }

    private void down() {
      keyPress(Keys.ArrowDown);
    }

    private void keyPress(string key) {
      new Actions(driver).SendKeys(key).Perform();
    }

    private TimeSpan seconds(double seconds) {
      return TimeSpan.FromSeconds(seconds);
    }

    /// <summary>
    /// Used to click "Play" after picking a game mode
    /// </summary>
    /// <param name="d">D.</param>
    /// <param name="canvas">Canvas.</param>
    private void clickPlay(IWebElement canvas) {
      click(canvas, (canvas.Size.Width / 2), (canvas.Size.Height / 3));
      wait(TimeSpan.FromSeconds(2));
    }

    /// <summary>
    /// Used to click the "Pac-Man" option in the main root menu
    /// </summary>
    /// <param name="d">D.</param>
    /// <param name="canvas">Canvas.</param>
    private void clickPacMan(IWebElement canvas) {
      click(canvas, (canvas.Size.Width / 2), (canvas.Size.Height / 4));
      wait(seconds(2));
    }

    private void takeScreenshot(IWebDriver d, string fileName) {
      string saveDir = Directory.GetCurrentDirectory() + dirSep();

      ITakesScreenshot screenshotDriver = d as ITakesScreenshot;
      Screenshot screenshot = screenshotDriver.GetScreenshot();

      // This actual screenshot save method doesn't work...
      //screenshot.SaveAsFile(saveDir + fileName, System.Drawing.Imaging.ImageFormat.Png);

      File.WriteAllBytes(saveDir + fileName, screenshot.AsByteArray);
    }

    private string dirSep() {
      return System.IO.Path.AltDirectorySeparatorChar.ToString();
    }

    private void click(IWebElement element, int offsetX, int offsetY) {
      new Actions(driver).MoveToElement(element,offsetX, offsetY).ClickAndHold().Release().Perform();
    }
  }
}

