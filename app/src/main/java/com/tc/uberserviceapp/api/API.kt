package com.tc.uberserviceapp.api

import com.beust.klaxon.Klaxon
import com.google.gson.Gson
import com.tc.uberserviceapp.interfaces.BookingService
import com.tc.uberserviceapp.interfaces.JobService
import com.tc.uberserviceapp.interfaces.LoginService
import com.tc.uberserviceapp.models.Booking
import com.tc.uberserviceapp.models.Job
import java.io.BufferedReader
import java.io.InputStreamReader
import java.io.OutputStreamWriter
import java.net.HttpURLConnection
import java.net.URL

class API(val target: String) : LoginService, JobService, BookingService {
    companion object
    {
        val Instance = API("http://localhost")
    }

    override val isLoggedIn: Boolean
        get() = _isLoggedIn

    private var _isLoggedIn = false
    private var token: Token? = null

    override fun login(email: String, password: String): Boolean {
        val result = call(target, "PUT", "/api/account/login", Login(email, password))
        token = Klaxon().parse<Token>(result.json)
        _isLoggedIn = result.success
        return result.success
    }

    override fun logout() {
        call(target, "PUT", "/api/account/logout", token)
        _isLoggedIn = false
    }

    override fun register(email: String, password: String, firstName: String, lastName: String): Boolean {
        val result = call(target, "POST", "/api/account/create", Registration(email, password, firstName, lastName))
        token = Klaxon().parse<Token>(result.json)
        _isLoggedIn = result.success
        return result.success
    }

    override fun getJob(id: ULong): Job? {
        val result = call(target, "GET", "/api/jobs/$id", null)
        if (result.success)
        {
            return Klaxon().parse<Job>(result.json)
        }
        else
        {
            return null
        }
    }

    override fun getJobs(count: Int): Array<Job> {
        val result = call(target, "GET", "/api/jobs", Range(null, count))
        if (result.success)
        {
            return Klaxon().parse<Array<Job>>(result.json)!!
        }
        else
        {
            return Array(0) { Job() }
        }
    }

    override fun get(id: ULong): Array<Booking> {
        val result = call(target, "GET", "/api/bookings/$id", null)
        if (result.success)
        {
            return Klaxon().parse<Array<Booking>>(result.json)!!
        }
        else
        {
            return Array(0) { Booking() }
        }
    }

    override fun book(booking: Booking): Boolean {
        if (!isLoggedIn) return false
        booking.by = token!!.user
        return call(target, "GET", "/api/bookings/book", booking).success
    }

    private fun <T> call(target: String, method: String, endpoint: String, data: T?): Response {
        var json: String = ""

        if (data != null)
        {
            json = Gson().toJson(data)
        }

        val url = URL(target + endpoint)

        with(url.openConnection() as HttpURLConnection) {
            requestMethod = method

            if (json.length > 0) {
                val outbound = OutputStreamWriter(outputStream)
                outbound.write(json)
                outbound.flush()
            }

            BufferedReader(InputStreamReader(inputStream)).use {
                return Response(responseCode, it.readText())
            }
        }
    }

    private class Response(code: Int, val json: String)
    {
        val success = code == 200
    }

    private class Login(val email: String, val password: String)

    private class Registration(val email: String, val password: String, val firstName: String, val lastName: String)

    private class Token(val user: String, val key: String)

    private class Range(start: Int?, count: Int)
}