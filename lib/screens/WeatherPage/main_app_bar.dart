import 'dart:async';
import 'dart:convert';
import 'dart:io';
import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:stor_mi/screens/ChooseCityPage/choose_city_page.dart';


String cityValue = "";

class MainAppBar extends StatefulWidget {
  var changeView;
  Function()? notifyParent;
  MainAppBar({Key? key, this.changeView, this.notifyParent}) : super(key: key);
  @override
  _MainAppBarState createState() => _MainAppBarState();
}

class _MainAppBarState extends State<MainAppBar> {
  @override
  Widget build(BuildContext context) {
    // readStateAppJson();
    return Container(
      child: SliverAppBar(
        backgroundColor: Colors.transparent,
        expandedHeight: 120,
        collapsedHeight: 80,
        floating: false,
        pinned: true,
        flexibleSpace: FlexibleSpaceBar(
            centerTitle: true,
            stretchModes: [StretchMode.zoomBackground],
            title: Padding(
              padding: const EdgeInsets.fromLTRB(12, 0, 4, 0),
              child: BackdropFilter(
                filter: ImageFilter.blur(sigmaX: 20, sigmaY: 20),
                child: Container(
                  color: Colors.grey.withOpacity(0.1),
                  alignment: Alignment.center,
                  child: Column(
                    mainAxisSize: MainAxisSize.max,
                    mainAxisAlignment: MainAxisAlignment.end,
                    children: [
                      Row(
                        mainAxisSize: MainAxisSize.max,
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(
                            'StorMi',
                            style: TextStyle(
                              fontSize: 24,
                              color: Colors.black,
                            ),
                          ),
                          Material(
                            color: Colors.transparent,
                            shadowColor: Colors.transparent,
                            borderRadius: BorderRadius.circular(50),
                            child: InkWell(
                              borderRadius: BorderRadius.circular(100),
                              radius: 100,
                              onTap: () => {
                              Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) => ChooseCityPage())),
                              },
                              child: Container(
                                width: 50,
                                height: 50,
                                child: Icon(
                                  Icons.location_city,
                                  size: 24,
                                  color: Colors.black,
                                ),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
              ),
            )),
      ),
    );
  }

  // void refresh() {
  //   setState(() {
  //     changeView = !changeView;
  //     widget.notifyParent!();
  //     opacityTrue = opacityTrue == 0.0 ? 1 : 0.0;
  //     writeStateAppJson();
  //   });
  // }

  // Future<File> get _localFile async {
  //   final path = await _localPath;
  //   return File('$path/stateApp.json');
  // }
  //
  // Future<String> get _localPath async {
  //   final directory = await getApplicationDocumentsDirectory();
  //
  //   return directory.path;
  // }
  //
  // Future<void> readStateAppJson() async {
  //   try {
  //     final file = await _localFile;
  //
  //     final contents = await file.readAsString();
  //     var data = await json.decode(contents);
  //     changeView = data;
  //   }
  //   catch(e){
  //     print(e);
  //   }
  // }
  // Future<File> writeStateAppJson() async {
  //   final file = await _localFile;
  //   String jsonTags = jsonEncode(changeView);
  //   return file.writeAsString(jsonTags);
  // }
}
