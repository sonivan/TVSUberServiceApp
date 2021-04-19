package com.tc.uberserviceapp.viewmodels

import com.tc.uberserviceapp.interfaces.JobService
import com.tc.uberserviceapp.models.Job

class JobsVM(val service: JobService) : JobService {
    override fun getJob(id: ULong): Job? {
        return service.getJob(id)
    }

    override fun getJobs(count: Int): Array<Job> {
        return service.getJobs(count)
    }
}