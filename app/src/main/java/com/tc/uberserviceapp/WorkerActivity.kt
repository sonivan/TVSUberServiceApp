package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityRegisterBinding
import com.tc.uberserviceapp.databinding.ActivityWorkerBinding

class WorkerActivity : AppCompatActivity() {
    private lateinit var binding: ActivityWorkerBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        binding = ActivityWorkerBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnUpdateProfile.setOnClickListener{

            val intent = Intent(this, WorkerProfile::class.java)
            startActivity(intent)

        }

        binding.btnViewRequests.setOnClickListener{

            val intent = Intent(this, JobWaitingScreen::class.java)
            startActivity(intent)

        }

        binding.btnLogout.setOnClickListener{

            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)

        }

    }
}