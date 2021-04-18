package com.tc.uberserviceapp.models

class Job {
    val id: ULong = 0u
    val title = ""
    val shortText = ""
    val description = ""
    val images = Array<String>(0) { "" }
    val owner = Owner()

    class Owner {
        val firstName: String = ""
        val lastName: String = ""
    }
}