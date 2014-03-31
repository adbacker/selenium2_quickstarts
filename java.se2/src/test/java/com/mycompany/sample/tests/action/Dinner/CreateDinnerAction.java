package com.mycompany.sample.tests.action.Dinner;

import com.mycompany.sample.tests.Action;
import com.mycompany.sample.tests.Util.WebBrowser;
import com.mycompany.sample.tests.model.User;
import com.mycompany.sample.tests.model.Dinner;
/**
 * Created by win7-64-vm on 3/18/14.
 */
public class CreateDinnerAction extends Action {

    User user;
    Dinner dinner;

    public CreateDinnerAction(WebBrowser browser) {
        super(browser);

    }

    @Override
    public boolean execute() {
        return false;
    }
}
