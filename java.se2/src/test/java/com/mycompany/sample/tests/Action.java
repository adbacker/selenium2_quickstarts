package com.mycompany.sample.tests;

import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.model.User;

/**
 * Created by IntelliJ IDEA.
 * User: aaron.backer
 * Date: 3/17/12
 * Time: 3:34 PM
 * To change this template use File | Settings | File Templates.
 */
public abstract class Action {
    protected WebBrowser _browser;

    public Action(WebBrowser browser) {
        _browser = browser;
    }

    public abstract boolean execute();

}
