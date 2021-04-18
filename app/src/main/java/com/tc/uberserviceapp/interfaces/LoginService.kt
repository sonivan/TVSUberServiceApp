package com.tc.uberserviceapp.interfaces

interface LoginService {
    val isLoggedIn: Boolean
    fun login(email: String, password: String): Boolean
    fun logout()
    fun register(email: String, password: String, firstName: String, lastName: String): Boolean
}