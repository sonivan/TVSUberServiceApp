package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityJobWaitingScreenBinding
import com.tc.uberserviceapp.databinding.ActivityWorkerWaitingScreenBinding

class WorkerWaitingScreen : AppCompatActivity() {
    private lateinit var binding: ActivityWorkerWaitingScreenBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityWorkerWaitingScreenBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnCancelC.setOnClickListener{

            val intent = Intent(this, CustomerHomePage::class.java)
            startActivity(intent)
        }

    }


}