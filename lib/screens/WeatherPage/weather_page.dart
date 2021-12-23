import 'package:flutter/material.dart';
import 'package:country_state_city_picker/country_state_city_picker.dart';

import 'main_app_bar.dart';

class WeatherPage extends StatefulWidget {
  const WeatherPage({Key? key}) : super(key: key);

  @override
  _WeatherPgeState createState() => _WeatherPgeState();
}

class _WeatherPgeState extends State<WeatherPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: PreferredSize(
        preferredSize: Size.fromHeight(0),
        child: AppBar(),
      ),
      resizeToAvoidBottomInset: false,
      body: Stack(
        children: [
          Container(
              height: MediaQuery.of(context).size.height,
              child: Image.asset(
                "res/images/login_back.jpg",
                fit: BoxFit.cover,
              )),
          CustomScrollView(
            physics: const BouncingScrollPhysics(),
            slivers: [
              MainAppBar(
                notifyParent: refresh,
              ),
              NotesWidget(),
            ],
          ),
        ],
      ),
    );
  }

  void refresh() {
    setState(() {});
  }
}

class NotesWidget extends StatefulWidget {
  NotesWidget({Key? key, this.items, this.refresh}) : super(key: key);
  var refresh;
  var items;
  bool isLoading = false;
  @override
  _NotesWidgetState createState() => _NotesWidgetState();
}

class _NotesWidgetState extends State<NotesWidget> {
  var delItem;
  int stop = 1;
  List config = [];

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    if (widget.refresh != null) {
      widget.refresh!();
    }

    futureLoad();

    SliverChildBuilderDelegate builderDelegate = SliverChildBuilderDelegate(
      (BuildContext context, int index) {
        return Padding(
          padding: const EdgeInsets.all(8.0),
          child: Container(),
        );
      },
    );
    return SliverList(
        delegate: SliverChildBuilderDelegate((BuildContext context, int index) {
      return Align(
              alignment: Alignment.center,
              child: Padding(
                padding: const EdgeInsets.symmetric(vertical: 8),
                child: Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.all(16.0),
                      child: SelectState(onCityChanged: (value) => {
                        setState(() {
                          cityValue = value;
                        })
                      }, onStateChanged: (String value) {  }),
                    ),
                    cityValue.isNotEmpty ? Container(
                      padding: EdgeInsets.symmetric(horizontal: 16),
                      child: Column(
                        children: [
                          // Text(
                          //   'Empty...',
                          //   style: TextStyle(fontSize: 50, color: Colors.grey),
                          // ),
                          Container(
                              width: MediaQuery.of(context).size.width,
                              child: Card(
                                child: Container(
                                    padding: EdgeInsets.all(16),
                                    child: Row(
                                      mainAxisSize: MainAxisSize.max,
                                      mainAxisAlignment: MainAxisAlignment.center,
                                      children: [
                                        Column(
                                          children: [
                                            Text(
                                              '-13°',
                                              style: TextStyle(
                                                fontSize: 32,
                                              ),
                                            ),
                                            Text(
                                              'Cloudy',
                                              style: TextStyle(
                                                fontSize: 24,
                                              ),
                                            ),
                                          ],
                                        ),
                                      ],
                                    )),
                              )),
                          Container(
                            width: MediaQuery.of(context).size.width,
                            height: 152,
                            child: Card(
                              child: Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: Column(
                                  children: [
                                    Text("DAILY FORECAST"),
                                    Expanded(
                                      child: ListView(
                                        scrollDirection: Axis.horizontal,
                                        children: [
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.cloud_outlined),
                                                Text("Today"),
                                                Text("Dec 23"),
                                                Text("-13°"),
                                                Text("Wind 14.0 km/h"),
                                                Text("Humidity 76%")
                                              ],
                                            ),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.ac_unit),
                                                Text("Fri"),
                                                Text("Dec 24"),
                                                Text("-15°"),
                                                Text("Wind 16.0 km/h"),
                                                Text("Humidity 83%")
                                              ],
                                            ),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.ac_unit),
                                                Text("Sat"),
                                                Text("Dec 25"),
                                                Text("-5°"),
                                                Text("Wind 11.0 km/h"),
                                                Text("Humidity 80%")
                                              ],
                                            ),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.ac_unit),
                                                Text("Sun"),
                                                Text("Dec 26"),
                                                Text("-4°"),
                                                Text("Wind 9.0 km/h"),
                                                Text("Humidity 88%")
                                              ],
                                            ),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.ac_unit),
                                                Text("Mon"),
                                                Text("Dec 27"),
                                                Text("-6°"),
                                                Text("Wind 4.0 km/h"),
                                                Text("Humidity 69%")
                                              ],
                                            ),
                                          ),
                                          Padding(
                                            padding: const EdgeInsets.all(4.0),
                                            child: Column(
                                              children: [
                                                Icon(Icons.grain),
                                                Text("Tue"),
                                                Text("Dec 28"),
                                                Text("-6°"),
                                                Text("Wind 8.0 km/h"),
                                                Text("Humidity 78%")
                                              ],
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

                        ],
                      ),
                    ) :
           Center(
              child: Container(
                      padding: EdgeInsets.only(top: 100),
                      width: 50,
                      height: 150,
                      child: CircularProgressIndicator()),
            ),
                  ],
                )));
    }, childCount: 1));
  }

  void futureLoad() {
    Future.delayed(Duration(seconds: 3)).then((_) {
      setState(() {
        widget.isLoading = true;
      });
    });
  }
}
