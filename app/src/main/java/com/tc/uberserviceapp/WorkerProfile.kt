package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityWorkerBinding
import com.tc.uberserviceapp.databinding.ActivityWorkerProfileBinding

class WorkerProfile : AppCompatActivity() {
    private lateinit var binding: ActivityWorkerProfileBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        binding = ActivityWorkerProfileBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnSave.setOnClickListener{

            val intent = Intent(this, WorkerActivity::class.java)
            startActivity(intent)
        }

    }


}