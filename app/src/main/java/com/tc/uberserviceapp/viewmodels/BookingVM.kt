package com.tc.uberserviceapp.viewmodels

import com.tc.uberserviceapp.interfaces.BookingService
import com.tc.uberserviceapp.models.Booking

class BookingVM(val service: BookingService) : BookingService {
    override fun get(id: ULong): Array<Booking> {
        return service.get(id)
    }

    override fun book(booking: Booking): Boolean {
        return service.book(booking)
    }
}