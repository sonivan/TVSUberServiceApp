package com.tc.uberserviceapp.interfaces

import com.tc.uberserviceapp.models.Job

interface JobService {
    fun getJob(id: ULong) : Job?
    fun getJobs(count: Int) : Array<Job>
}