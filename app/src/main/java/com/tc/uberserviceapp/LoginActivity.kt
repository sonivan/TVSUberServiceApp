package com.tc.uberserviceapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.databinding.ActivityJobWaitingScreenBinding
import com.tc.uberserviceapp.databinding.ActivityLoginBinding

class LoginActivity : AppCompatActivity() {
    private lateinit var binding: ActivityLoginBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        binding = ActivityLoginBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnLoginC.setOnClickListener{

            val intent = Intent(this, CustomerHomePage::class.java)
            startActivity(intent)
        }

        binding.btnRegisterPage.setOnClickListener{

            val intent = Intent(this, RegisterActivity::class.java)
            startActivity(intent)
        }

        binding.btnSignInW.setOnClickListener{

            val intent = Intent(this, WorkerActivity::class.java)
            startActivity(intent)
        }


    }
}