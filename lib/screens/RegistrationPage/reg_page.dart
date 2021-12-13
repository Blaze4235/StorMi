import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:stor_mi/constants/validator.dart';

final _emailKey = GlobalKey<FormState>();
TextEditingController emailController = TextEditingController();
TextEditingController phoneNumberController = TextEditingController();
TextEditingController usernameController = TextEditingController();
TextEditingController passwordController = TextEditingController();

class RegPage extends StatelessWidget {
  const RegPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.green,
        title: Text("Create new account", textAlign: TextAlign.center,),
        centerTitle: true,
      ),
      body: Material(
    child: SingleChildScrollView(
      child: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Row(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Form(
              key: _emailKey,
              child: Column(
                children: [
                  SizedBox(
                    height: 16,
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width - 32,
                    child: TextFormField(
                      controller: emailController,
                        validator: (value) => Validator.validateEmail(value),
                        decoration: InputDecoration(
                          border: OutlineInputBorder(),
                          hintText: "Email",
                          label: Text('Email'),
                        )),
                  ),
                  SizedBox(
                    height: 16,
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width - 32,
                    child: TextFormField(
                      validator: (value) => Validator.validateMobile(value!),
                        maxLength: 10,
                        keyboardType: TextInputType.number,
                        decoration: InputDecoration(
                          prefixText: "+38",
                          border: OutlineInputBorder(),
                          // hintText: "Phone number",
                          label: Text('Phone number'),
                        )),
                  ),
                  SizedBox(
                    height: 16,
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width - 32,
                    child: TextFormField(
                      validator: (value) => Validator.validateUserName(value!),
                        decoration: InputDecoration(
                          border: OutlineInputBorder(),
                          hintText: "Username",
                          label: Text('Username'),
                        )),
                  ),
                  SizedBox(
                    height: 16,
                  ),
                  Container(
                    width: MediaQuery.of(context).size.width - 32,
                    child: TextFormField(
                        obscureText: true,
                        validator: (value) => Validator.validatePassword(value!),
                        decoration: InputDecoration(
                          border: OutlineInputBorder(),
                          hintText: "Password",
                          label: Text('Password'),
                        )),
                  ),
                  SizedBox(
                    height: 16,
                  ),
                  Container(
                    height: 48,
                    width: MediaQuery.of(context).size.width - 64,
                    child: RaisedButton(
                      color: Colors.green,
                      onPressed: () {
                          // Validate returns true if the form is valid, or false otherwise.
                          if (_emailKey.currentState!.validate()) {
                            // If the form is valid, display a snackbar. In the real world,
                            // you'd often call a server or save the information in a database.
                            ScaffoldMessenger.of(context).showSnackBar(
                              const SnackBar(content: Text('Processing Data')),
                            );
                          }
                      },
                      child: Text(
                        'Create account',
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 18,
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    ),
    ),
    );
  }
}
