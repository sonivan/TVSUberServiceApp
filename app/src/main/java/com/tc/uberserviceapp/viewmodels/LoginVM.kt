package ViewModels

import androidx.lifecycle.ViewModel
import com.tc.uberserviceapp.interfaces.LoginService

/**
 *UberServiceApp created by trubattommy
 * student ID : 991_526_630
 * on 2021-04-18 */
class LoginVM(val login: LoginService): ViewModel() {

    var email: String = ""
    var password: String = ""

    fun login(){
        login.login(email, password)
    }

}