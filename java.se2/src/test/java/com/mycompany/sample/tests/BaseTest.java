package com.mycompany.sample.tests;

import com.mycompany.sample.tests.Util.WebBrowser;
import org.apache.log4j.BasicConfigurator;
import org.apache.log4j.Logger;
import org.junit.*;
import org.junit.rules.TestName;
import org.junit.rules.TestRule;
import org.junit.rules.TestWatcher;
import org.junit.runner.Description;
import org.openqa.selenium.WebDriver;

import java.net.InetAddress;
import java.net.UnknownHostException;

/**
 * Created by IntelliJ IDEA.
 * User: aaron.backer
 * Date: 3/13/12
 * Time: 2:12 PM
 * To change this template use File | Settings | File Templates.
 */
public class BaseTest {
    private static final Logger log = Logger.getLogger(BaseTest.class);
    
    public WebBrowser Browser;

    public BaseTest() {
        Browser = new WebBrowser();

    }



    @BeforeClass
    public static void classSetup() {
        BasicConfigurator.configure();

    }

    @Before
    public void setUp() {
     log.debug("Starting test " + simpleTestCaseName() + " on thread " + Thread.currentThread().getName());    }

    @After
    public void tearDown() {
        Browser.CloseBrowser();
    }

    @AfterClass
    public static void classTearDown() {

    }


    public static String getHostName() {
        String hostName;
        try { hostName = InetAddress.getLocalHost().getHostName(); }
        catch (UnknownHostException e) { hostName = "unknownhost"; }
        return hostName;
    }

    private String simpleTestCaseName() { return name.getMethodName(); }
    public String fullyQualifiedTestCaseName() { return String.format("%s.%s", this, simpleTestCaseName()); }

    private String generalClassName() {
        Class currentClass = getClass(), previousClass = currentClass;
        while (!currentClass.getPackage().getName().contains("tests")) {
            previousClass = currentClass; currentClass = previousClass.getSuperclass();
        }
        return previousClass.getName();
    }


    @Rule
    public final TestName name = new TestName() {
        @Override public String getMethodName() {
            String result = super.getMethodName();

            return result;
        }
    };

    @Rule public TestRule watcher = new TestWatcher() {
        @Override protected void succeeded(Description description) {
            //if junit detected the test passed, do something custom here
            //log.debug("PASS: test " + simpleTestCaseName() + " on thread " + Thread.currentThread().getName());
        }

        @Override protected void failed(Throwable e, Description description) {
            //if junit detected the test failed, do something custom here
            log.debug("FAIL: test " + simpleTestCaseName() + " on thread " + Thread.currentThread().getName());
            log.debug(description);
        }

    };

}
