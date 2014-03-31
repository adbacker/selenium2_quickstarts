package com.mycompany.sample.tests.pages;

import com.mycompany.sample.tests.Util.WebBrowser;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 11:49 AM
 * To change this template use File | Settings | File Templates.
 */
public class MainPage extends BasePage {

    public MainPage(WebBrowser browser) {
        super(browser);
    }

    public void NavTo()
    {
        _browser.go(Url);
    }

    public String Url = "http://localhost:54836/";

    //find by link text
    public By LogOnLinkFindBy()
    {
        return By.linkText("Log On");
    }
    public WebElement LogOnLink()
    {
        return _browser.element(LogOnLinkFindBy());
    }

    public By RegisterLinkFindBy()
    {
        return By.linkText("Register");
    }
    public WebElement RegisterLink()
    {
        return _browser.element(RegisterLinkFindBy());
    }

    public By LogOffLinkFindBy() {
        return By.linkText("Log Off");
    }
    public WebElement LogOffLink() {
        return _browser.element(LogOffLinkFindBy());
    }

    public By HostDinnerFindBy() {
        return By.linkText("Host Dinner");
    }
    public WebElement HostDinnerLink() {
        return _browser.element(HostDinnerFindBy());
    }


    //find by xpath
    public By WelcomeUserTextFindBy()
    {
        return By.xpath("//div[@id='logindisplay']/b");
    }


    public String LoggedInUser()
    {
        String user = null;

        WebElement welcomeUserElement = _browser.element(WelcomeUserTextFindBy());
        if (null != welcomeUserElement)
        {
            user = welcomeUserElement.getText();
        }
        return user;
    }
}
