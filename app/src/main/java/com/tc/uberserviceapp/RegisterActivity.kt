package com.tc.uberserviceapp

import ViewModels.LoginVM
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.tc.uberserviceapp.api.API
import com.tc.uberserviceapp.databinding.ActivityMainBinding
import com.tc.uberserviceapp.databinding.ActivityRegisterBinding

class RegisterActivity : AppCompatActivity() {
    private lateinit var binding: ActivityRegisterBinding

    private var ViewModel = LoginVM(API.Instance)

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)


        binding = ActivityRegisterBinding.inflate(layoutInflater)
        val view = binding.root
        setContentView(view)

        binding.btnSignInC.setOnClickListener{

            val intent = Intent(this, CustomerHomePage::class.java)
            startActivity(intent)
        }


    }
}