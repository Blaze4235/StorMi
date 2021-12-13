import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:sliding_up_panel/sliding_up_panel.dart';
import 'package:stor_mi/screens/RegistrationPage/reg_page.dart';

class AuthPage extends StatelessWidget {
  const AuthPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Material(
        child: Stack(
          alignment: Alignment.topCenter,
          children: <Widget>[
            SlidingUpPanel(
              maxHeight: 500,
              minHeight: 76,
              parallaxEnabled: true,
              parallaxOffset: .5,
              body: Stack(
                children: [
                  Container(
                      height: MediaQuery.of(context).size.height,
                      child: Image.asset(
                        "res/images/login_back.jpg",
                        fit: BoxFit.cover,
                      )),
                  Center(
                    child: Text(
                      "StorMi",
                      style: TextStyle(
                        fontSize: 32,
                      ),
                    ),
                  )
                ],
              ),
              panelBuilder: (sc) => _panel(sc, context),
              borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(18.0),
                  topRight: Radius.circular(18.0)),
            ),
          ],
        ),
      ),
    );
  }

  Widget _panel(ScrollController sc, BuildContext context) {
    return MediaQuery.removePadding(
        context: context,
        removeTop: true,
        child: ListView(
          controller: sc,
          children: <Widget>[
            SizedBox(
              height: 16.0,
            ),
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Container(
                  width: 30,
                  height: 5,
                  decoration: BoxDecoration(
                      color: Colors.grey[300],
                      borderRadius: BorderRadius.all(Radius.circular(12.0))),
                ),
              ],
            ),
            // const SizedBox(
            //   height: 18.0,
            // ),
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                mainAxisSize: MainAxisSize.max,
                children: <Widget>[
                  Column(
                    children: [
                      Text(
                        "Sign to your account",
                        style: TextStyle(
                          fontWeight: FontWeight.normal,
                          fontSize: 24.0,
                        ),
                      ),
                      SizedBox(
                        height: 16,
                      ),
                      Container(
                        width: MediaQuery.of(context).size.width - 32,
                        child: TextField(
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
                        child: TextField(
                            decoration: InputDecoration(
                          border: OutlineInputBorder(),
                          hintText: "Password",
                          label: Text('Password'),
                        )),
                      ),
                      Row(
                        mainAxisSize: MainAxisSize.max,
                        mainAxisAlignment: MainAxisAlignment.spaceAround,
                        children: [
                          CupertinoButton(
                              child: Text(
                                "I dont`t have account",
                                style: TextStyle(fontSize: 14),
                              ),
                              onPressed: () {
                                Navigator.of(context).push(MaterialPageRoute(
                                    builder: (context) => RegPage()));
                              }),
                          CupertinoButton(
                              child: Text("Forgot Password?",
                                  style: TextStyle(fontSize: 14)),
                              onPressed: () {}),
                        ],
                      )
                    ],
                  ),
                  Container(
                    height: 48,
                    width: MediaQuery.of(context).size.width,
                    child: RaisedButton(
                      color: Colors.green,
                      onPressed: () {},
                      child: Text(
                        'Login',
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 18,
                        ),
                      ),
                    ),
                  )
                ],
              ),
            ),
          ],
        ));
  }
}
