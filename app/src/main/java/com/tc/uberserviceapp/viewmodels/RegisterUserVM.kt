package ViewModels

import android.view.View
import androidx.lifecycle.ViewModel
import com.tc.uberserviceapp.interfaces.LoginService

/**
 *UberServiceApp created by trubattommy
 * student ID : 991_526_630
 * on 2021-04-18 */
class RegisterUserVM(val register: LoginService): ViewModel() {


    var firstName: String = ""
    var lastName: String = ""
    var email: String = ""
    var password: String = ""

    fun register(){
        register.register(email, password, firstName, lastName)
    }



}