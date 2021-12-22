import './App.css';

// Importing components
import {FormTextField} from './components/common/FormTextField';
import {ButtonCustom} from './components/common/ButtonCustom';
import {DropDown} from './components/common/DropDown';
import { Routes, Route, Link } from 'react-router-dom';
import {SingIn} from './components/common/SingIn';
import {SingUp} from './components/common/SingUp';
import {UserCabinet} from './components/user/UserCabinet';
import {AdminChat} from './components/user/ConnectWithAdmin';
import {CityList} from './components/user/CityList';

import {ChooseWeatherSource} from'./components/admin/ChooseWeatherSource'
import {AdminCabinet} from './components/admin/AdminCabinet';
import { CreateAccAdmin } from './components/admin/CreateAccAdmin';
import { DeleteUser } from './components/admin/DeleteUser';

import { Navigate } from 'react-router-dom';

function App() {

  if(window.location.pathname === '/'){
    window.location.replace("/sign-in");
  }
  
  return (
    <div className="App">
      <Routes>
        <Route path="/sign-in" element={<SingIn/>}/>
        <Route path="/sign-up" element={<SingUp/>}/>
        <Route path="/cabinet" element={<UserCabinet/>}/>
        <Route path="/cabinetAdmin" element={<AdminCabinet/>}/>
        <Route path="/createAccAdmin" element={<CreateAccAdmin/>}/>
        <Route path="/connectWithAdmin" element={<AdminChat/>}/>
        <Route path="/CityList" element={<CityList/>}/>
        <Route path="/weather" element = {<ChooseWeatherSource/>}/>
        <Route path="/deleteUser" element = {<DeleteUser/>}/>
      </Routes>
    </div>
  );
}
export default App;
