package com.mycompany.sample.tests.UserTests;

import com.mycompany.sample.tests.BaseTest;
import com.mycompany.sample.tests.Util.UserUtil;
import com.mycompany.sample.tests.action.User.CreateUserAction;
import com.mycompany.sample.tests.action.User.LoginAction;
import com.mycompany.sample.tests.action.User.LogoffAction;
import com.mycompany.sample.tests.model.User;
import org.apache.log4j.Logger;
import org.junit.*;

public class LoginTests extends BaseTest {
    private static final Logger log = Logger.getLogger(LoginTests.class);

    @Test
    public void testLogin1()
    {
        String username = UserUtil.RandomUserid();
        String password = "pass123";
        User user = new User(username,password,username + "@mailinator.com");
        //create the user first
        CreateUserAction cua = new CreateUserAction(Browser,user);
        LogoffAction loa = new LogoffAction(Browser);

        //notice we don't check the results of the create or log off -- we assume
        //they're successfull because they're checked elsewhere
        cua.execute();
        loa.execute();

        //then log in as that user
        LoginAction loginAction = new LoginAction(Browser,user);
        boolean loginSuccess = loginAction.execute();
        Assert.assertTrue(loginSuccess);
    }


    @Test
    public void testBadLoginPageObject()
    {
        User user = new User("test002","badpass","test002@mailinator.com");
        LoginAction loginAction = new LoginAction(Browser,user);
        boolean loginSuccess = loginAction.execute();

        Assert.assertFalse(loginSuccess);

        String foundBadPasswordError = loginAction.getLoginPage().logOnErrorBadUsernameOrPasswordMessage();
        Assert.assertNotNull(foundBadPasswordError);
        Assert.assertTrue("Bad password error did not match expected",loginAction.getLoginPage().expectedBadUsernameOrPasswordText().equals(foundBadPasswordError));
    }


}