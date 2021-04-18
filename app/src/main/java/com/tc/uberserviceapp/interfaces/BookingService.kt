package com.tc.uberserviceapp.interfaces

import com.tc.uberserviceapp.models.Booking

interface BookingService {
    fun get(id: ULong) : Array<Booking>
    fun book(booking: Booking) : Boolean
}