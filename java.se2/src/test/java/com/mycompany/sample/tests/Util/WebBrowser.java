package com.mycompany.sample.tests.Util;

import org.apache.log4j.Logger;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;


import java.net.MalformedURLException;
import java.net.URL;
import java.util.List;
import java.util.concurrent.TimeUnit;

//import org.openqa.selenium.ie.InternetExplorerDriver;

//wraps our webdriver instance and gives us some niceties
public class WebBrowser {

    //log4j magic:
    private Logger log = Logger.getLogger(WebBrowser.class);


    private WebDriver _driver = null;


    private WebDriver newDriver() {

        //local IE, chrome or firefox testing:
        //_driver = new InternetExplorerDriver();
        _driver = new FirefoxDriver();
        _driver = new ChromeDriver("c:\grid2");

        // - remoteWebDriver:
//
//        try {
//            newDriver = new RemoteWebDriver(new URL(hubUrl), browserType);
//        } catch (MalformedURLException e) {
//            e.printStackTrace();  //To change body of catch statement use File | Settings | File Templates.
//        }

        //using the Augmenter gives RemoteWebDriver the ability
        //to take screenshots...
        //_driver = new Augmenter().augment(new RemoteWebDriver(new URL(hubUrl), browserType));
    
        //
        //PageFactory.initElements(new AjaxElementLocatorFactory(newDriver, 10), this);
        newDriver.manage().timeouts().implicitlyWait(10, TimeUnit.SECONDS);
    
        return newDriver;
        
        
    }
    
    public WebBrowser() {
        _driver = newDriver();
    }



    public WebDriver getDriver() {

        return _driver;
    }



    public void CloseBrowser() {
        _driver.quit();
        _driver = null;
    }

    public WebElement element(By findBy) {
        List<WebElement> foundelements = _driver.findElements(findBy);

        //only return an item if one is found
        if (foundelements.size() > 0) {
            return foundelements.get(0);
        }

        log.debug("Failed finding web element" + findBy.toString());

        return null;
    }

    public static void enterText(WebElement textbox, String enterText) {
        try {
        textbox.click();
        textbox.clear();
        textbox.sendKeys(enterText);
        }
        catch (Exception e)
        {

        }
    }

    public void go(String url) {
        _driver.get(url);
    }

    protected static String getSetting(String settingName, String defaultVal) {
        String envName = settingName.replaceAll("\\.","");
        if(System.getenv(envName) != null) return System.getenv(envName);
        return System.getProperty(settingName, defaultVal);
    }

    /** Takes a screen-shot of the page.
     * @return a file containing the screenshot. */
    public String screenShotBase64String() {
        return  ((TakesScreenshot) _driver).getScreenshotAs(OutputType.BASE64);

    }
}
