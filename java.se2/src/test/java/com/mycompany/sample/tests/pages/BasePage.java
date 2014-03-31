package com.mycompany.sample.tests.pages;

import com.mycompany.sample.tests.Util.WebBrowser;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/18/12
 * Time: 11:48 AM
 * To change this template use File | Settings | File Templates.
 */
public abstract class BasePage {
    protected WebBrowser _browser;

    public BasePage(WebBrowser browser) {
        _browser = browser;
    }
}
