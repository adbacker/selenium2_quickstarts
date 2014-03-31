package com.mycompany.sample.tests.UserTests;

import com.mycompany.sample.tests.BaseTest;
import com.mycompany.sample.tests.action.User.CreateUserAction;
import com.mycompany.sample.tests.action.User.LoginAction;
import com.mycompany.sample.tests.action.User.LogoffAction;
import com.mycompany.sample.tests.model.User;
import junit.framework.Assert;
import org.junit.Test;

import java.util.UUID;

/**
 * Created by IntelliJ IDEA.
 * UserUtil: aaron.backer
 * Date: 3/17/12
 * Time: 4:13 PM
 * To change this template use File | Settings | File Templates.
 */
public class UserTests extends BaseTest {
    
    @Test
    public void testCreateUser() {

        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        User user = new User(randomUserName,"pass123",randomUserName + "@mailinator.com");
        CreateUserAction cuAction = new CreateUserAction(Browser,user);

        boolean success = cuAction.execute();
        Assert.assertTrue("createUser failed", success);
    }


    @Test
    public void testCreateUser1() {

        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        User user = new User(randomUserName,"pass123",randomUserName + "@mailinator.com");
        CreateUserAction cuAction = new CreateUserAction(Browser,user);

        boolean success = cuAction.execute();
        Assert.assertTrue("createUser failed", success);
    }


    @Test
    public void testCreateUser2() {

        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        User user = new User(randomUserName,"pass123",randomUserName + "@mailinator.com");
        CreateUserAction cuAction = new CreateUserAction(Browser,user);

        boolean success = cuAction.execute();
        Assert.assertTrue("createUser failed", success);
    }

    @Test
    public void testCreateUser3() {

        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        User user = new User(randomUserName,"pass123",randomUserName + "@mailinator.com");
        CreateUserAction cuAction = new CreateUserAction(Browser,user);

        boolean success = cuAction.execute();
        Assert.assertTrue("createUser failed", success);
    }



    @Test
    public void testLoginWithNewUser() {
        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        User user = new User(randomUserName,"pass123",randomUserName + "@mailinator.com");
        CreateUserAction cuAction = new CreateUserAction(Browser,user);
        cuAction.execute();
        //createUser leaves us logged in
        LogoffAction logOff = new LogoffAction(Browser);
        logOff.execute();
        
        LoginAction loginAction = new LoginAction(Browser,user);
        boolean loginWithNewUserSuccess = loginAction.execute();
        Assert.assertTrue("new user logon failed",loginWithNewUserSuccess);
    }
}
