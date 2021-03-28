package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityCustomerHomePageBinding
import com.tc.uberserviceapp.databinding.ActivityJobFormBinding

class JobForm : AppCompatActivity() {
    private lateinit var binding: ActivityJobFormBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityJobFormBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnRequest.setOnClickListener{

            val intent = Intent(this, WorkerWaitingScreen::class.java)
            startActivity(intent)
        }

    }
}