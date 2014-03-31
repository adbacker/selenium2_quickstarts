package com.mycompany.sample.tests.pages;

import com.mycompany.sample.tests.Util.WebBrowser;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 3:20 PM
 * To change this template use File | Settings | File Templates.
 */
public class RegisterPage extends BasePage {


    public RegisterPage(WebBrowser browser) {
        super(browser);
    }

    public WebElement txtUsername() {
        return _browser.element(By.id("UserName"));
    }
    
    public WebElement txtPassword() {
        return _browser.element(By.id("Password"));
    }
    
    public WebElement txtConfirmPassword() {
        return _browser.element(By.id("ConfirmPassword"));
    }
    
    public WebElement txtEmail() {
        return _browser.element(By.id("Email"));
    }

    public WebElement btnRegister() {
        return _browser.element(By.xpath(".//input[@value='Register']"));
    }
}
