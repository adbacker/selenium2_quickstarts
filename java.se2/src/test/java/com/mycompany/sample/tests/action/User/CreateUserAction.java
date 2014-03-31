package com.mycompany.sample.tests.action.User;

import com.mycompany.sample.tests.Action;
import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.model.User;
import com.mycompany.sample.tests.pages.LoginPage;
import com.mycompany.sample.tests.pages.MainPage;
import com.mycompany.sample.tests.pages.RegisterPage;


/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 3:46 PM
 * To change this template use File | Settings | File Templates.
 */
public class CreateUserAction extends Action {
    private User user;
    private MainPage mainPage;
    private LoginPage loginPage;
    private RegisterPage registerPage;

    public CreateUserAction(WebBrowser browser, User user) {
        super(browser);
        this.user = user;
        mainPage = new MainPage(_browser);
        loginPage = new LoginPage(_browser);
        registerPage = new RegisterPage(_browser);
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

    public RegisterPage getRegisterPage() {
        return registerPage;
    }

    @Override
    public boolean execute() {
        mainPage.NavTo();
        mainPage.LogOnLink().click();
        loginPage.registerLink().click();
        registerPage.txtUsername().sendKeys(user.getUsername());
        registerPage.txtEmail().sendKeys(user.getEmail());
        registerPage.txtPassword().sendKeys(user.getPassword());
        registerPage.txtConfirmPassword().sendKeys(user.getPassword());
        registerPage.btnRegister().click();
        
        return verify(user.getUsername());
    }
    

    private boolean verify(String username)
    {
        String foundUser = mainPage.LoggedInUser();
        boolean success = username.equals(foundUser) && null != mainPage.LogOffLink();
        //boolean success = (null != mainPage.LogOffLink());
        return success;
    }


}
