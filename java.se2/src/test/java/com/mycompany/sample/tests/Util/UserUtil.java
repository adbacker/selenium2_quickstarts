package com.mycompany.sample.tests.Util;

import java.util.UUID;

/**
 * Created by win7-64-vm on 3/18/14.
 */
public class UserUtil {

    public static String RandomUserid() {
        String randomUserName = "usr" + UUID.randomUUID().toString().substring(0, 10).replace("-", "");
        return randomUserName;
    }
}
