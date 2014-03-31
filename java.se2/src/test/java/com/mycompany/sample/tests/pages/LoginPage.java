package com.mycompany.sample.tests.pages;

import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.model.User;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 11:49 AM
 * To change this template use File | Settings | File Templates.
 */

public class LoginPage extends BasePage {

    public LoginPage(WebBrowser browser) {
        super(browser);
    }

    public By usernameEntryFindBy()
    {
        return By.id("UserName");
    }

    public WebElement txtUserName()
    {
        return _browser.element(usernameEntryFindBy());
    }

    public By passwordEntryFindBy() {
        return By.id("Password");
    }
    public WebElement txtPasswordEntry() {
        return _browser.element(passwordEntryFindBy());
    }

    public By logOnButtonFindBy()
    {
        return By.xpath("//input[@value='Log On']");
    }
    public WebElement logOnButton()
    {
        return _browser.element(logOnButtonFindBy());
    }

    public By logOnErrorBadUsernameOrPasswordFindBy()
    {
        return By.xpath("//div[@class='validation-summary-errors']/ul/li");
    }
    public String logOnErrorBadUsernameOrPasswordMessage()
    {
        return _browser.element(logOnErrorBadUsernameOrPasswordFindBy()).getText();
    }
    
    public By registerLinkFindBy() {
        return By.linkText("Register");
    }
    public WebElement registerLink() {
        return _browser.element(registerLinkFindBy());
    }

    public String expectedBadUsernameOrPasswordText()
    {
        return "The username or password provided is incorrect.";
    }
}
