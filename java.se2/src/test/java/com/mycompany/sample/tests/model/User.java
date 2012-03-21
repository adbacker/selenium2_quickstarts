package com.mycompany.sample.tests.model;

/**
 * Created by IntelliJ IDEA.
 * User: aaron.backer
 * Date: 3/17/12
 * Time: 3:48 PM
 * To change this template use File | Settings | File Templates.
 */
public class User {
    
    private String username = "";
    private String password = "";
    private String email = "";

    
    public User() {
        
    }
    
    public User(String username, String password, String email) {
        this();
        setUsername(username);
        setPassword(password);
        setEmail(email);
    }
    
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
