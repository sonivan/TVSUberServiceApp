package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityJobFormBinding
import com.tc.uberserviceapp.databinding.ActivityJobWaitingScreenBinding

class JobWaitingScreen : AppCompatActivity() {
    private lateinit var binding: ActivityJobWaitingScreenBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityJobWaitingScreenBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)


        binding.btnCancelW.setOnClickListener{

            val intent = Intent(this, WorkerActivity::class.java)
            startActivity(intent)
        }
    }
}