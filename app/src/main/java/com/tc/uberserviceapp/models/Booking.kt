package com.tc.uberserviceapp.models

import java.time.LocalDateTime

class Booking {
    var by = ""
    val job : ULong = 0u
    val start = LocalDateTime.MIN
    val end = LocalDateTime.MIN
}