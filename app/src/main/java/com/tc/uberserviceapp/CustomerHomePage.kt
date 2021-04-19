package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.api.API
import com.tc.uberserviceapp.databinding.ActivityCustomerHomePageBinding
import com.tc.uberserviceapp.viewmodels.JobsVM

class CustomerHomePage : AppCompatActivity() {

    private lateinit var binding: ActivityCustomerHomePageBinding

    private var ViewModel = JobsVM(API.Instance)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityCustomerHomePageBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnBeauty.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnCleaning.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnConstruction.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnPainting.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnRepair.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnSpecialService.setOnClickListener{

            val intent = Intent(this, JobForm::class.java)
            startActivity(intent)
        }

        binding.btnLogoutC.setOnClickListener{

            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)
        }


    }
}