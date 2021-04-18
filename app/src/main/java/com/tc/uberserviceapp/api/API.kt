package com.tc.uberserviceapp.api

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

class API : LoginService, JobService, BookingService {
    override val isLoggedIn: Boolean
        get() = _isLoggedIn

    private var _isLoggedIn = false

    override fun login(email: String, password: String): Boolean {


        return isLoggedIn
    }

    override fun logout() {
        TODO("Not yet implemented")
    }

    override fun register(
        email: String,
        password: String,
        firstName: String,
        lastName: String
    ): Boolean {
        TODO("Not yet implemented")
    }

    override fun getJob(id: ULong): Job {
        TODO("Not yet implemented")
    }

    override fun getJobs(count: Int): Array<Job> {
        TODO("Not yet implemented")
    }

    override fun get(id: ULong): Array<Booking> {
        TODO("Not yet implemented")
    }

    override fun book(booking: Booking): Boolean {
        TODO("Not yet implemented")
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

    private class Response(val code: Int, val json: String)
}