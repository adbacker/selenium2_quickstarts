package com.mycompany.sample.tests;

import com.mycompany.sample.tests.action.LoginAction;
import com.mycompany.sample.tests.model.User;
import com.mycompany.sample.tests.pages.LoginPage;
import org.apache.log4j.Logger;
import org.junit.*;

public class LoginTests extends BaseTest {
    private static final Logger log = Logger.getLogger(LoginTests.class);

    @Test
    public void testLogin1()
    {
        User user = new User("test002","pass002","test002@mailinator.com");
        LoginAction loginAction = new LoginAction(Browser,user);
        boolean loginSuccess = loginAction.execute();
        Assert.assertTrue(loginSuccess);
    }

    @Test
    public void testLogin2()
    {
        User user = new User("test002","pass002","test002@mailinator.com");
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