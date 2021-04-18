package com.tc.uberserviceapp.api

import com.tc.uberserviceapp.interfaces.BookingService
import com.tc.uberserviceapp.interfaces.JobService
import com.tc.uberserviceapp.interfaces.LoginService
import com.tc.uberserviceapp.models.Booking
import com.tc.uberserviceapp.models.Job

class API : LoginService, JobService, BookingService {
    override val isLoggedIn: Boolean
        get() = TODO("Not yet implemented")

    override fun login(email: String, password: String): Boolean {
        TODO("Not yet implemented")
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

}