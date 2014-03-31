package com.mycompany.sample.tests.pages.Dinner;

import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.pages.BasePage;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import java.util.WeakHashMap;

/**
 * Created by win7-64-vm on 3/18/14.
 */
public class CreateDinner extends BasePage {
    public CreateDinner(WebBrowser browser) {
        super(browser);
    }

//    public By passwordEntryFindBy() {
//        return By.id("Password");
//    }
//    public WebElement txtPasswordEntry() {
//        return _browser.element(passwordEntryFindBy());
//    }

    public By titleEntryFindBy() {
        return By.id("Title");
    }
    public WebElement txtTitle() {
        return _browser.element(titleEntryFindBy());
    }

    public By eventDateEntryFindBy() {
        return By.id("EventDate");
    }
    public WebElement txtEventDate() {
        return _browser.element(eventDateEntryFindBy());
    }

    public By descriptionFindBy() {
        return  By.id("Description");
    }
    public WebElement txtDescription() {
        return _browser.element(descriptionFindBy());
    }

    public By hostedByFindBy() {
        return By.id("HostedBy");
    }
    public WebElement txtHostedBy() {
        return _browser.element(hostedByFindBy());
    }

    public By contactInfoFindBy() {
        return By.id("ContactPhone");
    }
    public WebElement txtContactInfo() {
        return _browser.element(contactInfoFindBy());
    }

    public By addressFindBy() {
        return By.id("Address");
    }
    public WebElement txtAddress() {
        return _browser.element(addressFindBy());
    }

    public By countryFindBy() {
        return By.id("Country");
    }
    public WebElement ddlCountry() {
        return _browser.element(countryFindBy());
    }



}


