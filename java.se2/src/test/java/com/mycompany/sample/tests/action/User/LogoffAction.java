package com.mycompany.sample.tests.action.User;

import com.mycompany.sample.tests.Action;
import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.pages.MainPage;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 4:29 PM
 * To change this template use File | Settings | File Templates.
 */
public class LogoffAction extends Action {
    private MainPage mainPage;

    public LogoffAction(WebBrowser browser) {
        super(browser);
        mainPage = new MainPage(_browser);
    }

    public MainPage getMainPage() {
        return mainPage;
    }

    public boolean execute() {
        mainPage.LogOffLink().click();
        
        return verify();
    }
    
    private boolean verify() {
        return (null != mainPage.LogOnLink());
    }
}
