import 'package:flutter/material.dart';
import 'package:stor_mi/screens/AuthPage/auth_page.dart';

class UserAccountPage extends StatefulWidget {
  const UserAccountPage({Key? key}) : super(key: key);

  @override
  _UserAccountPageState createState() => _UserAccountPageState();
}

class _UserAccountPageState extends State<UserAccountPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.green,
        title: Text(
          "User Profile",
          textAlign: TextAlign.center,
        ),
        centerTitle: true,
      ),
      body: Material(
        child: Center(
          child: Column(
            children: [
              SizedBox(
                height: 16,
              ),
              Text(
                "User email: qwe@qwe.com",
                style: TextStyle(
                  fontSize: 24,
                ),
              ),
              SizedBox(
                height: 16,
              ),
              Container(
                height: 48,
                width: MediaQuery.of(context).size.width - 64,
                child: RaisedButton(
                  color: Colors.red,
                  onPressed: () {
                    Navigator.pushReplacement(context,
                        MaterialPageRoute(builder: (context) => AuthPage()));
                  },
                  child: Text(
                    'Logout from acoount',
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
      ),
    );
  }
}
