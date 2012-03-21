package com.mycompany.sample.tests.pages;

import com.mycompany.sample.tests.Util.WebBrowser;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

/**
 * Created by IntelliJ IDEA.
 * User: aaron.backer
 * Date: 3/17/12
 * Time: 3:20 PM
 * To change this template use File | Settings | File Templates.
 */
public class RegisterPage extends BasePage {


    public RegisterPage(WebBrowser browser) {
        super(browser);
    }

    public WebElement txtUsername() {
        return _browser.element(By.id("username"));
    }
    
    public WebElement txtPassword() {
        return _browser.element(By.id("password"));
    }
    
    public WebElement txtConfirmPassword() {
        return _browser.element(By.id("confirmPassword"));
    }
    
    public WebElement txtEmail() {
        return _browser.element(By.id("email"));
    }

    public WebElement btnRegister() {
        return _browser.element(By.xpath(".//input[@value='Register']"));
    }
}
