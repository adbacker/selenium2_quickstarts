package com.mycompany.sample.tests.action.User;

import com.mycompany.sample.tests.Action;
import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.model.User;
import com.mycompany.sample.tests.pages.LoginPage;
import com.mycompany.sample.tests.pages.MainPage;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 3:34 PM
 * To change this template use File | Settings | File Templates.
 */
public class LoginAction extends Action {
    private User user;
    private MainPage mainPage;
    private LoginPage loginPage;
    
    public LoginAction(WebBrowser browser, User user) {
        super(browser);
        this.user = user;
        mainPage = new MainPage(_browser);
        loginPage = new LoginPage(_browser);
    }

    public User getUser() {
        return user;
    }

    public MainPage getMainPage() {
        return mainPage;
    }

    public LoginPage getLoginPage() {
        return loginPage;
    }

    @Override
    public boolean execute()
    {
        mainPage.NavTo();

        mainPage.LogOnLink().click();

        loginPage.txtUserName().sendKeys(user.getUsername());
        loginPage.txtPasswordEntry().sendKeys(user.getPassword());
        loginPage.logOnButton().click();
        return Verify(user.getUsername());
    }

    private boolean Verify(String username)
    {
        String foundUser = mainPage.LoggedInUser();
        return username.equals(foundUser)
                && null != mainPage.LogOffLink() ;
    }
}
