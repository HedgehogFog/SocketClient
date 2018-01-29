using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController {
    public static String generatePlayer(String login)
    {
        return "action:login;login:" + login;
    }
}
